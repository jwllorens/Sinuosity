using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;


namespace Sinuosity.Forms
{
    using Sinuosity.Common;
    using Sinuosity.Forms.User_Controls;
    using System.Globalization;
    using System.Windows.Input;
    using System.Windows.Forms;


    public partial class EditorMenu : Form
    {
        private System.Windows.Forms.Timer UpdateTimer;
        private UserControl CurrentUserControl;
        public EditorMenu()
        {
            FormClosed += Form_FormClosed;
            InitializeComponent();
            RebindTreeView();
            // Initialize and start timer
            UpdateTimer = new System.Windows.Forms.Timer
            {
                Interval = 60000 // 1 minute in milliseconds
            };
            UpdateTimer.Tick += UpdateTimer_Tick;
            UpdateTimer.Start();
        }

        private void ProjectMenu_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((ProjectDataTreeView.SelectedNode != null) && (ProjectManager.Project != null))
                {
                    if (!string.IsNullOrEmpty((String)ProjectDataTreeView.SelectedNode.Tag))
                        ProjectManager.Project.DeleteNode(ProjectDataTreeView.SelectedNode.Tag as string);
                }
            }
        }

        public void UpdateProjectHeader()
        {
            if (ProjectManager.Project != null)
            {
                string projectNameString = ProjectManager.Project.GetID("");
                string versionString = ProjectManager.Project.GetAttribute("version", "");
                string filePathString = ProjectManager.Project.GetAttribute("filePath", "");
                string lastSavedString = ProjectManager.Project.GetAttribute("timeStamp", "");
                if (!string.IsNullOrEmpty(projectNameString))
                {
                    toolStripStatusLabel1.Text = projectNameString;
                }
                else
                {
                    toolStripStatusLabel1.Text = "No project loaded. Please create or load a project file.";
                }
                if (DateTime.TryParseExact(lastSavedString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    toolStripStatusLabel3.Visible = true;
                    TimeSpan diff = DateTime.Now - dateTime;
                    toolStripStatusLabel3.Text = "Last Saved: " + Utilities.GetTimeAgoString(diff);
                }
                else
                {
                    toolStripStatusLabel3.Visible = false;
                }
                if (!string.IsNullOrEmpty(versionString))
                {
                    toolStripStatusLabel2.Visible = true;
                    toolStripStatusLabel2.Text = "Version: " + versionString;
                }
                else
                {
                    toolStripStatusLabel2.Visible = false;
                    toolStripStatusLabel2.Text = "";
                }
                if (!string.IsNullOrEmpty(filePathString))
                {
                    toolStripStatusLabel4.Text = filePathString;
                }
                else
                {
                    toolStripStatusLabel4.Text = "";
                }
            }
        }

        private void UpdateEditorPanel(string nodeClass, string nodePath)
        {
            EditorPanel.Panel2.Controls.Clear(); // Clear current UI
            switch (nodeClass?.ToLower() ?? "unknown")
            {
                case "project":
                    var projectEditor = new ProjectEditor(ProjectDataTreeView, "");
                    CurrentUserControl = projectEditor;
                    CurrentUserControl.Dock = DockStyle.None;
                    EditorPanel.Panel2.Controls.Add(CurrentUserControl);
                    break;
                case "stream":
                    var streamEditor = new StreamEditor(ProjectDataTreeView, nodePath);
                    CurrentUserControl = streamEditor;
                    CurrentUserControl.Dock = DockStyle.None;
                    EditorPanel.Panel2.Controls.Add(CurrentUserControl);
                    break;
                case "reach":
                    var reachEditor = new ReachEditor(ProjectDataTreeView, nodePath);
                    CurrentUserControl = reachEditor;
                    CurrentUserControl.Dock = DockStyle.None;
                    EditorPanel.Panel2.Controls.Add(CurrentUserControl);
                    break;
                default:
                    var label = new Label
                    {
                        Text = "No editor available for class: " + nodeClass,
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    };
                    EditorPanel.Panel2.Controls.Add(label);
                    break;
            }
        }
        private void ProjectDataTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag is string nodePath && ProjectManager.Project != null)
            {
                string nodeClass = ProjectManager.Project.GetAttribute("formClass", nodePath);
                UpdateEditorPanel(nodeClass, nodePath);
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateProjectHeader(); // Update label every minute
        }
        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            if (ProjectManager.NewProject())
                RebindTreeView();
        }
        private void btn_OpenProject_Click(object sender, EventArgs e)
        {
            if (ProjectManager.OpenProject())
                RebindTreeView();
        }
        private void btn_SaveProject_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProject();
            UpdateProjectHeader();
        }
        private void btn_SaveProjectAs_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProjectAs();
            UpdateProjectHeader();
        }
        private void RebindTreeView()
        {
            if (ProjectManager.Project != null)
            {
                UpdateProjectHeader();
                if (!ProjectManager.Project.treeViewInitialized)
                    ProjectManager.Project.InitializeTreeView(ProjectDataTreeView, "formClass");
                ProjectManager.Project.UpdateTreeView();
                ProjectDataTreeView.SelectedNode = ProjectDataTreeView.Nodes[0];
                TreeViewEventArgs args = new TreeViewEventArgs(ProjectDataTreeView.Nodes[0]);
                ProjectDataTreeView_AfterSelect(this, args);
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
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

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.Project.DisposeTreeView();
            // Perform any cleanup or save operations here
        }
    }
}
