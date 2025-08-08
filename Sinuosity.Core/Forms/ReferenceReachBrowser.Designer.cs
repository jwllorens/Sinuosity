using System.Windows.Forms;
using Sinuosity.Forms.Custom_Controls;
using ScottPlot.WinForms;
using System;
using System.Drawing;


namespace Sinuosity.Forms
{
    partial class ReferenceReachBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceReachBrowser));
            this.listView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ecoregionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.streamTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drainageAreaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slopeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_CopyStream = new System.Windows.Forms.Button();
            this.btn_DeleteStream = new System.Windows.Forms.Button();
            this.btn_AddStream = new System.Windows.Forms.Button();
            this.tb_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Path_ReferenceReachPath = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tb_NameFilter = new System.Windows.Forms.TextBox();
            this.tb_EcoregionFilter = new System.Windows.Forms.TextBox();
            this.tb_StreamTypeFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vi_Filter_DrainageAreaMin = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.label4 = new System.Windows.Forms.Label();
            this.vi_Filter_StreamSlopeMin = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Slope();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_Bordered1 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.label10 = new System.Windows.Forms.Label();
            this.vi_Filter_StreamSlopeMax = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Slope();
            this.label8 = new System.Windows.Forms.Label();
            this.vi_Filter_DrainageAreaMax = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox_Bordered2 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.mathExpressionPanel = new Sinuosity.Forms.Custom_Controls.MathExpressionPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.customGroupBox3 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_CitationURL = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_CitationGrantID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_PreparedFor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_CitationPublisher = new System.Windows.Forms.TextBox();
            this.tb_CitationYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_CitationDay = new System.Windows.Forms.TextBox();
            this.tb_CitationTitle = new System.Windows.Forms.TextBox();
            this.tb_CitationMonth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_CitationAuthor = new System.Windows.Forms.TextBox();
            this.valueInput_Variable_Length2 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.groupBox_Bordered3 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.label11 = new System.Windows.Forms.Label();
            this.vi_Design_UpstreamDrainageArea = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.groupBox_Bordered4 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.subscriptLabel2 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.label_Subscript2 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.label_Subscript4 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.valueInput_Variable_Area2 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Area();
            this.label_Subscript1 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.valueInput_Variable_Length1 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.valueInput_Variable_Length3 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label_Subscript3 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.label32 = new System.Windows.Forms.Label();
            this.Cb_StreamType = new System.Windows.Forms.ComboBox();
            this.valueInput_Variable_Slope2 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Slope();
            this.valueInput_Variable_Length4 = new Sinuosity.Forms.Custom_Controls.ValueInput_Variable_Length();
            this.label_Subscript5 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.label_Subscript6 = new Sinuosity.Forms.Custom_Controls.Label_Subscript();
            this.groupBox_Bordered5 = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.mathExpressionPanel1 = new Sinuosity.Forms.Custom_Controls.MathExpressionPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_Bordered1.SuspendLayout();
            this.groupBox_Bordered2.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.groupBox_Bordered3.SuspendLayout();
            this.groupBox_Bordered4.SuspendLayout();
            this.groupBox_Bordered5.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.ecoregionHeader,
            this.streamTypeHeader,
            this.drainageAreaHeader,
            this.slopeHeader});
            this.listView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(4, 221);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(678, 540);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            // 
            // ecoregionHeader
            // 
            this.ecoregionHeader.Text = "Ecoregion";
            // 
            // streamTypeHeader
            // 
            this.streamTypeHeader.Text = "Stream Type";
            // 
            // drainageAreaHeader
            // 
            this.drainageAreaHeader.Text = "Drainage Area (sq. mi.)";
            // 
            // slopeHeader
            // 
            this.slopeHeader.Text = "Bankfull Slope (ft/ft)";
            // 
            // btn_CopyStream
            // 
            this.btn_CopyStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CopyStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CopyStream.Location = new System.Drawing.Point(658, 172);
            this.btn_CopyStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CopyStream.Name = "btn_CopyStream";
            this.btn_CopyStream.Size = new System.Drawing.Size(24, 24);
            this.btn_CopyStream.TabIndex = 74;
            this.btn_CopyStream.TabStop = false;
            this.btn_CopyStream.UseVisualStyleBackColor = false;
            // 
            // btn_DeleteStream
            // 
            this.btn_DeleteStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DeleteStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DeleteStream.Location = new System.Drawing.Point(658, 195);
            this.btn_DeleteStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_DeleteStream.Name = "btn_DeleteStream";
            this.btn_DeleteStream.Size = new System.Drawing.Size(24, 24);
            this.btn_DeleteStream.TabIndex = 73;
            this.btn_DeleteStream.TabStop = false;
            this.btn_DeleteStream.UseVisualStyleBackColor = false;
            // 
            // btn_AddStream
            // 
            this.btn_AddStream.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AddStream.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddStream.Location = new System.Drawing.Point(658, 148);
            this.btn_AddStream.Margin = new System.Windows.Forms.Padding(1);
            this.btn_AddStream.Name = "btn_AddStream";
            this.btn_AddStream.Size = new System.Drawing.Size(24, 24);
            this.btn_AddStream.TabIndex = 72;
            this.btn_AddStream.TabStop = false;
            this.btn_AddStream.UseVisualStyleBackColor = false;
            // 
            // tb_FilePath
            // 
            this.tb_FilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FilePath.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_FilePath.Location = new System.Drawing.Point(160, 20);
            this.tb_FilePath.Margin = new System.Windows.Forms.Padding(1);
            this.tb_FilePath.Name = "tb_FilePath";
            this.tb_FilePath.Size = new System.Drawing.Size(448, 20);
            this.tb_FilePath.TabIndex = 147;
            // 
            // btn_Path_ReferenceReachPath
            // 
            this.btn_Path_ReferenceReachPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Path_ReferenceReachPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Path_ReferenceReachPath.BackgroundImage")));
            this.btn_Path_ReferenceReachPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Path_ReferenceReachPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Path_ReferenceReachPath.Location = new System.Drawing.Point(141, 22);
            this.btn_Path_ReferenceReachPath.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Path_ReferenceReachPath.Name = "btn_Path_ReferenceReachPath";
            this.btn_Path_ReferenceReachPath.Size = new System.Drawing.Size(16, 16);
            this.btn_Path_ReferenceReachPath.TabIndex = 146;
            this.btn_Path_ReferenceReachPath.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(139, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 152;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 20);
            this.label20.Margin = new System.Windows.Forms.Padding(1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 20);
            this.label20.TabIndex = 149;
            this.label20.Text = "Reference Reach Data:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_NameFilter
            // 
            this.tb_NameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_NameFilter.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_NameFilter.Location = new System.Drawing.Point(122, 20);
            this.tb_NameFilter.Name = "tb_NameFilter";
            this.tb_NameFilter.Size = new System.Drawing.Size(117, 20);
            this.tb_NameFilter.TabIndex = 1;
            // 
            // tb_EcoregionFilter
            // 
            this.tb_EcoregionFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_EcoregionFilter.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_EcoregionFilter.Location = new System.Drawing.Point(122, 41);
            this.tb_EcoregionFilter.Name = "tb_EcoregionFilter";
            this.tb_EcoregionFilter.Size = new System.Drawing.Size(117, 20);
            this.tb_EcoregionFilter.TabIndex = 2;
            // 
            // tb_StreamTypeFilter
            // 
            this.tb_StreamTypeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StreamTypeFilter.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_StreamTypeFilter.Location = new System.Drawing.Point(122, 62);
            this.tb_StreamTypeFilter.Name = "tb_StreamTypeFilter";
            this.tb_StreamTypeFilter.Size = new System.Drawing.Size(117, 20);
            this.tb_StreamTypeFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 153;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 154;
            this.label2.Text = "Ecoregion:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 155;
            this.label3.Text = "Stream Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Filter_DrainageAreaMin
            // 
            this.vi_Filter_DrainageAreaMin.ComboBoxWidth = 54;
            this.vi_Filter_DrainageAreaMin.DisplayPrecision = 3;
            this.vi_Filter_DrainageAreaMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vi_Filter_DrainageAreaMin.Gap = 1;
            this.vi_Filter_DrainageAreaMin.Location = new System.Drawing.Point(122, 83);
            this.vi_Filter_DrainageAreaMin.MaximumSize = new System.Drawing.Size(500, 21);
            this.vi_Filter_DrainageAreaMin.MinimumSize = new System.Drawing.Size(98, 21);
            this.vi_Filter_DrainageAreaMin.Name = "vi_Filter_DrainageAreaMin";
            this.vi_Filter_DrainageAreaMin.ReadOnly = false;
            this.vi_Filter_DrainageAreaMin.Size = new System.Drawing.Size(117, 21);
            this.vi_Filter_DrainageAreaMin.TabIndex = 156;
            this.vi_Filter_DrainageAreaMin.Text = "valueInput_Variable_Area1";
            this.vi_Filter_DrainageAreaMin.Unit = null;
            this.vi_Filter_DrainageAreaMin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 157;
            this.label4.Text = "Drainage Area Min:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Filter_StreamSlopeMin
            // 
            this.vi_Filter_StreamSlopeMin.ComboBoxWidth = 54;
            this.vi_Filter_StreamSlopeMin.DisplayPrecision = 3;
            this.vi_Filter_StreamSlopeMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vi_Filter_StreamSlopeMin.Gap = 1;
            this.vi_Filter_StreamSlopeMin.Location = new System.Drawing.Point(122, 125);
            this.vi_Filter_StreamSlopeMin.MaximumSize = new System.Drawing.Size(500, 21);
            this.vi_Filter_StreamSlopeMin.MinimumSize = new System.Drawing.Size(98, 21);
            this.vi_Filter_StreamSlopeMin.Name = "vi_Filter_StreamSlopeMin";
            this.vi_Filter_StreamSlopeMin.ReadOnly = false;
            this.vi_Filter_StreamSlopeMin.Size = new System.Drawing.Size(117, 21);
            this.vi_Filter_StreamSlopeMin.TabIndex = 159;
            this.vi_Filter_StreamSlopeMin.Text = "valueInput_Variable_Slope1";
            this.vi_Filter_StreamSlopeMin.Unit = null;
            this.vi_Filter_StreamSlopeMin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 161;
            this.label5.Text = "Stream Slope Min:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox_Bordered1
            // 
            this.groupBox_Bordered1.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered1.Controls.Add(this.label10);
            this.groupBox_Bordered1.Controls.Add(this.vi_Filter_StreamSlopeMax);
            this.groupBox_Bordered1.Controls.Add(this.label8);
            this.groupBox_Bordered1.Controls.Add(this.vi_Filter_DrainageAreaMax);
            this.groupBox_Bordered1.Controls.Add(this.label1);
            this.groupBox_Bordered1.Controls.Add(this.label5);
            this.groupBox_Bordered1.Controls.Add(this.tb_StreamTypeFilter);
            this.groupBox_Bordered1.Controls.Add(this.tb_EcoregionFilter);
            this.groupBox_Bordered1.Controls.Add(this.vi_Filter_StreamSlopeMin);
            this.groupBox_Bordered1.Controls.Add(this.tb_NameFilter);
            this.groupBox_Bordered1.Controls.Add(this.label2);
            this.groupBox_Bordered1.Controls.Add(this.label4);
            this.groupBox_Bordered1.Controls.Add(this.label3);
            this.groupBox_Bordered1.Controls.Add(this.vi_Filter_DrainageAreaMin);
            this.groupBox_Bordered1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Bordered1.Location = new System.Drawing.Point(6, 44);
            this.groupBox_Bordered1.Name = "groupBox_Bordered1";
            this.groupBox_Bordered1.Size = new System.Drawing.Size(243, 171);
            this.groupBox_Bordered1.TabIndex = 162;
            this.groupBox_Bordered1.TabStop = false;
            this.groupBox_Bordered1.Text = "Filter";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 165;
            this.label10.Text = "Stream Slope Max:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Filter_StreamSlopeMax
            // 
            this.vi_Filter_StreamSlopeMax.ComboBoxWidth = 54;
            this.vi_Filter_StreamSlopeMax.DisplayPrecision = 3;
            this.vi_Filter_StreamSlopeMax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vi_Filter_StreamSlopeMax.Gap = 1;
            this.vi_Filter_StreamSlopeMax.Location = new System.Drawing.Point(122, 146);
            this.vi_Filter_StreamSlopeMax.MaximumSize = new System.Drawing.Size(500, 21);
            this.vi_Filter_StreamSlopeMax.MinimumSize = new System.Drawing.Size(98, 21);
            this.vi_Filter_StreamSlopeMax.Name = "vi_Filter_StreamSlopeMax";
            this.vi_Filter_StreamSlopeMax.ReadOnly = false;
            this.vi_Filter_StreamSlopeMax.Size = new System.Drawing.Size(117, 21);
            this.vi_Filter_StreamSlopeMax.TabIndex = 164;
            this.vi_Filter_StreamSlopeMax.Text = "valueInput_Variable_Slope3";
            this.vi_Filter_StreamSlopeMax.Unit = null;
            this.vi_Filter_StreamSlopeMax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 162;
            this.label8.Text = "Drainage Area Max:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Filter_DrainageAreaMax
            // 
            this.vi_Filter_DrainageAreaMax.ComboBoxWidth = 54;
            this.vi_Filter_DrainageAreaMax.DisplayPrecision = 3;
            this.vi_Filter_DrainageAreaMax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vi_Filter_DrainageAreaMax.Gap = 1;
            this.vi_Filter_DrainageAreaMax.Location = new System.Drawing.Point(122, 104);
            this.vi_Filter_DrainageAreaMax.MaximumSize = new System.Drawing.Size(500, 21);
            this.vi_Filter_DrainageAreaMax.MinimumSize = new System.Drawing.Size(98, 21);
            this.vi_Filter_DrainageAreaMax.Name = "vi_Filter_DrainageAreaMax";
            this.vi_Filter_DrainageAreaMax.ReadOnly = false;
            this.vi_Filter_DrainageAreaMax.Size = new System.Drawing.Size(117, 21);
            this.vi_Filter_DrainageAreaMax.TabIndex = 163;
            this.vi_Filter_DrainageAreaMax.Text = "valueInput_Variable_Area3";
            this.vi_Filter_DrainageAreaMax.Unit = null;
            this.vi_Filter_DrainageAreaMax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // formsPlot1
            // 
            this.formsPlot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Location = new System.Drawing.Point(6, 42);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(2);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(678, 353);
            this.formsPlot1.TabIndex = 163;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 398);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 21);
            this.label7.TabIndex = 162;
            this.label7.Text = "Relationship Equation:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_Bordered2
            // 
            this.groupBox_Bordered2.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered2.Controls.Add(this.textBox10);
            this.groupBox_Bordered2.Controls.Add(this.listView1);
            this.groupBox_Bordered2.Controls.Add(this.button1);
            this.groupBox_Bordered2.Controls.Add(this.mathExpressionPanel);
            this.groupBox_Bordered2.Controls.Add(this.label22);
            this.groupBox_Bordered2.Controls.Add(this.formsPlot1);
            this.groupBox_Bordered2.Controls.Add(this.label21);
            this.groupBox_Bordered2.Controls.Add(this.label7);
            this.groupBox_Bordered2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Bordered2.Location = new System.Drawing.Point(1256, 13);
            this.groupBox_Bordered2.Name = "groupBox_Bordered2";
            this.groupBox_Bordered2.Size = new System.Drawing.Size(690, 771);
            this.groupBox_Bordered2.TabIndex = 163;
            this.groupBox_Bordered2.TabStop = false;
            this.groupBox_Bordered2.Text = "Filter";
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.textBox10.Location = new System.Drawing.Point(160, 20);
            this.textBox10.Margin = new System.Windows.Forms.Padding(1);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(524, 20);
            this.textBox10.TabIndex = 166;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 425);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(678, 336);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 171;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ecoregion";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stream Type";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Drainage Area (sq. mi.)";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Bankfull Slope (ft/ft)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(140, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 18);
            this.button1.TabIndex = 164;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // mathExpressionPanel
            // 
            this.mathExpressionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mathExpressionPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mathExpressionPanel.ImageAlignment = Sinuosity.Forms.Custom_Controls.ImageAlignment.MiddleLeft;
            this.mathExpressionPanel.Location = new System.Drawing.Point(186, 398);
            this.mathExpressionPanel.Name = "mathExpressionPanel";
            this.mathExpressionPanel.Size = new System.Drawing.Size(174, 21);
            this.mathExpressionPanel.TabIndex = 170;
            this.mathExpressionPanel.Text = "D_(bkf)=12^(43)";
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(139, 20);
            this.label22.Margin = new System.Windows.Forms.Padding(1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 20);
            this.label22.TabIndex = 165;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 20);
            this.label21.Margin = new System.Windows.Forms.Padding(1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 20);
            this.label21.TabIndex = 163;
            this.label21.Text = "Relationship Data:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.BorderColor = System.Drawing.Color.Black;
            this.customGroupBox3.Controls.Add(this.label19);
            this.customGroupBox3.Controls.Add(this.tb_CitationURL);
            this.customGroupBox3.Controls.Add(this.label18);
            this.customGroupBox3.Controls.Add(this.tb_CitationGrantID);
            this.customGroupBox3.Controls.Add(this.label17);
            this.customGroupBox3.Controls.Add(this.tb_PreparedFor);
            this.customGroupBox3.Controls.Add(this.label16);
            this.customGroupBox3.Controls.Add(this.label13);
            this.customGroupBox3.Controls.Add(this.label15);
            this.customGroupBox3.Controls.Add(this.tb_CitationPublisher);
            this.customGroupBox3.Controls.Add(this.tb_CitationYear);
            this.customGroupBox3.Controls.Add(this.label12);
            this.customGroupBox3.Controls.Add(this.tb_CitationDay);
            this.customGroupBox3.Controls.Add(this.tb_CitationTitle);
            this.customGroupBox3.Controls.Add(this.tb_CitationMonth);
            this.customGroupBox3.Controls.Add(this.label6);
            this.customGroupBox3.Controls.Add(this.label14);
            this.customGroupBox3.Controls.Add(this.tb_CitationAuthor);
            this.customGroupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.customGroupBox3.Location = new System.Drawing.Point(271, 6);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(259, 196);
            this.customGroupBox3.TabIndex = 169;
            this.customGroupBox3.TabStop = false;
            this.customGroupBox3.Text = "Citation";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(4, 171);
            this.label19.Margin = new System.Windows.Forms.Padding(1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 21);
            this.label19.TabIndex = 184;
            this.label19.Text = "URL:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_CitationURL
            // 
            this.tb_CitationURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationURL.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_CitationURL.Location = new System.Drawing.Point(89, 171);
            this.tb_CitationURL.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationURL.Name = "tb_CitationURL";
            this.tb_CitationURL.Size = new System.Drawing.Size(166, 21);
            this.tb_CitationURL.TabIndex = 183;
            this.tb_CitationURL.Tag = "Citation_URL";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 149);
            this.label18.Margin = new System.Windows.Forms.Padding(1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 21);
            this.label18.TabIndex = 182;
            this.label18.Text = "Grant ID:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_CitationGrantID
            // 
            this.tb_CitationGrantID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationGrantID.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_CitationGrantID.Location = new System.Drawing.Point(89, 149);
            this.tb_CitationGrantID.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationGrantID.Name = "tb_CitationGrantID";
            this.tb_CitationGrantID.Size = new System.Drawing.Size(166, 21);
            this.tb_CitationGrantID.TabIndex = 181;
            this.tb_CitationGrantID.Tag = "Citation_GrantID";
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 127);
            this.label17.Margin = new System.Windows.Forms.Padding(1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 21);
            this.label17.TabIndex = 180;
            this.label17.Text = "Prepared for:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_PreparedFor
            // 
            this.tb_PreparedFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PreparedFor.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_PreparedFor.Location = new System.Drawing.Point(89, 127);
            this.tb_PreparedFor.Margin = new System.Windows.Forms.Padding(1);
            this.tb_PreparedFor.Name = "tb_PreparedFor";
            this.tb_PreparedFor.Size = new System.Drawing.Size(166, 21);
            this.tb_PreparedFor.TabIndex = 179;
            this.tb_PreparedFor.Tag = "Citation_PreparedFor";
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 64);
            this.label16.Margin = new System.Windows.Forms.Padding(1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 21);
            this.label16.TabIndex = 178;
            this.label16.Text = "Publisher:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 86);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 21);
            this.label13.TabIndex = 172;
            this.label13.Text = "Year";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(199, 86);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 21);
            this.label15.TabIndex = 176;
            this.label15.Text = "Day";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_CitationPublisher
            // 
            this.tb_CitationPublisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationPublisher.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_CitationPublisher.Location = new System.Drawing.Point(89, 64);
            this.tb_CitationPublisher.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationPublisher.Name = "tb_CitationPublisher";
            this.tb_CitationPublisher.Size = new System.Drawing.Size(166, 21);
            this.tb_CitationPublisher.TabIndex = 177;
            this.tb_CitationPublisher.Tag = "Citation_Publisher";
            // 
            // tb_CitationYear
            // 
            this.tb_CitationYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationYear.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_CitationYear.Location = new System.Drawing.Point(4, 106);
            this.tb_CitationYear.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationYear.Name = "tb_CitationYear";
            this.tb_CitationYear.Size = new System.Drawing.Size(84, 20);
            this.tb_CitationYear.TabIndex = 171;
            this.tb_CitationYear.Tag = "Citation_Year";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 21);
            this.label12.TabIndex = 170;
            this.label12.Text = "Title:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_CitationDay
            // 
            this.tb_CitationDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationDay.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_CitationDay.Location = new System.Drawing.Point(199, 106);
            this.tb_CitationDay.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationDay.Name = "tb_CitationDay";
            this.tb_CitationDay.Size = new System.Drawing.Size(56, 20);
            this.tb_CitationDay.TabIndex = 175;
            this.tb_CitationDay.Tag = "Citation_Day";
            // 
            // tb_CitationTitle
            // 
            this.tb_CitationTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationTitle.Font = new System.Drawing.Font("Arial", 9F);
            this.tb_CitationTitle.Location = new System.Drawing.Point(89, 42);
            this.tb_CitationTitle.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationTitle.Name = "tb_CitationTitle";
            this.tb_CitationTitle.Size = new System.Drawing.Size(166, 21);
            this.tb_CitationTitle.TabIndex = 169;
            this.tb_CitationTitle.Tag = "Citation_Title";
            // 
            // tb_CitationMonth
            // 
            this.tb_CitationMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationMonth.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_CitationMonth.Location = new System.Drawing.Point(89, 106);
            this.tb_CitationMonth.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationMonth.Name = "tb_CitationMonth";
            this.tb_CitationMonth.Size = new System.Drawing.Size(109, 20);
            this.tb_CitationMonth.TabIndex = 173;
            this.tb_CitationMonth.Tag = "Citation_Month";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 168;
            this.label6.Text = "Author:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(89, 86);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 21);
            this.label14.TabIndex = 174;
            this.label14.Text = "Month";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_CitationAuthor
            // 
            this.tb_CitationAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_CitationAuthor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_CitationAuthor.Location = new System.Drawing.Point(89, 20);
            this.tb_CitationAuthor.Margin = new System.Windows.Forms.Padding(1);
            this.tb_CitationAuthor.Name = "tb_CitationAuthor";
            this.tb_CitationAuthor.Size = new System.Drawing.Size(166, 21);
            this.tb_CitationAuthor.TabIndex = 167;
            this.tb_CitationAuthor.Tag = "Citation_Author";
            // 
            // valueInput_Variable_Length2
            // 
            this.valueInput_Variable_Length2.AllowedUnits.Add("ft");
            this.valueInput_Variable_Length2.AllowedUnits.Add("m");
            this.valueInput_Variable_Length2.AllowedUnits.Add("in");
            this.valueInput_Variable_Length2.ComboBoxWidth = 54;
            this.valueInput_Variable_Length2.DisplayPrecision = 3;
            this.valueInput_Variable_Length2.Gap = 1;
            this.valueInput_Variable_Length2.Location = new System.Drawing.Point(101, 60);
            this.valueInput_Variable_Length2.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Length2.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Length2.Name = "valueInput_Variable_Length2";
            this.valueInput_Variable_Length2.ReadOnly = false;
            this.valueInput_Variable_Length2.Size = new System.Drawing.Size(154, 21);
            this.valueInput_Variable_Length2.TabIndex = 196;
            this.valueInput_Variable_Length2.Text = "valueInput_Variable_Length2";
            this.valueInput_Variable_Length2.Unit = null;
            this.valueInput_Variable_Length2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // groupBox_Bordered3
            // 
            this.groupBox_Bordered3.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered3.Controls.Add(this.label20);
            this.groupBox_Bordered3.Controls.Add(this.btn_Path_ReferenceReachPath);
            this.groupBox_Bordered3.Controls.Add(this.btn_AddStream);
            this.groupBox_Bordered3.Controls.Add(this.btn_CopyStream);
            this.groupBox_Bordered3.Controls.Add(this.listView);
            this.groupBox_Bordered3.Controls.Add(this.btn_DeleteStream);
            this.groupBox_Bordered3.Controls.Add(this.tb_FilePath);
            this.groupBox_Bordered3.Controls.Add(this.groupBox_Bordered1);
            this.groupBox_Bordered3.Controls.Add(this.label9);
            this.groupBox_Bordered3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Bordered3.Location = new System.Drawing.Point(10, 13);
            this.groupBox_Bordered3.Name = "groupBox_Bordered3";
            this.groupBox_Bordered3.Size = new System.Drawing.Size(690, 771);
            this.groupBox_Bordered3.TabIndex = 164;
            this.groupBox_Bordered3.TabStop = false;
            this.groupBox_Bordered3.Text = "Filter";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 123;
            this.label11.Text = "Drainage Area:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vi_Design_UpstreamDrainageArea
            // 
            this.vi_Design_UpstreamDrainageArea.ComboBoxWidth = 54;
            this.vi_Design_UpstreamDrainageArea.DisplayPrecision = 3;
            this.vi_Design_UpstreamDrainageArea.Gap = 1;
            this.vi_Design_UpstreamDrainageArea.Location = new System.Drawing.Point(101, 19);
            this.vi_Design_UpstreamDrainageArea.MaximumSize = new System.Drawing.Size(500, 21);
            this.vi_Design_UpstreamDrainageArea.MinimumSize = new System.Drawing.Size(98, 21);
            this.vi_Design_UpstreamDrainageArea.Name = "vi_Design_UpstreamDrainageArea";
            this.vi_Design_UpstreamDrainageArea.ReadOnly = false;
            this.vi_Design_UpstreamDrainageArea.Size = new System.Drawing.Size(154, 21);
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
            // groupBox_Bordered4
            // 
            this.groupBox_Bordered4.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered4.Controls.Add(this.subscriptLabel2);
            this.groupBox_Bordered4.Controls.Add(this.label_Subscript2);
            this.groupBox_Bordered4.Controls.Add(this.label_Subscript4);
            this.groupBox_Bordered4.Controls.Add(this.valueInput_Variable_Area2);
            this.groupBox_Bordered4.Controls.Add(this.label_Subscript1);
            this.groupBox_Bordered4.Controls.Add(this.valueInput_Variable_Length1);
            this.groupBox_Bordered4.Controls.Add(this.valueInput_Variable_Length2);
            this.groupBox_Bordered4.Controls.Add(this.valueInput_Variable_Length3);
            this.groupBox_Bordered4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox_Bordered4.Location = new System.Drawing.Point(6, 139);
            this.groupBox_Bordered4.Name = "groupBox_Bordered4";
            this.groupBox_Bordered4.Size = new System.Drawing.Size(259, 105);
            this.groupBox_Bordered4.TabIndex = 185;
            this.groupBox_Bordered4.TabStop = false;
            this.groupBox_Bordered4.Text = "Channel Dimensions";
            // 
            // subscriptLabel2
            // 
            this.subscriptLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subscriptLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscriptLabel2.Location = new System.Drawing.Point(4, 18);
            this.subscriptLabel2.Name = "subscriptLabel2";
            this.subscriptLabel2.Size = new System.Drawing.Size(95, 20);
            this.subscriptLabel2.SubscriptHorizontalOffset = -3F;
            this.subscriptLabel2.SubscriptText = "riff";
            this.subscriptLabel2.TabIndex = 187;
            this.subscriptLabel2.Text = "A";
            this.subscriptLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_Subscript2
            // 
            this.label_Subscript2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript2.Location = new System.Drawing.Point(4, 81);
            this.label_Subscript2.Name = "label_Subscript2";
            this.label_Subscript2.Size = new System.Drawing.Size(95, 20);
            this.label_Subscript2.SubscriptHorizontalOffset = -3F;
            this.label_Subscript2.SubscriptText = "riff-max";
            this.label_Subscript2.TabIndex = 190;
            this.label_Subscript2.Text = "d";
            this.label_Subscript2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_Subscript4
            // 
            this.label_Subscript4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript4.Location = new System.Drawing.Point(4, 39);
            this.label_Subscript4.Name = "label_Subscript4";
            this.label_Subscript4.Size = new System.Drawing.Size(95, 20);
            this.label_Subscript4.SubscriptHorizontalOffset = -3F;
            this.label_Subscript4.SubscriptText = "riff-top";
            this.label_Subscript4.TabIndex = 191;
            this.label_Subscript4.Text = "W";
            this.label_Subscript4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // valueInput_Variable_Area2
            // 
            this.valueInput_Variable_Area2.ComboBoxWidth = 54;
            this.valueInput_Variable_Area2.DisplayPrecision = 3;
            this.valueInput_Variable_Area2.Gap = 1;
            this.valueInput_Variable_Area2.Location = new System.Drawing.Point(101, 18);
            this.valueInput_Variable_Area2.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Area2.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Area2.Name = "valueInput_Variable_Area2";
            this.valueInput_Variable_Area2.ReadOnly = false;
            this.valueInput_Variable_Area2.Size = new System.Drawing.Size(154, 21);
            this.valueInput_Variable_Area2.TabIndex = 194;
            this.valueInput_Variable_Area2.Tag = "/Properties/Design/UpstreamDrainageArea";
            this.valueInput_Variable_Area2.Text = "valueInput_Variable_Area1";
            this.valueInput_Variable_Area2.Unit = null;
            this.valueInput_Variable_Area2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label_Subscript1
            // 
            this.label_Subscript1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript1.Location = new System.Drawing.Point(4, 60);
            this.label_Subscript1.Name = "label_Subscript1";
            this.label_Subscript1.Size = new System.Drawing.Size(95, 20);
            this.label_Subscript1.SubscriptHorizontalOffset = -3F;
            this.label_Subscript1.SubscriptText = "riff-avg";
            this.label_Subscript1.TabIndex = 189;
            this.label_Subscript1.Text = "d";
            this.label_Subscript1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // valueInput_Variable_Length1
            // 
            this.valueInput_Variable_Length1.AllowedUnits.Add("ft");
            this.valueInput_Variable_Length1.AllowedUnits.Add("m");
            this.valueInput_Variable_Length1.AllowedUnits.Add("in");
            this.valueInput_Variable_Length1.ComboBoxWidth = 54;
            this.valueInput_Variable_Length1.DisplayPrecision = 3;
            this.valueInput_Variable_Length1.Gap = 1;
            this.valueInput_Variable_Length1.Location = new System.Drawing.Point(101, 39);
            this.valueInput_Variable_Length1.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Length1.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Length1.Name = "valueInput_Variable_Length1";
            this.valueInput_Variable_Length1.ReadOnly = false;
            this.valueInput_Variable_Length1.Size = new System.Drawing.Size(154, 21);
            this.valueInput_Variable_Length1.TabIndex = 195;
            this.valueInput_Variable_Length1.Text = "valueInput_Variable_Length1";
            this.valueInput_Variable_Length1.Unit = null;
            this.valueInput_Variable_Length1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Variable_Length3
            // 
            this.valueInput_Variable_Length3.AllowedUnits.Add("ft");
            this.valueInput_Variable_Length3.AllowedUnits.Add("m");
            this.valueInput_Variable_Length3.AllowedUnits.Add("in");
            this.valueInput_Variable_Length3.ComboBoxWidth = 54;
            this.valueInput_Variable_Length3.DisplayPrecision = 3;
            this.valueInput_Variable_Length3.Gap = 1;
            this.valueInput_Variable_Length3.Location = new System.Drawing.Point(101, 81);
            this.valueInput_Variable_Length3.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Length3.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Length3.Name = "valueInput_Variable_Length3";
            this.valueInput_Variable_Length3.ReadOnly = false;
            this.valueInput_Variable_Length3.Size = new System.Drawing.Size(154, 21);
            this.valueInput_Variable_Length3.TabIndex = 197;
            this.valueInput_Variable_Length3.Text = "valueInput_Variable_Length3";
            this.valueInput_Variable_Length3.Unit = null;
            this.valueInput_Variable_Length3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // textBox18
            // 
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Arial", 8.25F);
            this.textBox18.Location = new System.Drawing.Point(101, 63);
            this.textBox18.Margin = new System.Windows.Forms.Padding(1);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(154, 20);
            this.textBox18.TabIndex = 198;
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(4, 63);
            this.label30.Margin = new System.Windows.Forms.Padding(1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(95, 20);
            this.label30.TabIndex = 199;
            this.label30.Text = "HUC:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(4, 41);
            this.label31.Margin = new System.Windows.Forms.Padding(1);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(95, 20);
            this.label31.TabIndex = 200;
            this.label31.Text = "Ecoregion:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox19
            // 
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.Font = new System.Drawing.Font("Arial", 8.25F);
            this.textBox19.Location = new System.Drawing.Point(101, 41);
            this.textBox19.Margin = new System.Windows.Forms.Padding(1);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(154, 20);
            this.textBox19.TabIndex = 201;
            // 
            // label_Subscript3
            // 
            this.label_Subscript3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript3.Location = new System.Drawing.Point(4, 107);
            this.label_Subscript3.Name = "label_Subscript3";
            this.label_Subscript3.Size = new System.Drawing.Size(95, 20);
            this.label_Subscript3.SubscriptHorizontalOffset = -3F;
            this.label_Subscript3.SubscriptText = "bkf";
            this.label_Subscript3.TabIndex = 202;
            this.label_Subscript3.Text = "S";
            this.label_Subscript3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(4, 85);
            this.label32.Margin = new System.Windows.Forms.Padding(1);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(95, 20);
            this.label32.TabIndex = 204;
            this.label32.Text = "Stream Type";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Cb_StreamType.Location = new System.Drawing.Point(101, 85);
            this.Cb_StreamType.Name = "Cb_StreamType";
            this.Cb_StreamType.Size = new System.Drawing.Size(154, 20);
            this.Cb_StreamType.TabIndex = 203;
            // 
            // valueInput_Variable_Slope2
            // 
            this.valueInput_Variable_Slope2.ComboBoxWidth = 54;
            this.valueInput_Variable_Slope2.DisplayPrecision = 3;
            this.valueInput_Variable_Slope2.Gap = 1;
            this.valueInput_Variable_Slope2.Location = new System.Drawing.Point(101, 107);
            this.valueInput_Variable_Slope2.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Slope2.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Slope2.Name = "valueInput_Variable_Slope2";
            this.valueInput_Variable_Slope2.ReadOnly = false;
            this.valueInput_Variable_Slope2.Size = new System.Drawing.Size(154, 21);
            this.valueInput_Variable_Slope2.TabIndex = 205;
            this.valueInput_Variable_Slope2.Text = "valueInput_Variable_Slope2";
            this.valueInput_Variable_Slope2.Unit = null;
            this.valueInput_Variable_Slope2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // valueInput_Variable_Length4
            // 
            this.valueInput_Variable_Length4.AllowedUnits.Add("ft");
            this.valueInput_Variable_Length4.AllowedUnits.Add("m");
            this.valueInput_Variable_Length4.AllowedUnits.Add("in");
            this.valueInput_Variable_Length4.ComboBoxWidth = 44;
            this.valueInput_Variable_Length4.DisplayPrecision = 3;
            this.valueInput_Variable_Length4.Gap = 2;
            this.valueInput_Variable_Length4.Location = new System.Drawing.Point(178, 488);
            this.valueInput_Variable_Length4.MaximumSize = new System.Drawing.Size(500, 21);
            this.valueInput_Variable_Length4.MinimumSize = new System.Drawing.Size(98, 21);
            this.valueInput_Variable_Length4.Name = "valueInput_Variable_Length4";
            this.valueInput_Variable_Length4.ReadOnly = false;
            this.valueInput_Variable_Length4.Size = new System.Drawing.Size(121, 21);
            this.valueInput_Variable_Length4.TabIndex = 207;
            this.valueInput_Variable_Length4.Text = "valueInput_Variable_Length4";
            this.valueInput_Variable_Length4.Unit = null;
            this.valueInput_Variable_Length4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label_Subscript5
            // 
            this.label_Subscript5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript5.Location = new System.Drawing.Point(94, 488);
            this.label_Subscript5.Name = "label_Subscript5";
            this.label_Subscript5.Size = new System.Drawing.Size(82, 20);
            this.label_Subscript5.SubscriptHorizontalOffset = -3F;
            this.label_Subscript5.SubscriptText = "fpa";
            this.label_Subscript5.TabIndex = 206;
            this.label_Subscript5.Text = "W";
            this.label_Subscript5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Subscript6
            // 
            this.label_Subscript6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Subscript6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subscript6.Location = new System.Drawing.Point(95, 455);
            this.label_Subscript6.Name = "label_Subscript6";
            this.label_Subscript6.Size = new System.Drawing.Size(60, 20);
            this.label_Subscript6.SubscriptHorizontalOffset = -3F;
            this.label_Subscript6.SubscriptText = "riff";
            this.label_Subscript6.TabIndex = 208;
            this.label_Subscript6.Text = "[W/d]";
            this.label_Subscript6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_Bordered5
            // 
            this.groupBox_Bordered5.BorderColor = System.Drawing.Color.Black;
            this.groupBox_Bordered5.Controls.Add(this.label11);
            this.groupBox_Bordered5.Controls.Add(this.vi_Design_UpstreamDrainageArea);
            this.groupBox_Bordered5.Controls.Add(this.textBox18);
            this.groupBox_Bordered5.Controls.Add(this.label30);
            this.groupBox_Bordered5.Controls.Add(this.valueInput_Variable_Slope2);
            this.groupBox_Bordered5.Controls.Add(this.label31);
            this.groupBox_Bordered5.Controls.Add(this.textBox19);
            this.groupBox_Bordered5.Controls.Add(this.label_Subscript3);
            this.groupBox_Bordered5.Controls.Add(this.label32);
            this.groupBox_Bordered5.Controls.Add(this.Cb_StreamType);
            this.groupBox_Bordered5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox_Bordered5.Location = new System.Drawing.Point(6, 6);
            this.groupBox_Bordered5.Name = "groupBox_Bordered5";
            this.groupBox_Bordered5.Size = new System.Drawing.Size(259, 132);
            this.groupBox_Bordered5.TabIndex = 198;
            this.groupBox_Bordered5.TabStop = false;
            this.groupBox_Bordered5.Text = "Stream Properties";
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.textBox9.Location = new System.Drawing.Point(157, 455);
            this.textBox9.Margin = new System.Windows.Forms.Padding(1);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(121, 20);
            this.textBox9.TabIndex = 206;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(706, 13);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(544, 771);
            this.TabControl.TabIndex = 209;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.mathExpressionPanel1);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.valueInput_Variable_Length4);
            this.tabPage1.Controls.Add(this.textBox9);
            this.tabPage1.Controls.Add(this.label_Subscript5);
            this.tabPage1.Controls.Add(this.customGroupBox3);
            this.tabPage1.Controls.Add(this.groupBox_Bordered5);
            this.tabPage1.Controls.Add(this.label_Subscript6);
            this.tabPage1.Controls.Add(this.groupBox_Bordered4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 742);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataTab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(10, 329);
            this.label25.Margin = new System.Windows.Forms.Padding(1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(95, 20);
            this.label25.TabIndex = 211;
            this.label25.Text = "Sinuosity:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(10, 307);
            this.label24.Margin = new System.Windows.Forms.Padding(1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 20);
            this.label24.TabIndex = 210;
            this.label24.Text = "Width to Depth:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mathExpressionPanel1
            // 
            this.mathExpressionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mathExpressionPanel1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mathExpressionPanel1.ImageAlignment = Sinuosity.Forms.Custom_Controls.ImageAlignment.MiddleRight;
            this.mathExpressionPanel1.Location = new System.Drawing.Point(311, 266);
            this.mathExpressionPanel1.Name = "mathExpressionPanel1";
            this.mathExpressionPanel1.Size = new System.Drawing.Size(174, 21);
            this.mathExpressionPanel1.TabIndex = 171;
            this.mathExpressionPanel1.Text = "[W_(riff-top)/d_(riff-avg)]: ";
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(10, 285);
            this.label23.Margin = new System.Windows.Forms.Padding(1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 20);
            this.label23.TabIndex = 209;
            this.label23.Text = "Entrenchment:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 742);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Images";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ReferenceReachBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2155, 1033);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.groupBox_Bordered3);
            this.Controls.Add(this.groupBox_Bordered2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReferenceReachBrowser";
            this.Text = "ReferenceReachEditor";
            this.groupBox_Bordered1.ResumeLayout(false);
            this.groupBox_Bordered1.PerformLayout();
            this.groupBox_Bordered2.ResumeLayout(false);
            this.groupBox_Bordered2.PerformLayout();
            this.customGroupBox3.ResumeLayout(false);
            this.customGroupBox3.PerformLayout();
            this.groupBox_Bordered3.ResumeLayout(false);
            this.groupBox_Bordered3.PerformLayout();
            this.groupBox_Bordered4.ResumeLayout(false);
            this.groupBox_Bordered5.ResumeLayout(false);
            this.groupBox_Bordered5.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView;
        private ColumnHeader nameHeader;
        private ColumnHeader ecoregionHeader;
        private ColumnHeader streamTypeHeader;
        private ColumnHeader drainageAreaHeader;
        private ColumnHeader slopeHeader;
        private Button btn_CopyStream;
        private Button btn_DeleteStream;
        private Button btn_AddStream;
        private TextBox tb_FilePath;
        private Button btn_Path_ReferenceReachPath;
        private Label label9;
        private Label label20;
        private TextBox tb_NameFilter;
        private TextBox tb_EcoregionFilter;
        private TextBox tb_StreamTypeFilter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Custom_Controls.ValueInput_Variable_Area vi_Filter_DrainageAreaMin;
        private Label label4;
        private Custom_Controls.ValueInput_Variable_Slope vi_Filter_StreamSlopeMin;
        private Label label5;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label7;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered2;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered3;
        private Label label6;
        private TextBox tb_CitationAuthor;
        private Custom_Controls.GroupBox_Bordered customGroupBox3;
        private Label label12;
        private TextBox tb_CitationTitle;
        private Label label11;
        private Custom_Controls.ValueInput_Variable_Area vi_Design_UpstreamDrainageArea;
        private Label label19;
        private TextBox tb_CitationURL;
        private Label label18;
        private TextBox tb_CitationGrantID;
        private Label label17;
        private TextBox tb_PreparedFor;
        private Label label16;
        private TextBox tb_CitationPublisher;
        private Label label15;
        private TextBox tb_CitationDay;
        private Label label14;
        private TextBox tb_CitationMonth;
        private Label label13;
        private TextBox tb_CitationYear;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered4;
        private Custom_Controls.Label_Subscript label_Subscript4;
        private Custom_Controls.Label_Subscript label_Subscript2;
        private Custom_Controls.Label_Subscript label_Subscript1;
        private Custom_Controls.Label_Subscript subscriptLabel2;
        private Custom_Controls.ValueInput_Variable_Area valueInput_Variable_Area2;
        private Custom_Controls.ValueInput_Variable_Length valueInput_Variable_Length1;
        private Custom_Controls.ValueInput_Variable_Length valueInput_Variable_Length2;
        private Custom_Controls.ValueInput_Variable_Length valueInput_Variable_Length3;
        private TextBox textBox18;
        private Label label30;
        private Label label31;
        private TextBox textBox19;
        private Custom_Controls.Label_Subscript label_Subscript3;
        private Label label32;
        private ComboBox Cb_StreamType;
        private Custom_Controls.ValueInput_Variable_Slope valueInput_Variable_Slope2;
        private Custom_Controls.ValueInput_Variable_Length valueInput_Variable_Length4;
        private Custom_Controls.Label_Subscript label_Subscript5;
        private Custom_Controls.Label_Subscript label_Subscript6;
        private Custom_Controls.MathExpressionPanel mathExpressionPanel;
        private Custom_Controls.GroupBox_Bordered groupBox_Bordered5;
        private TextBox textBox9;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Custom_Controls.ValueInput_Variable_Slope vi_Filter_StreamSlopeMax;
        private Custom_Controls.ValueInput_Variable_Area vi_Filter_DrainageAreaMax;
        private Label label10;
        private Label label8;
        private TextBox textBox10;
        private Button button1;
        private Label label22;
        private Label label21;
        private TabControl TabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label25;
        private Label label24;
        private Custom_Controls.MathExpressionPanel mathExpressionPanel1;
        private Label label23;
    }
}