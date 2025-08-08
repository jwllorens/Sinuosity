using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Sinuosity.Common;
using SinuosityCore.Properties;

namespace Sinuosity.Forms
{
    public partial class GeopropertyConfiguration : Form
    {

        private IReadOnlyDictionary<TextBox, string> ConfigMap;

        public GeopropertyConfiguration()
        {
            InitializeComponent();

            ConfigMap = new Dictionary<TextBox, string>
            {
                {tb_FP1, Resources.Config_ShapeFile_Path_State},
                {tb_FN1, Resources.Config_ShapeFile_Field_State},
                {tb_FP2, Resources.Config_ShapeFile_Path_County},
                {tb_FN2, Resources.Config_ShapeFile_Field_County},
                {tb_FP3, Resources.Config_ShapeFile_Path_L4Ecoregion},
                {tb_FN3, Resources.Config_ShapeFile_Field_L4Ecoregion},
                {tb_FP4, Resources.Config_ShapeFile_Path_L3Ecoregion},
                {tb_FN4, Resources.Config_ShapeFile_Field_L3Ecoregion},
                {tb_FP5, Resources.Config_ShapeFile_Path_EcoregionCode},
                {tb_FN5, Resources.Config_ShapeFile_Field_EcoregionCode},
                {tb_FP6, Resources.Config_ShapeFile_Path_HUCWatershedName},
                {tb_FN6, Resources.Config_ShapeFile_Field_HUCWatershedName},
                {tb_FP7, Resources.Config_ShapeFile_Path_HUCWatershedCode},
                {tb_FN7, Resources.Config_ShapeFile_Field_HUCWatershedCode},
            };

            foreach (var kvp in ConfigMap)
            {
                kvp.Key.Text = Convert.ToString(ProjectManager.Configuration.GetValue(kvp.Value));
            }


        }

        private void btn_Path_State_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP1.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project state.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP1.Text = fileName;
            }
        }

        private void btn_Path_County_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP2.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project county.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP2.Text = fileName;
            }
        }

        private void btn_Path_L4ERName_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP3.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project level IV ecoregion name.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP3.Text = fileName;
            }
        }

        private void btn_Path_L3ERName_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP4.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project level III ecoregion name.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP4.Text = fileName;
            }
        }

        private void btn_Path_ERCode_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP5.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project ecoregion code.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP5.Text = fileName;
            }
        }

        private void btn_Path_HUCWatershedName_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP6.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project HUC8 watershed name.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP6.Text = fileName;
            }
        }

        private void btn_Path_HUCWatershedCode_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FP7.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select shape file to identify project HUC8 watershed code.", "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FP7.Text = fileName;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // This will return true when checked
            Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            foreach (var kvp in ConfigMap)
            {
                ProjectManager.Configuration?.SetValue(kvp.Key.Text, kvp.Value);
            }
            bool? saveSuccess = ProjectManager.Configuration?.SilentSave();
            if (saveSuccess != null)
            {
                if (saveSuccess == true)
                {
                    MessageBox.Show("Configuration settings saved successfully.");
                    DialogResult = DialogResult.OK; // This will return true when checked
                    Close();
                }
                else
                {
                    MessageBox.Show("An error occurred saving configuration settings.");
                }
            }
        }

        private void customGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
