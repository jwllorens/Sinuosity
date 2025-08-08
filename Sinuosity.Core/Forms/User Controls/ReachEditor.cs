using Sinuosity.Common;
using System.Windows.Forms;
using System;

namespace Sinuosity.Forms.User_Controls
{
    public partial class ReachEditor : UserControl
    {
        private EditorFormTransactionManager tm;
        public ReachEditor(TreeView treeView, string nodePath)
        {
            InitializeComponent();
            tm = new EditorFormTransactionManager(nodePath, this, treeView, Tb_ReachID);
            tm.AddDataEntryControl(vi_Design_UpstreamDrainageArea);
            tm.AddDataEntryControl(vi_Design_LateralDrainageArea);
            tm.AddDataEntryControl(vi_Design_TotalDrainageArea);
            tm.AddDataEntryControl(vi_Design_BeginStation);
            tm.AddDataEntryControl(vi_Design_EndStation);
            tm.AddDataEntryControl(vi_Design_Length);
            tm.RegisterEventHandler(vi_Design_UpstreamDrainageArea, CalculateTotalDrainageArea);
            tm.RegisterEventHandler(vi_Design_LateralDrainageArea, CalculateTotalDrainageArea);
            tm.RegisterEventHandler(vi_Design_BeginStation, CalculateTotalLength);
            tm.RegisterEventHandler(vi_Design_EndStation, CalculateTotalLength);
        }
        protected override void OnLoad(EventArgs e)
        {
            tm.ListBox_Repopulate();
            tm.UpdateControls();
            SetHeader();
        }
        private void SetHeader() { gb_Main.Text = $"{tm.ParentID}-{tm.ThisID}"; }
        private void RestoreOnLeave(object sender, EventArgs e) { tm.RestoreData(sender, e); }
        private void ChangeUnit(object sender, EventArgs e) { tm.EnterData(sender); }
        private void EnterValue(object sender, KeyEventArgs e) { if (tm.EnterData(sender, true, e) && sender == tm.IDbox) SetHeader(); } // If the ID was successfully set, update the header text
        private void EnterValue_Decimal(object sender, KeyEventArgs e) { tm.EnterData(sender, true, e, new DecimalValidator()); } // Use DecimalValidator for decimal values
        private void ListBox_AddItem(object sender, EventArgs e) { tm.ListBox_AddItem(typeof(TS_Reach), "Please enter a reach ID."); }
        private void ListBox_SplitItem(object sender, EventArgs e) { tm.ListBox_SplitItem(); }
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
        private void CalculateTotalDrainageArea(object sender)
        {
            decimal? upstreamArea = vi_Design_UpstreamDrainageArea.Value;
            decimal? lateralArea = vi_Design_LateralDrainageArea.Value;
            UnitArea upstreamUnit = vi_Design_UpstreamDrainageArea.Unit;
            UnitArea lateralUnit = vi_Design_LateralDrainageArea.Unit;
            UnitArea totalUnit = vi_Design_TotalDrainageArea.Unit;
            if (upstreamArea != null && lateralArea != null && upstreamUnit != null && lateralUnit != null)
            {
                UnitArea resultUnit = totalUnit;
                if (totalUnit == null) resultUnit = Units.GetPriorityUnit(upstreamUnit, lateralUnit, new string[] { "mi²", "ac", "ft²" });
                decimal? result = Units.ConvertValue((decimal)upstreamArea, upstreamUnit, resultUnit) + Units.ConvertValue((decimal)lateralArea, lateralUnit, resultUnit);
                vi_Design_TotalDrainageArea.Value = result;
                if (resultUnit != totalUnit) vi_Design_TotalDrainageArea.Unit = resultUnit;
            }
            else vi_Design_TotalDrainageArea.Value = null; // Reset if any area is null
            tm.EnterData(vi_Design_TotalDrainageArea);
        }
        private void CalculateTotalLength(object sender)
        {
            decimal? beginStation = vi_Design_BeginStation.Value;
            decimal? endStation = vi_Design_EndStation.Value;

            if (beginStation != null && endStation != null && beginStation > endStation)
            {
                MessageBox.Show("Begin station must be less than or equal to end station.", "Invalid Stationing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vi_Design_BeginStation.Value = null;
                tm.EnterData(vi_Design_BeginStation);
                vi_Design_EndStation.Value = null;
                tm.EnterData(vi_Design_EndStation);
                vi_Design_Length.Value = null;
                vi_Design_Length.Unit = null;
                tm.EnterData(vi_Design_Length);
                return;
            }
            UnitLength lengthUnit = vi_Design_Length.Unit;
            if (beginStation != null && endStation != null)
            {
                decimal? result = endStation - beginStation;
                if (lengthUnit == null) lengthUnit = Units.Foot;
                vi_Design_Length.Unit = lengthUnit;
                vi_Design_Length.Value = Units.ConvertLength((decimal)result, Units.Foot, lengthUnit);
            }
            else // Reset if either station is null
            {
                vi_Design_Length.Value = null;
                vi_Design_Length.Unit = null;
            }
            tm.EnterData(vi_Design_Length);
        }

        private void valueInput_Variable_Area3_Click(object sender, EventArgs e)
        {

        }
    }
}
