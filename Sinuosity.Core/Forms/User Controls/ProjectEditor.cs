using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sinuosity.Common;

namespace Sinuosity.Forms.User_Controls
{
    public partial class ProjectEditor : UserControl
    {

        private EditorFormTransactionManager tm;
        public ProjectEditor(TreeView treeView, string nodePath)
        {
            InitializeComponent();
            tm = new EditorFormTransactionManager(nodePath, this, treeView, Tb_ProjectID, lb_StreamList);
            tm.AddDataEntryControl(tb_ProjectLat);
            tm.AddDataEntryControl(tb_ProjectLon);
            tm.AddDataEntryControl(tb_ProjectState);
            tm.AddDataEntryControl(tb_ProjectCounty);
            tm.AddDataEntryControl(tb_ProjectERL3Name);
            tm.AddDataEntryControl(tb_ProjectERL4Name);
            tm.AddDataEntryControl(tb_ProjectERCode);
            tm.AddDataEntryControl(tb_ProjectHUCName);
            tm.AddDataEntryControl(tb_ProjectHUCCode);
        }
        protected override void OnLoad(EventArgs e)
        {
            tm.ListBox_Repopulate();
            tm.UpdateControls();
            SetHeader();
        }
        private void SetHeader() { gb_Main.Text = ProjectManager.Project.GetID(""); this.Parent.Text = ProjectManager.Project.GetID(""); }
        private void RestoreOnLeave(object sender, EventArgs e) { tm.RestoreData(sender, e); }
        private void ChangeUnit(object sender, EventArgs e) { tm.EnterData(sender); }
        private void EnterValue(object sender, KeyEventArgs e)
        {
        } // If the ID was successfully set, update the header text
        private void EnterValue_Decimal(object sender, KeyEventArgs e) { tm.EnterData(sender, true, e, new DecimalValidator()); } // Use DecimalValidator for decimal values
        private void ListBox_AddItem(object sender, EventArgs e) { tm.ListBox_AddItem(typeof(TS_Stream), "Please enter a stream ID."); }
        private void ListBox_CopyItem(object sender, EventArgs e) { tm.ListBox_CopyItem(); }
        private void ListBox_DeleteItem(object sender, EventArgs e) { tm.ListBox_RemoveItem(); }
        //private void ListBox_MoveDown(object sender, EventArgs e) { tm.ListBox_MoveItem(false, checkBox1.Checked); }
        //private void ListBox_MoveUp(object sender, EventArgs e) { tm.ListBox_MoveItem(true, checkBox1.Checked); }
        private void ListBox_Leave(object sender, EventArgs e) { tm.ListBox_Leave(); }
        private void ListBox_GoToItem(object sender, EventArgs e) { tm.ListBox_GoToItem(); }
        private void GoBack(object sender, EventArgs e) { tm.TreeView_Back(); }
        private void Btn_EditNotes_Click(object sender, EventArgs e)
        {
            string path = tm.GetFullPath(((Button)sender).Tag);
            string text = Convert.ToString(ProjectManager.Project.GetValue(path));
            string title = gb_Main.Text;
            using (TextBlockInput inputForm = new TextBlockInput(text, title))
            {
                bool result = inputForm.ShowDialog() == DialogResult.OK;
                if (result)
                {
                    ProjectManager.Project.SetValue(inputForm.ResultText, path);
                }
            }
        }
        private void btn_CalcGeoProps_Click(object sender, EventArgs e)
        {
            try
            {
                decimal latitude = Convert.ToDecimal(ProjectManager.Project.GetValue("Properties/Latitude"));
                decimal longitude = Convert.ToDecimal(ProjectManager.Project.GetValue("Properties/Longitude"));
                using (ProjectPropertiesGeoCalcs form = new ProjectPropertiesGeoCalcs(latitude, longitude, out var results))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        foreach (KeyValuePair<string, object> kvp in results)
                        {
                            string tag = kvp.Key;
                            object value = kvp.Value;
                            string path = tm.GetFullPath("") + "/Properties/" + tag;
                            ProjectManager.Project.SetValue(value, path);
                        }
                        tm.UpdateControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating geographic properties: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_GeoConfig_Click(object sender, EventArgs e)
        {
            using (GeopropertyConfiguration form = new GeopropertyConfiguration())
            {
                DialogResult result = form.ShowDialog();

                // Code to run after Form1 closes
                if (result == DialogResult.OK)
                {
                    // Example: Update a label or run some logic
                }
            }
        }
    }
}
