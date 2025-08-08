using System.Windows.Forms;
using System.Drawing;
namespace Sinuosity.Forms
{
    partial class GeopropertyConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeopropertyConfiguration));
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.customGroupBox1 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.btn_Path_HUCWatershedCode = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Path_ERCode = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Path_L3ERName = new System.Windows.Forms.Button();
            this.tb_FN5 = new System.Windows.Forms.TextBox();
            this.btn_Path_L4ERName = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Path_HUCWatershedName = new System.Windows.Forms.Button();
            this.tb_FN4 = new System.Windows.Forms.TextBox();
            this.btn_Path_County = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_FP1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_FN7 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_FN1 = new System.Windows.Forms.TextBox();
            this.tb_FP4 = new System.Windows.Forms.TextBox();
            this.btn_Path_State = new System.Windows.Forms.Button();
            this.tb_FP5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_FN3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_FP2 = new System.Windows.Forms.TextBox();
            this.tb_FP3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_FN2 = new System.Windows.Forms.TextBox();
            this.tb_FP7 = new System.Windows.Forms.TextBox();
            this.tb_FP6 = new System.Windows.Forms.TextBox();
            this.tb_FN6 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.customGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(338, 200);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(64, 20);
            this.Btn_Save.TabIndex = 148;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(404, 200);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(64, 20);
            this.Btn_Cancel.TabIndex = 149;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.customGroupBox1.Controls.Add(this.btn_Path_HUCWatershedCode);
            this.customGroupBox1.Controls.Add(this.label6);
            this.customGroupBox1.Controls.Add(this.btn_Path_ERCode);
            this.customGroupBox1.Controls.Add(this.label11);
            this.customGroupBox1.Controls.Add(this.btn_Path_L3ERName);
            this.customGroupBox1.Controls.Add(this.tb_FN5);
            this.customGroupBox1.Controls.Add(this.btn_Path_L4ERName);
            this.customGroupBox1.Controls.Add(this.label7);
            this.customGroupBox1.Controls.Add(this.btn_Path_HUCWatershedName);
            this.customGroupBox1.Controls.Add(this.tb_FN4);
            this.customGroupBox1.Controls.Add(this.btn_Path_County);
            this.customGroupBox1.Controls.Add(this.label17);
            this.customGroupBox1.Controls.Add(this.label21);
            this.customGroupBox1.Controls.Add(this.label15);
            this.customGroupBox1.Controls.Add(this.label18);
            this.customGroupBox1.Controls.Add(this.tb_FP1);
            this.customGroupBox1.Controls.Add(this.label14);
            this.customGroupBox1.Controls.Add(this.tb_FN7);
            this.customGroupBox1.Controls.Add(this.label13);
            this.customGroupBox1.Controls.Add(this.label2);
            this.customGroupBox1.Controls.Add(this.label12);
            this.customGroupBox1.Controls.Add(this.label16);
            this.customGroupBox1.Controls.Add(this.label10);
            this.customGroupBox1.Controls.Add(this.tb_FN1);
            this.customGroupBox1.Controls.Add(this.tb_FP4);
            this.customGroupBox1.Controls.Add(this.btn_Path_State);
            this.customGroupBox1.Controls.Add(this.tb_FP5);
            this.customGroupBox1.Controls.Add(this.label9);
            this.customGroupBox1.Controls.Add(this.tb_FN3);
            this.customGroupBox1.Controls.Add(this.label5);
            this.customGroupBox1.Controls.Add(this.label19);
            this.customGroupBox1.Controls.Add(this.tb_FP2);
            this.customGroupBox1.Controls.Add(this.tb_FP3);
            this.customGroupBox1.Controls.Add(this.label1);
            this.customGroupBox1.Controls.Add(this.tb_FN2);
            this.customGroupBox1.Controls.Add(this.tb_FP7);
            this.customGroupBox1.Controls.Add(this.tb_FP6);
            this.customGroupBox1.Controls.Add(this.tb_FN6);
            this.customGroupBox1.Controls.Add(this.label20);
            this.customGroupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customGroupBox1.Location = new System.Drawing.Point(10, 10);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(458, 188);
            this.customGroupBox1.TabIndex = 147;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "Geographic Properties - Calculation Shape Files";
            this.customGroupBox1.Enter += new System.EventHandler(this.customGroupBox1_Enter);
            // 
            // btn_Path_HUCWatershedCode
            // 
            this.btn_Path_HUCWatershedCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_HUCWatershedCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_HUCWatershedCode.BackgroundImage")));
            this.btn_Path_HUCWatershedCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_HUCWatershedCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_HUCWatershedCode.Location = new System.Drawing.Point(139, 167);
            this.btn_Path_HUCWatershedCode.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_HUCWatershedCode.Name = "btn_Path_HUCWatershedCode";
            this.btn_Path_HUCWatershedCode.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_HUCWatershedCode.TabIndex = 142;
            this.btn_Path_HUCWatershedCode.TabStop = false;
            this.btn_Path_HUCWatershedCode.UseVisualStyleBackColor = false;
            this.btn_Path_HUCWatershedCode.Click += new System.EventHandler(this.btn_Path_HUCWatershedCode_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 144;
            this.label6.Text = "Property";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Path_ERCode
            // 
            this.btn_Path_ERCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_ERCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_ERCode.BackgroundImage")));
            this.btn_Path_ERCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_ERCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_ERCode.Location = new System.Drawing.Point(139, 125);
            this.btn_Path_ERCode.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_ERCode.Name = "btn_Path_ERCode";
            this.btn_Path_ERCode.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_ERCode.TabIndex = 140;
            this.btn_Path_ERCode.TabStop = false;
            this.btn_Path_ERCode.UseVisualStyleBackColor = false;
            this.btn_Path_ERCode.Click += new System.EventHandler(this.btn_Path_ERCode_Click);
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 20);
            this.label11.TabIndex = 129;
            this.label11.Text = "Ecoregion Code:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Path_L3ERName
            // 
            this.btn_Path_L3ERName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_L3ERName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_L3ERName.BackgroundImage")));
            this.btn_Path_L3ERName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_L3ERName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_L3ERName.Location = new System.Drawing.Point(139, 104);
            this.btn_Path_L3ERName.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_L3ERName.Name = "btn_Path_L3ERName";
            this.btn_Path_L3ERName.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_L3ERName.TabIndex = 139;
            this.btn_Path_L3ERName.TabStop = false;
            this.btn_Path_L3ERName.UseVisualStyleBackColor = false;
            this.btn_Path_L3ERName.Click += new System.EventHandler(this.btn_Path_L3ERName_Click);
            // 
            // tb_FN5
            // 
            this.tb_FN5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN5.Location = new System.Drawing.Point(385, 123);
            this.tb_FN5.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN5.Name = "tb_FN5";
            this.tb_FN5.Size = new System.Drawing.Size(70, 20);
            this.tb_FN5.TabIndex = 10;
            this.tb_FN5.Text = "US_L4CODE";
            // 
            // btn_Path_L4ERName
            // 
            this.btn_Path_L4ERName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_L4ERName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_L4ERName.BackgroundImage")));
            this.btn_Path_L4ERName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_L4ERName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_L4ERName.Location = new System.Drawing.Point(139, 83);
            this.btn_Path_L4ERName.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_L4ERName.Name = "btn_Path_L4ERName";
            this.btn_Path_L4ERName.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_L4ERName.TabIndex = 138;
            this.btn_Path_L4ERName.TabStop = false;
            this.btn_Path_L4ERName.UseVisualStyleBackColor = false;
            this.btn_Path_L4ERName.Click += new System.EventHandler(this.btn_Path_L4ERName_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 144);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 128;
            this.label7.Text = "HUC Watershed Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Path_HUCWatershedName
            // 
            this.btn_Path_HUCWatershedName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_HUCWatershedName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_HUCWatershedName.BackgroundImage")));
            this.btn_Path_HUCWatershedName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_HUCWatershedName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_HUCWatershedName.Location = new System.Drawing.Point(139, 146);
            this.btn_Path_HUCWatershedName.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_HUCWatershedName.Name = "btn_Path_HUCWatershedName";
            this.btn_Path_HUCWatershedName.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_HUCWatershedName.TabIndex = 141;
            this.btn_Path_HUCWatershedName.TabStop = false;
            this.btn_Path_HUCWatershedName.UseVisualStyleBackColor = false;
            this.btn_Path_HUCWatershedName.Click += new System.EventHandler(this.btn_Path_HUCWatershedCode_Click);
            // 
            // tb_FN4
            // 
            this.tb_FN4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN4.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN4.Location = new System.Drawing.Point(385, 102);
            this.tb_FN4.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN4.Name = "tb_FN4";
            this.tb_FN4.Size = new System.Drawing.Size(70, 20);
            this.tb_FN4.TabIndex = 8;
            this.tb_FN4.Text = "US_L3NAME";
            // 
            // btn_Path_County
            // 
            this.btn_Path_County.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_County.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_County.BackgroundImage")));
            this.btn_Path_County.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_County.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_County.Location = new System.Drawing.Point(139, 62);
            this.btn_Path_County.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Path_County.Name = "btn_Path_County";
            this.btn_Path_County.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_County.TabIndex = 137;
            this.btn_Path_County.TabStop = false;
            this.btn_Path_County.UseVisualStyleBackColor = false;
            this.btn_Path_County.Click += new System.EventHandler(this.btn_Path_County_Click);
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 165);
            this.label17.Margin = new System.Windows.Forms.Padding(1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 20);
            this.label17.TabIndex = 127;
            this.label17.Text = "HUC Watershed Code:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(137, 165);
            this.label21.Margin = new System.Windows.Forms.Padding(1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 20);
            this.label21.TabIndex = 151;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 102);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 20);
            this.label15.TabIndex = 130;
            this.label15.Text = "L3 Ecoregion Name:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(137, 144);
            this.label18.Margin = new System.Windows.Forms.Padding(1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 20);
            this.label18.TabIndex = 150;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FP1
            // 
            this.tb_FP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP1.Location = new System.Drawing.Point(158, 39);
            this.tb_FP1.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP1.Name = "tb_FP1";
            this.tb_FP1.Size = new System.Drawing.Size(226, 20);
            this.tb_FP1.TabIndex = 1;
            this.tb_FP1.Text = "C:\\Users\\john\\Documents\\Map Shapes\\States.shp";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(137, 123);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 20);
            this.label14.TabIndex = 149;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FN7
            // 
            this.tb_FN7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN7.Location = new System.Drawing.Point(385, 165);
            this.tb_FN7.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN7.Name = "tb_FN7";
            this.tb_FN7.Size = new System.Drawing.Size(70, 20);
            this.tb_FN7.TabIndex = 14;
            this.tb_FN7.Text = "HUC8";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(137, 102);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 148;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.Location = new System.Drawing.Point(158, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "File Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(137, 81);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 20);
            this.label12.TabIndex = 147;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 81);
            this.label16.Margin = new System.Windows.Forms.Padding(1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 20);
            this.label16.TabIndex = 131;
            this.label16.Text = "L4 Ecoregion Name:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(137, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 146;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FN1
            // 
            this.tb_FN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN1.Location = new System.Drawing.Point(385, 39);
            this.tb_FN1.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN1.Name = "tb_FN1";
            this.tb_FN1.Size = new System.Drawing.Size(70, 20);
            this.tb_FN1.TabIndex = 2;
            this.tb_FN1.Text = "NAME";
            // 
            // tb_FP4
            // 
            this.tb_FP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP4.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP4.Location = new System.Drawing.Point(158, 102);
            this.tb_FP4.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP4.Name = "tb_FP4";
            this.tb_FP4.Size = new System.Drawing.Size(226, 20);
            this.tb_FP4.TabIndex = 7;
            this.tb_FP4.Text = "C:\\Users\\john\\Documents\\Map Shapes\\EcoL4.shp";
            // 
            // btn_Path_State
            // 
            this.btn_Path_State.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_State.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_State.BackgroundImage")));
            this.btn_Path_State.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_State.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_State.Location = new System.Drawing.Point(139, 41);
            this.btn_Path_State.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Path_State.Name = "btn_Path_State";
            this.btn_Path_State.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_State.TabIndex = 73;
            this.btn_Path_State.TabStop = false;
            this.btn_Path_State.UseVisualStyleBackColor = false;
            this.btn_Path_State.Click += new System.EventHandler(this.btn_Path_State_Click);
            // 
            // tb_FP5
            // 
            this.tb_FP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP5.Location = new System.Drawing.Point(158, 123);
            this.tb_FP5.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP5.Name = "tb_FP5";
            this.tb_FP5.Size = new System.Drawing.Size(226, 20);
            this.tb_FP5.TabIndex = 9;
            this.tb_FP5.Text = "C:\\Users\\john\\Documents\\Map Shapes\\EcoL4.shp";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(137, 39);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 145;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FN3
            // 
            this.tb_FN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN3.Location = new System.Drawing.Point(385, 81);
            this.tb_FN3.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN3.Name = "tb_FN3";
            this.tb_FN3.Size = new System.Drawing.Size(70, 20);
            this.tb_FN3.TabIndex = 6;
            this.tb_FN3.Text = "US_L4NAME";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 143;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 60);
            this.label19.Margin = new System.Windows.Forms.Padding(1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 20);
            this.label19.TabIndex = 132;
            this.label19.Text = "County:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_FP2
            // 
            this.tb_FP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP2.Location = new System.Drawing.Point(158, 60);
            this.tb_FP2.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP2.Name = "tb_FP2";
            this.tb_FP2.Size = new System.Drawing.Size(226, 20);
            this.tb_FP2.TabIndex = 3;
            this.tb_FP2.Text = "C:\\Users\\john\\Documents\\Map Shapes\\Counties.shp";
            // 
            // tb_FP3
            // 
            this.tb_FP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP3.Location = new System.Drawing.Point(158, 81);
            this.tb_FP3.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP3.Name = "tb_FP3";
            this.tb_FP3.Size = new System.Drawing.Size(226, 20);
            this.tb_FP3.TabIndex = 5;
            this.tb_FP3.Text = "C:\\Users\\john\\Documents\\Map Shapes\\EcoL4.shp";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(385, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 110;
            this.label1.Text = "Field Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_FN2
            // 
            this.tb_FN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN2.Location = new System.Drawing.Point(385, 60);
            this.tb_FN2.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN2.Name = "tb_FN2";
            this.tb_FN2.Size = new System.Drawing.Size(70, 20);
            this.tb_FN2.TabIndex = 4;
            this.tb_FN2.Text = "NAME";
            // 
            // tb_FP7
            // 
            this.tb_FP7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP7.Location = new System.Drawing.Point(158, 165);
            this.tb_FP7.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP7.Name = "tb_FP7";
            this.tb_FP7.Size = new System.Drawing.Size(226, 20);
            this.tb_FP7.TabIndex = 13;
            this.tb_FP7.Text = "C:\\Users\\john\\Documents\\Map Shapes\\HUC8.shp";
            // 
            // tb_FP6
            // 
            this.tb_FP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FP6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FP6.Location = new System.Drawing.Point(158, 144);
            this.tb_FP6.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FP6.Name = "tb_FP6";
            this.tb_FP6.Size = new System.Drawing.Size(226, 20);
            this.tb_FP6.TabIndex = 11;
            this.tb_FP6.Text = "C:\\Users\\john\\Documents\\Map Shapes\\HUC8.shp";
            // 
            // tb_FN6
            // 
            this.tb_FN6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FN6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FN6.Location = new System.Drawing.Point(385, 144);
            this.tb_FN6.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FN6.Name = "tb_FN6";
            this.tb_FN6.Size = new System.Drawing.Size(70, 20);
            this.tb_FN6.TabIndex = 12;
            this.tb_FN6.Text = "NAME";
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 39);
            this.label20.Margin = new System.Windows.Forms.Padding(1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 20);
            this.label20.TabIndex = 133;
            this.label20.Text = "State:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GeopropertyConfiguration
            // 
            this.AcceptButton = this.Btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_Cancel;
            this.ClientSize = new System.Drawing.Size(479, 223);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.customGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(495, 262);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 262);
            this.Name = "GeopropertyConfiguration";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configuration";
            this.TopMost = true;
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_Path_HUCWatershedCode;
        private Button btn_Path_ERCode;
        private Button btn_Path_L3ERName;
        private Button btn_Path_L4ERName;
        private Button btn_Path_HUCWatershedName;
        private Button btn_Path_County;
        private Label label21;
        private Label label18;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label10;
        private Label label6;
        private Button btn_Path_State;
        private Label label9;
        private Label label5;
        private TextBox tb_FP2;
        private Label label1;
        private TextBox tb_FP7;
        private TextBox tb_FN6;
        private Label label20;
        private TextBox tb_FP6;
        private TextBox tb_FN2;
        private TextBox tb_FP3;
        private Label label19;
        private TextBox tb_FN3;
        private TextBox tb_FP5;
        private TextBox tb_FP4;
        private TextBox tb_FN1;
        private Label label16;
        private Label label2;
        private TextBox tb_FN7;
        private TextBox tb_FP1;
        private Label label15;
        private Label label17;
        private TextBox tb_FN4;
        private Label label7;
        private TextBox tb_FN5;
        private Label label11;
        private Custom_Controls.GroupBox_Bordered customGroupBox1;
        private Button Btn_Save;
        private Button Btn_Cancel;
    }
}