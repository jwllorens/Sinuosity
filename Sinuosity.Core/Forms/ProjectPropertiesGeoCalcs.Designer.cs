using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sinuosity.Forms
{
    partial class ProjectPropertiesGeoCalcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.dispose();
        //    }
        //    base.dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPropertiesGeoCalcs));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_OutputInfo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tb_Lon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Lat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb_CalcProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lbl_PBStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_StartCalculations = new System.Windows.Forms.ToolStripButton();
            this.btn_Accept = new System.Windows.Forms.ToolStripButton();
            this.btn_Reject = new System.Windows.Forms.ToolStripButton();
            this.btn_Settings = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_OutputInfo);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 286);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculation Output:";
            // 
            // tb_OutputInfo
            // 
            this.tb_OutputInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_OutputInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OutputInfo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_OutputInfo.Location = new System.Drawing.Point(3, 18);
            this.tb_OutputInfo.Multiline = true;
            this.tb_OutputInfo.Name = "tb_OutputInfo";
            this.tb_OutputInfo.ReadOnly = true;
            this.tb_OutputInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_OutputInfo.Size = new System.Drawing.Size(433, 265);
            this.tb_OutputInfo.TabIndex = 28;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.tb_Lon);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tb_Lat);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 63);
            this.groupBox3.TabIndex = 146;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Project Location";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.textBox3.Location = new System.Drawing.Point(207, 18);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(225, 41);
            this.textBox3.TabIndex = 147;
            this.textBox3.Text = "Latitude and Longitude are assumed to be in decimal degrees, WGS84.";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Lon
            // 
            this.tb_Lon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Lon.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_Lon.Location = new System.Drawing.Point(72, 39);
            this.tb_Lon.Margin = new System.Windows.Forms.Padding(1);
            this.tb_Lon.Name = "tb_Lon";
            this.tb_Lon.ReadOnly = true;
            this.tb_Lon.Size = new System.Drawing.Size(134, 20);
            this.tb_Lon.TabIndex = 146;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 135;
            this.label3.Text = "Latitude:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Lat
            // 
            this.tb_Lat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Lat.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_Lat.Location = new System.Drawing.Point(72, 18);
            this.tb_Lat.Margin = new System.Windows.Forms.Padding(1);
            this.tb_Lat.Name = "tb_Lat";
            this.tb_Lat.ReadOnly = true;
            this.tb_Lat.Size = new System.Drawing.Size(134, 20);
            this.tb_Lat.TabIndex = 145;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 134;
            this.label8.Text = "Longitude:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb_CalcProgress,
            this.lbl_PBStatus,
            this.spacerLabel,
            this.btn_StartCalculations,
            this.btn_Accept,
            this.btn_Reject,
            this.btn_Settings});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(449, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 147;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pb_CalcProgress
            // 
            this.pb_CalcProgress.AutoSize = false;
            this.pb_CalcProgress.MarqueeAnimationSpeed = 0;
            this.pb_CalcProgress.Name = "pb_CalcProgress";
            this.pb_CalcProgress.Size = new System.Drawing.Size(170, 16);
            // 
            // lbl_PBStatus
            // 
            this.lbl_PBStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PBStatus.Name = "lbl_PBStatus";
            this.lbl_PBStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // spacerLabel
            // 
            this.spacerLabel.Name = "spacerLabel";
            this.spacerLabel.Size = new System.Drawing.Size(16, 17);
            this.spacerLabel.Spring = true;
            // 
            // btn_StartCalculations
            // 
            this.btn_StartCalculations.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_StartCalculations.Name = "btn_StartCalculations";
            this.btn_StartCalculations.Size = new System.Drawing.Size(103, 20);
            this.btn_StartCalculations.Text = "Start Calculations";
            this.btn_StartCalculations.Click += new System.EventHandler(this.btn_StartCalculations_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(48, 20);
            this.btn_Accept.Text = "Accept";
            this.btn_Accept.Visible = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Reject
            // 
            this.btn_Reject.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Reject.Name = "btn_Reject";
            this.btn_Reject.Size = new System.Drawing.Size(43, 20);
            this.btn_Reject.Text = "Reject";
            this.btn_Reject.Visible = false;
            this.btn_Reject.Click += new System.EventHandler(this.btn_Reject_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(23, 20);
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // ProjectPropertiesGeoCalcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(449, 374);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectPropertiesGeoCalcs";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Calculating Project Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GroupBox groupBox1;
        private TextBox tb_OutputInfo;
        private GroupBox groupBox3;
        private TextBox textBox3;
        private TextBox tb_Lon;
        private Label label3;
        private TextBox tb_Lat;
        private Label label8;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar pb_CalcProgress;
        private ToolStripStatusLabel lbl_PBStatus;
        private ToolStripStatusLabel spacerLabel;
        private ToolStripButton btn_StartCalculations;
        private ToolStripButton btn_Accept;
        private ToolStripButton btn_Reject;
        private ToolStripButton btn_Settings;
    }
}
#endregion