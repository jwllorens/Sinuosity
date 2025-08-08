using System;
using System.Windows.Forms;
using Sinuosity;

namespace Sinuosity.Forms
{
    public partial class PlaceholderMenu : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public PlaceholderMenu()
        {
            AllocConsole(); // Opens a console window
            InitializeComponent();
        }

        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            ProjectManager.NewProject();
        }
        private void btn_OpenProject_Click(object sender, EventArgs e)
        {
            ProjectManager.OpenProject();
        }

        private void btn_SaveProject_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProject();
        }
        private void btn_SaveProjectAs_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProjectAs();
        }
        private void btn_Editor_Click(object sender, EventArgs e)
        {
            using (Sinuosity.Forms.EditorMenu form = new Sinuosity.Forms.EditorMenu())
            {
                DialogResult result = form.ShowDialog();

                // Code to run after Form1 closes
                if (result == DialogResult.OK)
                {
                    // Example: Update a label or run some logic
                }
            }
        }

        private void btn_Configuration_Click(object sender, EventArgs e)
        {
            using (Sinuosity.Forms.GeopropertyConfiguration form = new Sinuosity.Forms.GeopropertyConfiguration())
            {
                DialogResult result = form.ShowDialog();

                // Code to run after Form1 closes
                if (result == DialogResult.OK)
                {
                    // Example: Update a label or run some logic
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Sinuosity.Forms.ReferenceReachBrowser form = new Sinuosity.Forms.ReferenceReachBrowser())
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
