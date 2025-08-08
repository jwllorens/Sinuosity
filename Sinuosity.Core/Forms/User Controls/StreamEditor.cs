using Sinuosity.Common;
using System;
using System.Windows.Forms;

namespace Sinuosity.Forms.User_Controls
{
    public partial class StreamEditor : UserControl
    {
        private EditorFormTransactionManager tm;

        public StreamEditor(TreeView treeView, string nodePath)
        {
            InitializeComponent();
            tm = new EditorFormTransactionManager(nodePath, this, treeView, Tb_StreamID, lb_ReachList);
            //add tagged controls here
            tm.AddDataEntryControl(tb_StreamAlternateName);
            //add custom event handlers here for special calculations
            //tm.RegisterEventHandler(control, method);
        }
        protected override void OnLoad(EventArgs e)
        {
            tm.ListBox_Repopulate();
            tm.UpdateControls();
            SetHeader();
        }
        private void SetHeader() { gb_Main.Text = tm.ThisID; }
        private void RestoreOnLeave(object sender, EventArgs e) { tm.RestoreData(sender, e); }
        private void ChangeUnit(object sender, EventArgs e) { tm.EnterData(sender); }
        private void EnterValue(object sender, KeyEventArgs e) { if (tm.EnterData(sender, true, e) && sender == tm.IDbox) SetHeader(); } // If the ID was successfully set, update the header text
        private void EnterValue_Decimal(object sender, KeyEventArgs e) { tm.EnterData(sender, true, e, new DecimalValidator()); } // Use DecimalValidator for decimal values
        private void ListBox_AddItem(object sender, EventArgs e) { tm.ListBox_AddItem(typeof(TS_Reach), "Please enter a reach ID."); }
        private void ListBox_SplitItem(object sender, EventArgs e) { tm.ListBox_SplitItem(); }
        private void ListBox_DeleteItem(object sender, EventArgs e) { tm.ListBox_RemoveItem(); }
        private void ListBox_MoveDown(object sender, EventArgs e) { tm.ListBox_MoveItem(false, checkBox1.Checked); }
        private void ListBox_MoveUp(object sender, EventArgs e) { tm.ListBox_MoveItem(true, checkBox1.Checked); }
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
    }
}
