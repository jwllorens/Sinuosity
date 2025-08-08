using System.Runtime.Versioning;
using System.Windows.Forms;
using System.Drawing;

namespace Sinuosity.Forms
{
    partial class EditorMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProjectDataTreeView = new System.Windows.Forms.TreeView();
            this.EditorPanel = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btn_Configuration = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn_Save = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn_SaveAs = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPanel)).BeginInit();
            this.EditorPanel.Panel1.SuspendLayout();
            this.EditorPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectDataTreeView
            // 
            this.ProjectDataTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectDataTreeView.Location = new System.Drawing.Point(0, 0);
            this.ProjectDataTreeView.Name = "ProjectDataTreeView";
            this.ProjectDataTreeView.Size = new System.Drawing.Size(257, 551);
            this.ProjectDataTreeView.TabIndex = 0;
            this.ProjectDataTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProjectDataTreeView_AfterSelect);
            // 
            // EditorPanel
            // 
            this.EditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.EditorPanel.IsSplitterFixed = true;
            this.EditorPanel.Location = new System.Drawing.Point(0, 0);
            this.EditorPanel.Name = "EditorPanel";
            // 
            // EditorPanel.Panel1
            // 
            this.EditorPanel.Panel1.Controls.Add(this.ProjectDataTreeView);
            // 
            // EditorPanel.Panel2
            // 
            this.EditorPanel.Panel2.AutoScroll = true;
            this.EditorPanel.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 43);
            this.EditorPanel.Size = new System.Drawing.Size(733, 551);
            this.EditorPanel.SplitterDistance = 257;
            this.EditorPanel.TabIndex = 33;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Configuration,
            this.btn_Save,
            this.btn_SaveAs,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(733, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btn_Configuration
            // 
            this.btn_Configuration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Configuration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Configuration.Name = "btn_Configuration";
            this.btn_Configuration.ShowDropDownArrow = false;
            this.btn_Configuration.Size = new System.Drawing.Size(4, 20);
            this.btn_Configuration.Text = "toolStripDropDownButton1";
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.ShowDropDownArrow = false;
            this.btn_Save.Size = new System.Drawing.Size(4, 20);
            this.btn_Save.Text = "toolStripDropDownButton2";
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.ShowDropDownArrow = false;
            this.btn_SaveAs.Size = new System.Drawing.Size(4, 20);
            this.btn_SaveAs.Text = "toolStripDropDownButton3";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(319, 17);
            this.toolStripStatusLabel1.Text = "No project loaded.  Please open or create a new project file.";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // EditorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 573);
            this.Controls.Add(this.EditorPanel);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(242, 39);
            this.Name = "EditorMenu";
            this.Text = "Sinuosity - Stream Design Tools";
            this.EditorPanel.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPanel)).EndInit();
            this.EditorPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView ProjectDataTreeView;
        private System.Windows.Forms.SplitContainer EditorPanel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripDropDownButton btn_Save;
        private ToolStripDropDownButton btn_SaveAs;
        private ToolStripDropDownButton btn_Configuration;
    }
}