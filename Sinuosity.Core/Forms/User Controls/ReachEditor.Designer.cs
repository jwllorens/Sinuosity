using System.Windows.Forms;
using System.Drawing;

namespace Sinuosity.Forms.User_Controls
{
    partial class ReachEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReachEditor));
            this.gb_Main = new System.Windows.Forms.GroupBox();
            this.Btn_EditNotes = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Tb_ReachID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ProjectLon = new System.Windows.Forms.TextBox();
            this.tb_ProjectLat = new System.Windows.Forms.TextBox();
            this.Btn_Back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.Cb_StreamType = new Sinuosity.Forms.Custom_Controls.ComboBox_Sizeable();
            this.groupBox_Bordered1 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.valueInput_Variable_Length1 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.valueInput_Station1 = new Sinuosity.Forms.Custom_Controls.ValueInput_Station();
            this.valueInput_Station2 = new Sinuosity.Forms.Custom_Controls.ValueInput_Station();
            this.vi_Design_Length = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.label14 = new System.Windows.Forms.Label();
            this.vi_Design_EndStation = new Sinuosity.Forms.Custom_Controls.ValueInput_Station();
            this.label6 = new System.Windows.Forms.Label();
            this.vi_Design_BeginStation = new Sinuosity.Forms.Custom_Controls.ValueInput_Station();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.customGroupBox3 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.valueInput_Variable_Area1 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.valueInput_Variable_Area2 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.valueInput_Variable_Area3 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.vi_Design_UpstreamDrainageArea = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.vi_Design_TotalDrainageArea = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.vi_Design_LateralDrainageArea = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb_Main.SuspendLayout();
            this.groupBox_Bordered1.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Main
            // 
            this.gb_Main.Controls.Add(this.label17);
            this.gb_Main.Controls.Add(this.button1);
            this.gb_Main.Controls.Add(this.Cb_StreamType);
            this.gb_Main.Controls.Add(this.groupBox_Bordered1);
            this.gb_Main.Controls.Add(this.customGroupBox3);
            this.gb_Main.Controls.Add(this.label7);
            this.gb_Main.Controls.Add(this.Tb_ReachID);
            this.gb_Main.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Main.Location = new System.Drawing.Point(3, 27);
            this.gb_Main.Name = "gb_Main";
            this.gb_Main.Size = new System.Drawing.Size(487, 470);
            this.gb_Main.TabIndex = 77;
            this.gb_Main.TabStop = false;
            this.gb_Main.Text = "Reach Properties";
            // 
            // Btn_EditNotes
            // 
            this.Btn_EditNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_EditNotes.Image = ((System.Drawing.Image)(resources.GetObject("Btn_EditNotes.Image")));
            this.Btn_EditNotes.Location = new System.Drawing.Point(466, 2);
            this.Btn_EditNotes.Name = "Btn_EditNotes";
            this.Btn_EditNotes.Size = new System.Drawing.Size(24, 24);
            this.Btn_EditNotes.TabIndex = 114;
            this.Btn_EditNotes.Tag = "/Properties/Description";
            this.toolTip.SetToolTip(this.Btn_EditNotes, "view or edit reach notes");
            this.Btn_EditNotes.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 24);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 20);
            this.label17.TabIndex = 151;
            this.label17.Text = "Reach ID:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(357, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 21);
            this.button1.TabIndex = 128;
            this.button1.Text = "Section Data";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(129, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 111;
            this.label7.Text = "Rosgen Stream Type:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tb_ReachID
            // 
            this.Tb_ReachID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tb_ReachID.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Tb_ReachID.Location = new System.Drawing.Point(68, 24);
            this.Tb_ReachID.Margin = new System.Windows.Forms.Padding(1);
            this.Tb_ReachID.Name = "Tb_ReachID";
            this.Tb_ReachID.Size = new System.Drawing.Size(59, 20);
            this.Tb_ReachID.TabIndex = 63;
            this.toolTip.SetToolTip(this.Tb_ReachID, "reach ID");
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 105;
            this.label5.Text = "Placeholder Text:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Placeholder Text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_ProjectLon
            // 
            this.tb_ProjectLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectLon.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectLon.Location = new System.Drawing.Point(136, 41);
            this.tb_ProjectLon.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectLon.Name = "tb_ProjectLon";
            this.tb_ProjectLon.Size = new System.Drawing.Size(200, 20);
            this.tb_ProjectLon.TabIndex = 92;
            this.tb_ProjectLon.Tag = "/Properties/Longitude";
            // 
            // tb_ProjectLat
            // 
            this.tb_ProjectLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ProjectLat.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_ProjectLat.Location = new System.Drawing.Point(136, 19);
            this.tb_ProjectLat.Margin = new System.Windows.Forms.Padding(1);
            this.tb_ProjectLat.Name = "tb_ProjectLat";
            this.tb_ProjectLat.Size = new System.Drawing.Size(200, 20);
            this.tb_ProjectLat.TabIndex = 90;
            this.tb_ProjectLat.Tag = "/Properties/Latitude";
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Back.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_Back.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Back.Image")));
            this.Btn_Back.Location = new System.Drawing.Point(3, 2);
            this.Btn_Back.Margin = new System.Windows.Forms.Padding(1);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(24, 24);
            this.Btn_Back.TabIndex = 75;
            this.toolTip.SetToolTip(this.Btn_Back, "back to parent stream");
            this.Btn_Back.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Back to Stream";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(425, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 14);
            this.label18.TabIndex = 115;
            this.label18.Text = "Notes";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cb_StreamType
            // 
            this.Cb_StreamType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Cb_StreamType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cb_StreamType.FormattingEnabled = true;
            this.Cb_StreamType.ItemHeight = 14;
            this.Cb_StreamType.Items.AddRange(new object[] {
            "Aa+",
            "A",
            "Ba",
            "B",
            "Bc",
            "Eb",
            "E",
            "Ec*",
            "Cb",
            "C",
            "Cc-",
            "G",
            "Gc",
            "F",
            "Fb",
            "D",
            "Db",
            "Dc",
            "DA"});
            this.Cb_StreamType.Location = new System.Drawing.Point(260, 24);
            this.Cb_StreamType.Name = "Cb_StreamType";
            this.Cb_StreamType.Size = new System.Drawing.Size(38, 20);
            this.Cb_StreamType.TabIndex = 130;
            // 
            // groupBox_Bordered1
            // 
            this.groupBox_Bordered1.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered1.Controls.Add(this.valueInput_Variable_Length1);
            this.groupBox_Bordered1.Controls.Add(this.valueInput_Station1);
            this.groupBox_Bordered1.Controls.Add(this.valueInput_Station2);
            this.groupBox_Bordered1.Controls.Add(this.vi_Design_Length);
            this.groupBox_Bordered1.Controls.Add(this.label14);
            this.groupBox_Bordered1.Controls.Add(this.vi_Design_EndStation);
            this.groupBox_Bordered1.Controls.Add(this.label6);
            this.groupBox_Bordered1.Controls.Add(this.vi_Design_BeginStation);
            this.groupBox_Bordered1.Controls.Add(this.label15);
            this.groupBox_Bordered1.Controls.Add(this.label16);
            this.groupBox_Bordered1.Controls.Add(this.label8);
            this.groupBox_Bordered1.Controls.Add(this.label9);
            this.groupBox_Bordered1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox_Bordered1.Location = new System.Drawing.Point(8, 169);
            this.groupBox_Bordered1.Name = "groupBox_Bordered1";
            this.groupBox_Bordered1.Size = new System.Drawing.Size(344, 92);
            this.groupBox_Bordered1.TabIndex = 148;
            this.groupBox_Bordered1.TabStop = false;
            this.groupBox_Bordered1.Text = "Length";
            // 
            // valueInput_Variable_Length1
            // 
            this.valueInput_Variable_Length1.ComboBoxWidth = 44;
            this.valueInput_Variable_Length1.DisplayPrecision = 2;
            this.valueInput_Variable_Length1.Gap = 1;
            this.valueInput_Variable_Length1.Location = new System.Drawing.Point(237, 71);
            this.valueInput_Variable_Length1.MaximumSize = new System.Drawing.Size(429, 17);
            this.valueInput_Variable_Length1.MinimumSize = new System.Drawing.Size(84, 17);
            this.valueInput_Variable_Length1.Name = "valueInput_Variable_Length1";
            this.valueInput_Variable_Length1.ReadOnly = true;
            this.valueInput_Variable_Length1.Size = new System.Drawing.Size(104, 17);
            this.valueInput_Variable_Length1.TabIndex = 148;
            this.valueInput_Variable_Length1.Tag = "/Properties/Design/Length";
            this.valueInput_Variable_Length1.Text = "valueInput_Variable_Length1";
            this.valueInput_Variable_Length1.Unit = null;
            this.valueInput_Variable_Length1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Station1
            // 
            this.valueInput_Station1.DisplayPrecision = 2;
            this.valueInput_Station1.Gap = 1;
            this.valueInput_Station1.Location = new System.Drawing.Point(237, 53);
            this.valueInput_Station1.MaximumSize = new System.Drawing.Size(429, 17);
            this.valueInput_Station1.MinimumSize = new System.Drawing.Size(84, 17);
            this.valueInput_Station1.Name = "valueInput_Station1";
            this.valueInput_Station1.ReadOnly = false;
            this.valueInput_Station1.Size = new System.Drawing.Size(104, 17);
            this.valueInput_Station1.TabIndex = 150;
            this.valueInput_Station1.Tag = "/Properties/Design/EndStation";
            this.valueInput_Station1.Text = "valueInput_Station1";
            this.valueInput_Station1.UnitBoxWidth = 44;
            this.valueInput_Station1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Station2
            // 
            this.valueInput_Station2.DisplayPrecision = 2;
            this.valueInput_Station2.Gap = 1;
            this.valueInput_Station2.Location = new System.Drawing.Point(237, 35);
            this.valueInput_Station2.MaximumSize = new System.Drawing.Size(429, 17);
            this.valueInput_Station2.MinimumSize = new System.Drawing.Size(84, 17);
            this.valueInput_Station2.Name = "valueInput_Station2";
            this.valueInput_Station2.ReadOnly = false;
            this.valueInput_Station2.Size = new System.Drawing.Size(104, 17);
            this.valueInput_Station2.TabIndex = 149;
            this.valueInput_Station2.Tag = "/Properties/Design/BeginStation";
            this.valueInput_Station2.Text = "valueInput_Station1";
            this.valueInput_Station2.UnitBoxWidth = 44;
            this.valueInput_Station2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vi_Design_Length
            // 
            this.vi_Design_Length.ComboBoxWidth = 44;
            this.vi_Design_Length.DisplayPrecision = 2;
            this.vi_Design_Length.Gap = 1;
            this.vi_Design_Length.Location = new System.Drawing.Point(132, 71);
            this.vi_Design_Length.MaximumSize = new System.Drawing.Size(429, 17);
            this.vi_Design_Length.MinimumSize = new System.Drawing.Size(84, 17);
            this.vi_Design_Length.Name = "vi_Design_Length";
            this.vi_Design_Length.ReadOnly = true;
            this.vi_Design_Length.Size = new System.Drawing.Size(104, 17);
            this.vi_Design_Length.TabIndex = 128;
            this.vi_Design_Length.Tag = "/Properties/Design/Length";
            this.vi_Design_Length.Text = "valueInput_Variable_Length1";
            this.vi_Design_Length.Unit = null;
            this.vi_Design_Length.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label14.Location = new System.Drawing.Point(237, 16);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 18);
            this.label14.TabIndex = 147;
            this.label14.Text = "Proposed";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vi_Design_EndStation
            // 
            this.vi_Design_EndStation.DisplayPrecision = 2;
            this.vi_Design_EndStation.Gap = 1;
            this.vi_Design_EndStation.Location = new System.Drawing.Point(132, 53);
            this.vi_Design_EndStation.MaximumSize = new System.Drawing.Size(429, 17);
            this.vi_Design_EndStation.MinimumSize = new System.Drawing.Size(84, 17);
            this.vi_Design_EndStation.Name = "vi_Design_EndStation";
            this.vi_Design_EndStation.ReadOnly = false;
            this.vi_Design_EndStation.Size = new System.Drawing.Size(104, 17);
            this.vi_Design_EndStation.TabIndex = 129;
            this.vi_Design_EndStation.Tag = "/Properties/Design/EndStation";
            this.vi_Design_EndStation.Text = "valueInput_Station1";
            this.vi_Design_EndStation.UnitBoxWidth = 44;
            this.vi_Design_EndStation.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 123;
            this.label6.Text = "Total Length:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Design_BeginStation
            // 
            this.vi_Design_BeginStation.DisplayPrecision = 2;
            this.vi_Design_BeginStation.Gap = 1;
            this.vi_Design_BeginStation.Location = new System.Drawing.Point(132, 35);
            this.vi_Design_BeginStation.MaximumSize = new System.Drawing.Size(429, 17);
            this.vi_Design_BeginStation.MinimumSize = new System.Drawing.Size(84, 17);
            this.vi_Design_BeginStation.Name = "vi_Design_BeginStation";
            this.vi_Design_BeginStation.ReadOnly = false;
            this.vi_Design_BeginStation.Size = new System.Drawing.Size(104, 17);
            this.vi_Design_BeginStation.TabIndex = 128;
            this.vi_Design_BeginStation.Tag = "/Properties/Design/BeginStation";
            this.vi_Design_BeginStation.Text = "valueInput_Station1";
            this.vi_Design_BeginStation.UnitBoxWidth = 44;
            this.vi_Design_BeginStation.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label15.Location = new System.Drawing.Point(3, 16);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 18);
            this.label15.TabIndex = 146;
            this.label15.Text = "Property";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label16.Location = new System.Drawing.Point(132, 16);
            this.label16.Margin = new System.Windows.Forms.Padding(1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 18);
            this.label16.TabIndex = 145;
            this.label16.Text = "Existing";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 18);
            this.label8.TabIndex = 105;
            this.label8.Text = "Begin Station:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 18);
            this.label9.TabIndex = 104;
            this.label9.Text = "End Station:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.BorderColor = System.Drawing.Color.Black;
            this.customGroupBox3.Controls.Add(this.label13);
            this.customGroupBox3.Controls.Add(this.label10);
            this.customGroupBox3.Controls.Add(this.label12);
            this.customGroupBox3.Controls.Add(this.valueInput_Variable_Area1);
            this.customGroupBox3.Controls.Add(this.valueInput_Variable_Area2);
            this.customGroupBox3.Controls.Add(this.valueInput_Variable_Area3);
            this.customGroupBox3.Controls.Add(this.vi_Design_UpstreamDrainageArea);
            this.customGroupBox3.Controls.Add(this.vi_Design_TotalDrainageArea);
            this.customGroupBox3.Controls.Add(this.vi_Design_LateralDrainageArea);
            this.customGroupBox3.Controls.Add(this.label11);
            this.customGroupBox3.Controls.Add(this.label2);
            this.customGroupBox3.Controls.Add(this.label3);
            this.customGroupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.customGroupBox3.Location = new System.Drawing.Point(5, 54);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(362, 101);
            this.customGroupBox3.TabIndex = 126;
            this.customGroupBox3.TabStop = false;
            this.customGroupBox3.Text = "Drainage Area";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label13.Location = new System.Drawing.Point(255, 17);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 18);
            this.label13.TabIndex = 147;
            this.label13.Text = "Proposed";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label10.Location = new System.Drawing.Point(3, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 18);
            this.label10.TabIndex = 146;
            this.label10.Text = "Property";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label12.Location = new System.Drawing.Point(150, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 18);
            this.label12.TabIndex = 145;
            this.label12.Text = "Existing";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // valueInput_Variable_Area1
            // 
            this.valueInput_Variable_Area1.ComboBoxWidth = 44;
            this.valueInput_Variable_Area1.DisplayPrecision = 3;
            this.valueInput_Variable_Area1.Gap = 1;
            this.valueInput_Variable_Area1.Location = new System.Drawing.Point(150, 78);
            this.valueInput_Variable_Area1.MaximumSize = new System.Drawing.Size(500, 20);
            this.valueInput_Variable_Area1.MinimumSize = new System.Drawing.Size(100, 20);
            this.valueInput_Variable_Area1.Name = "valueInput_Variable_Area1";
            this.valueInput_Variable_Area1.ReadOnly = true;
            this.valueInput_Variable_Area1.Size = new System.Drawing.Size(104, 20);
            this.valueInput_Variable_Area1.TabIndex = 133;
            this.valueInput_Variable_Area1.Tag = "Properties/Design/TotalDrainageArea";
            this.valueInput_Variable_Area1.Text = "valueInput_Variable_Area3";
            this.valueInput_Variable_Area1.Unit = null;
            this.valueInput_Variable_Area1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Variable_Area2
            // 
            this.valueInput_Variable_Area2.ComboBoxWidth = 44;
            this.valueInput_Variable_Area2.DisplayPrecision = 3;
            this.valueInput_Variable_Area2.Gap = 1;
            this.valueInput_Variable_Area2.Location = new System.Drawing.Point(150, 57);
            this.valueInput_Variable_Area2.MaximumSize = new System.Drawing.Size(500, 20);
            this.valueInput_Variable_Area2.MinimumSize = new System.Drawing.Size(100, 20);
            this.valueInput_Variable_Area2.Name = "valueInput_Variable_Area2";
            this.valueInput_Variable_Area2.ReadOnly = false;
            this.valueInput_Variable_Area2.Size = new System.Drawing.Size(104, 20);
            this.valueInput_Variable_Area2.TabIndex = 132;
            this.valueInput_Variable_Area2.Tag = "Properties/Design/LateralDrainageArea";
            this.valueInput_Variable_Area2.Text = "valueInput_Variable_Area2";
            this.valueInput_Variable_Area2.Unit = null;
            this.valueInput_Variable_Area2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Variable_Area3
            // 
            this.valueInput_Variable_Area3.ComboBoxWidth = 44;
            this.valueInput_Variable_Area3.DisplayPrecision = 3;
            this.valueInput_Variable_Area3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueInput_Variable_Area3.Gap = 1;
            this.valueInput_Variable_Area3.Location = new System.Drawing.Point(150, 36);
            this.valueInput_Variable_Area3.Margin = new System.Windows.Forms.Padding(0);
            this.valueInput_Variable_Area3.MaximumSize = new System.Drawing.Size(500, 20);
            this.valueInput_Variable_Area3.MinimumSize = new System.Drawing.Size(98, 20);
            this.valueInput_Variable_Area3.Name = "valueInput_Variable_Area3";
            this.valueInput_Variable_Area3.ReadOnly = false;
            this.valueInput_Variable_Area3.Size = new System.Drawing.Size(104, 20);
            this.valueInput_Variable_Area3.TabIndex = 131;
            this.valueInput_Variable_Area3.Tag = "/Properties/Design/UpstreamDrainageArea";
            this.valueInput_Variable_Area3.Text = "valueInput_Variable_Area1";
            this.valueInput_Variable_Area3.Unit = null;
            this.valueInput_Variable_Area3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valueInput_Variable_Area3.Click += new System.EventHandler(this.valueInput_Variable_Area3_Click);
            // 
            // vi_Design_UpstreamDrainageArea
            // 
            this.vi_Design_UpstreamDrainageArea.ComboBoxWidth = 44;
            this.vi_Design_UpstreamDrainageArea.DisplayPrecision = 3;
            this.vi_Design_UpstreamDrainageArea.Gap = 1;
            this.vi_Design_UpstreamDrainageArea.Location = new System.Drawing.Point(255, 36);
            this.vi_Design_UpstreamDrainageArea.MaximumSize = new System.Drawing.Size(500, 20);
            this.vi_Design_UpstreamDrainageArea.MinimumSize = new System.Drawing.Size(100, 20);
            this.vi_Design_UpstreamDrainageArea.Name = "vi_Design_UpstreamDrainageArea";
            this.vi_Design_UpstreamDrainageArea.ReadOnly = false;
            this.vi_Design_UpstreamDrainageArea.Size = new System.Drawing.Size(104, 20);
            this.vi_Design_UpstreamDrainageArea.TabIndex = 128;
            this.vi_Design_UpstreamDrainageArea.Tag = "/Properties/Design/UpstreamDrainageArea";
            this.vi_Design_UpstreamDrainageArea.Text = "valueInput_Variable_Area1";
            this.vi_Design_UpstreamDrainageArea.Unit = null;
            this.vi_Design_UpstreamDrainageArea.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vi_Design_TotalDrainageArea
            // 
            this.vi_Design_TotalDrainageArea.ComboBoxWidth = 44;
            this.vi_Design_TotalDrainageArea.DisplayPrecision = 3;
            this.vi_Design_TotalDrainageArea.Gap = 1;
            this.vi_Design_TotalDrainageArea.Location = new System.Drawing.Point(255, 78);
            this.vi_Design_TotalDrainageArea.MaximumSize = new System.Drawing.Size(500, 20);
            this.vi_Design_TotalDrainageArea.MinimumSize = new System.Drawing.Size(100, 20);
            this.vi_Design_TotalDrainageArea.Name = "vi_Design_TotalDrainageArea";
            this.vi_Design_TotalDrainageArea.ReadOnly = true;
            this.vi_Design_TotalDrainageArea.Size = new System.Drawing.Size(104, 20);
            this.vi_Design_TotalDrainageArea.TabIndex = 130;
            this.vi_Design_TotalDrainageArea.Tag = "Properties/Design/TotalDrainageArea";
            this.vi_Design_TotalDrainageArea.Text = "valueInput_Variable_Area3";
            this.vi_Design_TotalDrainageArea.Unit = null;
            this.vi_Design_TotalDrainageArea.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vi_Design_LateralDrainageArea
            // 
            this.vi_Design_LateralDrainageArea.ComboBoxWidth = 44;
            this.vi_Design_LateralDrainageArea.DisplayPrecision = 3;
            this.vi_Design_LateralDrainageArea.Gap = 1;
            this.vi_Design_LateralDrainageArea.Location = new System.Drawing.Point(255, 57);
            this.vi_Design_LateralDrainageArea.MaximumSize = new System.Drawing.Size(500, 20);
            this.vi_Design_LateralDrainageArea.MinimumSize = new System.Drawing.Size(100, 20);
            this.vi_Design_LateralDrainageArea.Name = "vi_Design_LateralDrainageArea";
            this.vi_Design_LateralDrainageArea.ReadOnly = false;
            this.vi_Design_LateralDrainageArea.Size = new System.Drawing.Size(104, 20);
            this.vi_Design_LateralDrainageArea.TabIndex = 129;
            this.vi_Design_LateralDrainageArea.Tag = "Properties/Design/LateralDrainageArea";
            this.vi_Design_LateralDrainageArea.Text = "valueInput_Variable_Area2";
            this.vi_Design_LateralDrainageArea.Unit = null;
            this.vi_Design_LateralDrainageArea.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 20);
            this.label11.TabIndex = 123;
            this.label11.Text = "Total Drainage Area:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 105;
            this.label2.Text = "Upstream Drainage Area:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 104;
            this.label3.Text = "Lateral Drainage Area:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReachEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Btn_Back);
            this.Controls.Add(this.Btn_EditNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_Main);
            this.Name = "ReachEditor";
            this.Size = new System.Drawing.Size(493, 523);
            this.gb_Main.ResumeLayout(false);
            this.gb_Main.PerformLayout();
            this.groupBox_Bordered1.ResumeLayout(false);
            this.customGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gb_Main;
        private TextBox Tb_ReachID;
        private Button Btn_Back;
        private Label label1;
        private Custom_Controls.GroupBox_Bordered gb_Reaches;
        private Label label5;
        private Label label4;
        private TextBox tb_ProjectLon;
        private TextBox tb_ProjectLat;
        private Button Btn_EditNotes;
        private ToolTip toolTip;
        private Label label2;
        private Label label3;
        private Label label6;
        private TextBox Tb_;
        private Label label7;
        private TextBox textBox3;
        private Label label8;
        private Label label9;
        private TextBox textBox2;
        private ComboBox comboBox3;
        private Label label11;
        private Custom_Controls.GroupBox_Bordered customGroupBox3;
        private Custom_Controls.ValueInput_Variable_Area unitValue_TotalDrainageArea_Design;
        private Custom_Controls.ValueInput_Station vi_Design_BeginStation;
        private Custom_Controls.ValueInput_Station vi_Design_EndStation;
        private Custom_Controls.ValueInput_Variable_Area vi_Design_TotalDrainageArea;
        private Custom_Controls.ValueInput_Variable_Area vi_Design_LateralDrainageArea;
        private Custom_Controls.ValueInput_Variable_Area vi_Design_UpstreamDrainageArea;
        private Custom_Controls.ValueInput_Variable_Length vi_Design_Length;
        private Custom_Controls.ComboBox_Sizeable Cb_StreamType;
        private Custom_Controls.ValueInput_Variable_Area valueInput_Variable_Area1;
        private Custom_Controls.ValueInput_Variable_Area valueInput_Variable_Area2;
        private Custom_Controls.ValueInput_Variable_Area valueInput_Variable_Area3;
        private Label label13;
        private Label label10;
        private Label label12;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Button button1;
        private Custom_Controls.ValueInput_Variable_Length valueInput_Variable_Length1;
        private Custom_Controls.ValueInput_Station valueInput_Station1;
        private Custom_Controls.ValueInput_Station valueInput_Station2;
        private Label label17;
        private Label label18;
    }
}
