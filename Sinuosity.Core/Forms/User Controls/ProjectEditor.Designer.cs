using System.Windows.Forms;
using System.Drawing;

namespace Sinuosity.Forms.User_Controls
{
    partial class ProjectEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditor));
            this.gb_Main = new System.Windows.Forms.GroupBox();
            this.Tb_ProjectID = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.Btn_EditNotes = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.customGroupBox1 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_GoToStream = new System.Windows.Forms.Button();
            this.btn_DeleteStream = new System.Windows.Forms.Button();
            this.lb_StreamList = new System.Windows.Forms.ListBox();
            this.btn_AddStream = new System.Windows.Forms.Button();
            this.gb_GeographicProperties = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_ProjectState = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_ProjectERCode = new System.Windows.Forms.TextBox();
            this.tb_ProjectCounty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_ProjectHUCName = new System.Windows.Forms.TextBox();
            this.tb_ProjectERL4Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ProjectHUCCode = new System.Windows.Forms.TextBox();
            this.tb_ProjectERL3Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_CalcGeoProps = new System.Windows.Forms.Button();
            this.customGroupBox2 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.tb_ProjectLat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ProjectLon = new System.Windows.Forms.TextBox();
            this.gb_Main.SuspendLayout();
            this.customGroupBox1.SuspendLayout();
            this.gb_GeographicProperties.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Main
            // 
            this.gb_Main.Controls.Add(this.customGroupBox1);
            this.gb_Main.Controls.Add(this.Tb_ProjectID);
            this.gb_Main.Controls.Add(this.gb_GeographicProperties);
            this.gb_Main.Controls.Add(this.lbl2);
            this.gb_Main.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Main.Location = new System.Drawing.Point(3, 24);
            this.gb_Main.Name = "gb_Main";
            this.gb_Main.Size = new System.Drawing.Size(487, 497);
            this.gb_Main.TabIndex = 77;
            this.gb_Main.TabStop = false;
            this.gb_Main.Text = "Project Properties: ---";
            // 
            // Tb_ProjectID
            // 
            this.Tb_ProjectID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tb_ProjectID.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Tb_ProjectID.Location = new System.Drawing.Point(87, 20);
            this.Tb_ProjectID.Margin = new System.Windows.Forms.Padding(1);
            this.Tb_ProjectID.Name = "Tb_ProjectID";
            this.Tb_ProjectID.Size = new System.Drawing.Size(395, 20);
            this.Tb_ProjectID.TabIndex = 1;
            this.Tb_ProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.Tb_ProjectID.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(5, 23);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(83, 14);
            this.lbl2.TabIndex = 64;
            this.lbl2.Text = "Project Name:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_EditNotes
            // 
            this.Btn_EditNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_EditNotes.Image = ((System.Drawing.Image)(resources.GetObject("Btn_EditNotes.Image")));
            this.Btn_EditNotes.Location = new System.Drawing.Point(466, 2);
            this.Btn_EditNotes.Name = "Btn_EditNotes";
            this.Btn_EditNotes.Size = new System.Drawing.Size(24, 24);
            this.Btn_EditNotes.TabIndex = 113;
            this.Btn_EditNotes.TabStop = false;
            this.Btn_EditNotes.Tag = "/Properties/Description";
            this.toolTip.SetToolTip(this.Btn_EditNotes, "view or edit project description");
            this.Btn_EditNotes.UseVisualStyleBackColor = true;
            this.Btn_EditNotes.Click += new System.EventHandler(this.Btn_EditNotes_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(425, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 14);
            this.label18.TabIndex = 116;
            this.label18.Text = "Notes";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.customGroupBox1.Controls.Add(this.button1);
            this.customGroupBox1.Controls.Add(this.btn_GoToStream);
            this.customGroupBox1.Controls.Add(this.btn_DeleteStream);
            this.customGroupBox1.Controls.Add(this.lb_StreamList);
            this.customGroupBox1.Controls.Add(this.btn_AddStream);
            this.customGroupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.customGroupBox1.Location = new System.Drawing.Point(380, 42);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(102, 191);
            this.customGroupBox1.TabIndex = 79;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "Streams";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(77, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 71;
            this.button1.TabStop = false;
            this.toolTip.SetToolTip(this.button1, "duplicate stream");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ListBox_CopyItem);
            // 
            // btn_GoToStream
            // 
            this.btn_GoToStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_GoToStream.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_GoToStream.BackgroundImage")));
            this.btn_GoToStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_GoToStream.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GoToStream.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_GoToStream.Location = new System.Drawing.Point(77, 165);
            this.btn_GoToStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_GoToStream.Name = "btn_GoToStream";
            this.btn_GoToStream.Size = new System.Drawing.Size(24, 24);
            this.btn_GoToStream.TabIndex = 69;
            this.btn_GoToStream.TabStop = false;
            this.toolTip.SetToolTip(this.btn_GoToStream, "edit stream");
            this.btn_GoToStream.UseVisualStyleBackColor = false;
            this.btn_GoToStream.Click += new System.EventHandler(this.ListBox_GoToItem);
            // 
            // btn_DeleteStream
            // 
            this.btn_DeleteStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DeleteStream.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteStream.BackgroundImage")));
            this.btn_DeleteStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteStream.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_DeleteStream.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_DeleteStream.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteStream.Location = new System.Drawing.Point(77, 61);
            this.btn_DeleteStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_DeleteStream.Name = "btn_DeleteStream";
            this.btn_DeleteStream.Size = new System.Drawing.Size(24, 24);
            this.btn_DeleteStream.TabIndex = 70;
            this.btn_DeleteStream.TabStop = false;
            this.toolTip.SetToolTip(this.btn_DeleteStream, "delete stream");
            this.btn_DeleteStream.UseVisualStyleBackColor = false;
            this.btn_DeleteStream.Click += new System.EventHandler(this.ListBox_DeleteItem);
            // 
            // lb_StreamList
            // 
            this.lb_StreamList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_StreamList.FormattingEnabled = true;
            this.lb_StreamList.ItemHeight = 14;
            this.lb_StreamList.Location = new System.Drawing.Point(3, 16);
            this.lb_StreamList.Margin = new System.Windows.Forms.Padding(1);
            this.lb_StreamList.Name = "lb_StreamList";
            this.lb_StreamList.Size = new System.Drawing.Size(74, 172);
            this.lb_StreamList.Sorted = true;
            this.lb_StreamList.TabIndex = 68;
            this.lb_StreamList.TabStop = false;
            this.lb_StreamList.Tag = "/Streams";
            this.lb_StreamList.Leave += new System.EventHandler(this.ListBox_Leave);
            // 
            // btn_AddStream
            // 
            this.btn_AddStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AddStream.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AddStream.BackgroundImage")));
            this.btn_AddStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddStream.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_AddStream.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_AddStream.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddStream.Location = new System.Drawing.Point(77, 15);
            this.btn_AddStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_AddStream.Name = "btn_AddStream";
            this.btn_AddStream.Size = new System.Drawing.Size(24, 24);
            this.btn_AddStream.TabIndex = 28;
            this.btn_AddStream.TabStop = false;
            this.toolTip.SetToolTip(this.btn_AddStream, "add a stream to project");
            this.btn_AddStream.UseVisualStyleBackColor = false;
            this.btn_AddStream.Click += new System.EventHandler(this.ListBox_AddItem);
            // 
            // gb_GeographicProperties
            // 
            this.gb_GeographicProperties.BorderColor = System.Drawing.Color.Black;
            this.gb_GeographicProperties.Controls.Add(this.panel1);
            this.gb_GeographicProperties.Controls.Add(this.btn_CalcGeoProps);
            this.gb_GeographicProperties.Controls.Add(this.customGroupBox2);
            this.gb_GeographicProperties.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_GeographicProperties.Location = new System.Drawing.Point(5, 42);
            this.gb_GeographicProperties.Name = "gb_GeographicProperties";
            this.gb_GeographicProperties.Size = new System.Drawing.Size(369, 191);
            this.gb_GeographicProperties.TabIndex = 77;
            this.gb_GeographicProperties.TabStop = false;
            this.gb_GeographicProperties.Text = "Geographic Properties";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_ProjectState);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tb_ProjectERCode);
            this.panel1.Controls.Add(this.tb_ProjectCounty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tb_ProjectHUCName);
            this.panel1.Controls.Add(this.tb_ProjectERL4Name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_ProjectHUCCode);
            this.panel1.Controls.Add(this.tb_ProjectERL3Name);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(5, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 108);
            this.panel1.TabIndex = 80;
            // 
            // tb_ProjectState
            // 
            this.tb_ProjectState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectState.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectState.Location = new System.Drawing.Point(260, 1);
            this.tb_ProjectState.Margin = new System.Windows.Forms.Padding(0);
            this.tb_ProjectState.Name = "tb_ProjectState";
            this.tb_ProjectState.Size = new System.Drawing.Size(96, 20);
            this.tb_ProjectState.TabIndex = 4;
            this.tb_ProjectState.Tag = "/Properties/State";
            this.tb_ProjectState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_ProjectState, "project state");
            this.tb_ProjectState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectState.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 112;
            this.label7.Text = "State:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(207, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 113;
            this.label10.Text = "County:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_ProjectERCode
            // 
            this.tb_ProjectERCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectERCode.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectERCode.Location = new System.Drawing.Point(133, 1);
            this.tb_ProjectERCode.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectERCode.Name = "tb_ProjectERCode";
            this.tb_ProjectERCode.Size = new System.Drawing.Size(73, 20);
            this.tb_ProjectERCode.TabIndex = 6;
            this.tb_ProjectERCode.Tag = "/Properties/Ecoregion Code";
            this.toolTip.SetToolTip(this.tb_ProjectERCode, "project ecoregion code");
            this.tb_ProjectERCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectERCode.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // tb_ProjectCounty
            // 
            this.tb_ProjectCounty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectCounty.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectCounty.Location = new System.Drawing.Point(260, 22);
            this.tb_ProjectCounty.Margin = new System.Windows.Forms.Padding(0);
            this.tb_ProjectCounty.Name = "tb_ProjectCounty";
            this.tb_ProjectCounty.Size = new System.Drawing.Size(96, 20);
            this.tb_ProjectCounty.TabIndex = 5;
            this.tb_ProjectCounty.Tag = "/Properties/County";
            this.tb_ProjectCounty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_ProjectCounty, "Project county");
            this.tb_ProjectCounty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectCounty.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 111;
            this.label9.Text = "L3 Ecoregion Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 20);
            this.label11.TabIndex = 99;
            this.label11.Text = "Ecoregion Code:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 110;
            this.label8.Text = "L4 Ecoregion Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_ProjectHUCName
            // 
            this.tb_ProjectHUCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectHUCName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectHUCName.Location = new System.Drawing.Point(133, 85);
            this.tb_ProjectHUCName.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectHUCName.Name = "tb_ProjectHUCName";
            this.tb_ProjectHUCName.Size = new System.Drawing.Size(223, 20);
            this.tb_ProjectHUCName.TabIndex = 10;
            this.tb_ProjectHUCName.Tag = "/Properties/HUC Watershed Name";
            this.toolTip.SetToolTip(this.tb_ProjectHUCName, "project HUC8 watershed name");
            this.tb_ProjectHUCName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectHUCName.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // tb_ProjectERL4Name
            // 
            this.tb_ProjectERL4Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectERL4Name.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectERL4Name.Location = new System.Drawing.Point(133, 43);
            this.tb_ProjectERL4Name.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectERL4Name.Name = "tb_ProjectERL4Name";
            this.tb_ProjectERL4Name.Size = new System.Drawing.Size(223, 20);
            this.tb_ProjectERL4Name.TabIndex = 8;
            this.tb_ProjectERL4Name.Tag = "/Properties/L4 Ecoregion Name";
            this.toolTip.SetToolTip(this.tb_ProjectERL4Name, "project level IV ecoregion");
            this.tb_ProjectERL4Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectERL4Name.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 108;
            this.label3.Text = "HUC Watershed:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_ProjectHUCCode
            // 
            this.tb_ProjectHUCCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectHUCCode.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectHUCCode.Location = new System.Drawing.Point(133, 22);
            this.tb_ProjectHUCCode.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectHUCCode.Name = "tb_ProjectHUCCode";
            this.tb_ProjectHUCCode.Size = new System.Drawing.Size(73, 20);
            this.tb_ProjectHUCCode.TabIndex = 7;
            this.tb_ProjectHUCCode.Tag = "/Properties/HUC Watershed Code";
            this.toolTip.SetToolTip(this.tb_ProjectHUCCode, "project HUC8 watershed code");
            this.tb_ProjectHUCCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectHUCCode.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // tb_ProjectERL3Name
            // 
            this.tb_ProjectERL3Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectERL3Name.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectERL3Name.Location = new System.Drawing.Point(133, 64);
            this.tb_ProjectERL3Name.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectERL3Name.Name = "tb_ProjectERL3Name";
            this.tb_ProjectERL3Name.Size = new System.Drawing.Size(223, 20);
            this.tb_ProjectERL3Name.TabIndex = 9;
            this.tb_ProjectERL3Name.Tag = "/Properties/L3 Ecoregion Name";
            this.toolTip.SetToolTip(this.tb_ProjectERL3Name, "project level III ecoregion");
            this.tb_ProjectERL3Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue);
            this.tb_ProjectERL3Name.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 109;
            this.label6.Text = "HUC Watershed Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_CalcGeoProps
            // 
            this.btn_CalcGeoProps.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CalcGeoProps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CalcGeoProps.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcGeoProps.Image = ((System.Drawing.Image)(resources.GetObject("btn_CalcGeoProps.Image")));
            this.btn_CalcGeoProps.Location = new System.Drawing.Point(142, 40);
            this.btn_CalcGeoProps.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CalcGeoProps.Name = "btn_CalcGeoProps";
            this.btn_CalcGeoProps.Size = new System.Drawing.Size(24, 24);
            this.btn_CalcGeoProps.TabIndex = 72;
            this.btn_CalcGeoProps.TabStop = false;
            this.toolTip.SetToolTip(this.btn_CalcGeoProps, "Calculate geographic properties from shapefiles");
            this.btn_CalcGeoProps.UseVisualStyleBackColor = false;
            this.btn_CalcGeoProps.Click += new System.EventHandler(this.btn_CalcGeoProps_Click);
            // 
            // customGroupBox2
            // 
            this.customGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.customGroupBox2.Controls.Add(this.tb_ProjectLat);
            this.customGroupBox2.Controls.Add(this.label5);
            this.customGroupBox2.Controls.Add(this.label4);
            this.customGroupBox2.Controls.Add(this.tb_ProjectLon);
            this.customGroupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.customGroupBox2.Location = new System.Drawing.Point(5, 19);
            this.customGroupBox2.Name = "customGroupBox2";
            this.customGroupBox2.Size = new System.Drawing.Size(133, 55);
            this.customGroupBox2.TabIndex = 79;
            this.customGroupBox2.TabStop = false;
            this.customGroupBox2.Text = "Project Location";
            // 
            // tb_ProjectLat
            // 
            this.tb_ProjectLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectLat.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectLat.Location = new System.Drawing.Point(2, 33);
            this.tb_ProjectLat.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectLat.Name = "tb_ProjectLat";
            this.tb_ProjectLat.Size = new System.Drawing.Size(65, 20);
            this.tb_ProjectLat.TabIndex = 2;
            this.tb_ProjectLat.Tag = "/Properties/Latitude";
            this.tb_ProjectLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_ProjectLat, "project latitude (WGS84)");
            this.tb_ProjectLat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue_Decimal);
            this.tb_ProjectLat.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 105;
            this.label5.Text = "Latitude";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 104;
            this.label4.Text = "Longitude";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ProjectLon
            // 
            this.tb_ProjectLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectLon.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectLon.Location = new System.Drawing.Point(66, 33);
            this.tb_ProjectLon.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectLon.Name = "tb_ProjectLon";
            this.tb_ProjectLon.Size = new System.Drawing.Size(65, 20);
            this.tb_ProjectLon.TabIndex = 3;
            this.tb_ProjectLon.Tag = "/Properties/Longitude";
            this.tb_ProjectLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tb_ProjectLon, "project longitude (WGS84)");
            this.tb_ProjectLon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterValue_Decimal);
            this.tb_ProjectLon.Leave += new System.EventHandler(this.RestoreOnLeave);
            // 
            // ProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Btn_EditNotes);
            this.Controls.Add(this.gb_Main);
            this.Name = "ProjectEditor";
            this.Size = new System.Drawing.Size(493, 523);
            this.gb_Main.ResumeLayout(false);
            this.gb_Main.PerformLayout();
            this.customGroupBox1.ResumeLayout(false);
            this.gb_GeographicProperties.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customGroupBox2.ResumeLayout(false);
            this.customGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gb_Main;
        private Custom_Controls.GroupBox_Bordered customGroupBox1;
        private Button btn_GoToStream;
        private Button btn_DeleteStream;
        private ListBox lb_StreamList;
        private Button btn_AddStream;
        private Label lbl2;
        private TextBox Tb_ProjectID;
        private Custom_Controls.GroupBox_Bordered gb_GeographicProperties;
        private Label label5;
        private Button btn_CalcGeoProps;
        private Label label4;
        private TextBox tb_ProjectHUCCode;
        private TextBox tb_ProjectLon;
        private TextBox tb_ProjectLat;
        private TextBox tb_ProjectHUCName;
        private TextBox tb_ProjectERCode;
        private TextBox tb_ProjectERL3Name;
        private Label label11;
        private TextBox tb_ProjectERL4Name;
        private TextBox tb_ProjectCounty;
        private TextBox tb_ProjectState;
        private Button Btn_EditNotes;
        private Button button1;
        private ToolTip toolTip;
        private Custom_Controls.GroupBox_Bordered customGroupBox2;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label6;
        private Panel panel1;
        private Label label7;
        private Label label10;
        private Label label18;
    }
}
