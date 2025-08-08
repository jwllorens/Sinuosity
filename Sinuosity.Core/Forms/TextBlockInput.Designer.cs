using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Drawing;

namespace Sinuosity.Forms
{
    partial class TextBlockInput
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tb_Notes = new System.Windows.Forms.TextBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Accept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tb_Notes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.Btn_Accept);
            this.splitContainer1.Size = new System.Drawing.Size(507, 420);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 80;
            // 
            // tb_Notes
            // 
            this.tb_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Notes.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_Notes.Location = new System.Drawing.Point(3, 9);
            this.tb_Notes.Multiline = true;
            this.tb_Notes.Name = "tb_Notes";
            this.tb_Notes.Size = new System.Drawing.Size(502, 373);
            this.tb_Notes.TabIndex = 30;
            this.tb_Notes.Tag = "";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.Location = new System.Drawing.Point(439, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(64, 20);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Btn_Accept
            // 
            this.Btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Accept.Location = new System.Drawing.Point(369, 3);
            this.Btn_Accept.Name = "Btn_Accept";
            this.Btn_Accept.Size = new System.Drawing.Size(64, 20);
            this.Btn_Accept.TabIndex = 0;
            this.Btn_Accept.Text = "Accept";
            this.Btn_Accept.UseVisualStyleBackColor = true;
            // 
            // TextBlockInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 420);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextBlockInput";
            this.Text = "Enter Plain Text";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer splitContainer1;
        private Button Btn_Cancel;
        private Button Btn_Accept;
        private TextBox tb_Notes;
    }
}