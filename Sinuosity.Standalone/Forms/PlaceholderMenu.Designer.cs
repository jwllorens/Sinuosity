using System.Drawing;
using System.Windows.Forms;

namespace Sinuosity.Forms
{
    partial class PlaceholderMenu
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
            btn_Save = new Button();
            btn_Open = new Button();
            btn_New = new Button();
            btn_SaveAs = new Button();
            button1 = new Button();
            btn_Configuration = new Button();
            btn_Editor = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Save.Location = new Point(86, 12);
            btn_Save.Margin = new Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(24, 24);
            btn_Save.TabIndex = 29;
            btn_Save.TabStop = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_SaveProject_Click;
            // 
            // btn_Open
            // 
            btn_Open.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Open.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Open.Location = new Point(49, 12);
            btn_Open.Margin = new Padding(4, 3, 4, 3);
            btn_Open.Name = "btn_Open";
            btn_Open.Size = new Size(24, 24);
            btn_Open.TabIndex = 30;
            btn_Open.TabStop = false;
            btn_Open.UseVisualStyleBackColor = true;
            btn_Open.Click += btn_OpenProject_Click;
            // 
            // btn_New
            // 
            btn_New.BackgroundImageLayout = ImageLayout.Stretch;
            btn_New.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_New.Location = new Point(13, 12);
            btn_New.Margin = new Padding(4, 3, 4, 3);
            btn_New.Name = "btn_New";
            btn_New.Size = new Size(24, 24);
            btn_New.TabIndex = 28;
            btn_New.UseVisualStyleBackColor = true;
            btn_New.Click += btn_NewProject_Click;
            // 
            // btn_SaveAs
            // 
            btn_SaveAs.BackgroundImageLayout = ImageLayout.Stretch;
            btn_SaveAs.Location = new Point(123, 12);
            btn_SaveAs.Margin = new Padding(4, 3, 4, 3);
            btn_SaveAs.Name = "btn_SaveAs";
            btn_SaveAs.Size = new Size(24, 24);
            btn_SaveAs.TabIndex = 31;
            btn_SaveAs.TabStop = false;
            btn_SaveAs.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(471, 12);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(162, 29);
            button1.TabIndex = 32;
            button1.TabStop = false;
            button1.Text = "Project Data Cache Report";
            button1.UseVisualStyleBackColor = true;
            // 
            // btn_Configuration
            // 
            btn_Configuration.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Configuration.Location = new Point(160, 12);
            btn_Configuration.Margin = new Padding(4, 3, 4, 3);
            btn_Configuration.Name = "btn_Configuration";
            btn_Configuration.Size = new Size(24, 24);
            btn_Configuration.TabIndex = 33;
            btn_Configuration.TabStop = false;
            btn_Configuration.UseVisualStyleBackColor = true;
            btn_Configuration.Click += btn_Configuration_Click;
            // 
            // btn_Editor
            // 
            btn_Editor.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Editor.Location = new Point(33, 108);
            btn_Editor.Margin = new Padding(4, 3, 4, 3);
            btn_Editor.Name = "btn_Editor";
            btn_Editor.Size = new Size(60, 60);
            btn_Editor.TabIndex = 34;
            btn_Editor.TabStop = false;
            btn_Editor.UseVisualStyleBackColor = true;
            btn_Editor.Click += btn_Editor_Click;
            // 
            // button2
            // 
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(101, 108);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(60, 60);
            button2.TabIndex = 35;
            button2.TabStop = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PlaceholderMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 462);
            Controls.Add(button2);
            Controls.Add(btn_Editor);
            Controls.Add(btn_Configuration);
            Controls.Add(button1);
            Controls.Add(btn_SaveAs);
            Controls.Add(btn_Save);
            Controls.Add(btn_Open);
            Controls.Add(btn_New);
            Name = "PlaceholderMenu";
            Text = "Program";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Save;
        private Button btn_Open;
        private Button btn_New;
        private Button btn_SaveAs;
        private Button button1;
        private Button btn_Configuration;
        private Button btn_Editor;
        private Button button2;
    }
}