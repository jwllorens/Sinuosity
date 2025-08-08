using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Sinuosity.Forms.User_Controls
{
    partial class StreamEditor
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
            this.gb_Main = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_StreamAlternateName = new System.Windows.Forms.TextBox();
            this.gb_Reaches = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_MoveDown = new System.Windows.Forms.Button();
            this.Btn_MoveUp = new System.Windows.Forms.Button();
            this.btn_GoToReach = new System.Windows.Forms.Button();
            this.btn_DeleteReach = new System.Windows.Forms.Button();
            this.lb_ReachList = new System.Windows.Forms.ListBox();
            this.btn_AddReach = new System.Windows.Forms.Button();
            this.verticalLabel3 = new Sinuosity.Forms.Custom_Controls.Label_Vertical();
            this.verticalLabel2 = new Sinuosity.Forms.Custom_Controls.Label_Vertical();
            this.verticalLabel1 = new Sinuosity.Forms.Custom_Controls.Label_Vertical();
            this.lbl2 = new System.Windows.Forms.Label();
            this.gb_Description = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.Tb_StreamID = new System.Windows.Forms.TextBox();
            this.gb_GeographicProperties = new Sinuosity.Forms.Custom_Controls.GroupBox_Bordered();
            this.Btn_EditNotes = new System.Windows.Forms.Button();
            this.Btn_Back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gb_Main.SuspendLayout();
            this.gb_Reaches.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Main
            // 
            this.gb_Main.Controls.Add(this.tb_StreamAlternateName);
            this.gb_Main.Controls.Add(this.label2);
            this.gb_Main.Controls.Add(this.gb_Reaches);
            this.gb_Main.Controls.Add(this.gb_Description);
            this.gb_Main.Controls.Add(this.Tb_StreamID);
            this.gb_Main.Controls.Add(this.gb_GeographicProperties);
            this.gb_Main.Controls.Add(this.lbl2);
            this.gb_Main.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Main.Location = new System.Drawing.Point(3, 24);
            this.gb_Main.Name = "gb_Main";
            this.gb_Main.Size = new System.Drawing.Size(487, 497);
            this.gb_Main.TabIndex = 77;
            this.gb_Main.TabStop = false;
            this.gb_Main.Text = "Stream Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(129, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 83;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_StreamAlternateName
            // 
            this.tb_StreamAlternateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StreamAlternateName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.tb_StreamAlternateName.Location = new System.Drawing.Point(169, 20);
            this.tb_StreamAlternateName.Margin = new System.Windows.Forms.Padding(1);
            this.tb_StreamAlternateName.Name = "tb_StreamAlternateName";
            this.tb_StreamAlternateName.Size = new System.Drawing.Size(308, 20);
            this.tb_StreamAlternateName.TabIndex = 82;
            this.tb_StreamAlternateName.Tag = "/Properties/Name";
            this.toolTip.SetToolTip(this.tb_StreamAlternateName, "Stream name");
            // 
            // gb_Reaches
            // 
            this.gb_Reaches.BorderColor = System.Drawing.Color.Black;
            this.gb_Reaches.Controls.Add(this.checkBox1);
            this.gb_Reaches.Controls.Add(this.button1);
            this.gb_Reaches.Controls.Add(this.Btn_MoveDown);
            this.gb_Reaches.Controls.Add(this.Btn_MoveUp);
            this.gb_Reaches.Controls.Add(this.btn_GoToReach);
            this.gb_Reaches.Controls.Add(this.btn_DeleteReach);
            this.gb_Reaches.Controls.Add(this.lb_ReachList);
            this.gb_Reaches.Controls.Add(this.btn_AddReach);
            this.gb_Reaches.Controls.Add(this.verticalLabel3);
            this.gb_Reaches.Controls.Add(this.verticalLabel2);
            this.gb_Reaches.Controls.Add(this.verticalLabel1);
            this.gb_Reaches.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gb_Reaches.Location = new System.Drawing.Point(371, 42);
            this.gb_Reaches.Name = "gb_Reaches";
            this.gb_Reaches.Size = new System.Drawing.Size(111, 200);
            this.gb_Reaches.TabIndex = 79;
            this.gb_Reaches.TabStop = false;
            this.gb_Reaches.Text = "Reaches";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(90, 97);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 115;
            this.toolTip.SetToolTip(this.checkBox1, "Move all child data when moving reach");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(86, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 21);
            this.button1.TabIndex = 75;
            this.toolTip.SetToolTip(this.button1, "Split reach");
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Btn_MoveDown
            // 
            this.Btn_MoveDown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_MoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_MoveDown.Location = new System.Drawing.Point(86, 133);
            this.Btn_MoveDown.Margin = new System.Windows.Forms.Padding(1);
            this.Btn_MoveDown.Name = "Btn_MoveDown";
            this.Btn_MoveDown.Size = new System.Drawing.Size(21, 21);
            this.Btn_MoveDown.TabIndex = 74;
            this.toolTip.SetToolTip(this.Btn_MoveDown, "Change reach order (move down)");
            this.Btn_MoveDown.UseVisualStyleBackColor = false;
            // 
            // Btn_MoveUp
            // 
            this.Btn_MoveUp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_MoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_MoveUp.Location = new System.Drawing.Point(86, 111);
            this.Btn_MoveUp.Margin = new System.Windows.Forms.Padding(1);
            this.Btn_MoveUp.Name = "Btn_MoveUp";
            this.Btn_MoveUp.Size = new System.Drawing.Size(21, 21);
            this.Btn_MoveUp.TabIndex = 73;
            this.toolTip.SetToolTip(this.Btn_MoveUp, "Change reach order (move up)");
            this.Btn_MoveUp.UseVisualStyleBackColor = false;
            // 
            // btn_GoToReach
            // 
            this.btn_GoToReach.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_GoToReach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_GoToReach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GoToReach.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btn_GoToReach.Location = new System.Drawing.Point(86, 168);
            this.btn_GoToReach.Margin = new System.Windows.Forms.Padding(1);
            this.btn_GoToReach.Name = "btn_GoToReach";
            this.btn_GoToReach.Size = new System.Drawing.Size(21, 21);
            this.btn_GoToReach.TabIndex = 69;
            this.toolTip.SetToolTip(this.btn_GoToReach, "Edit reach");
            this.btn_GoToReach.UseVisualStyleBackColor = false;
            // 
            // btn_DeleteReach
            // 
            this.btn_DeleteReach.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DeleteReach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DeleteReach.Location = new System.Drawing.Point(86, 61);
            this.btn_DeleteReach.Margin = new System.Windows.Forms.Padding(1);
            this.btn_DeleteReach.Name = "btn_DeleteReach";
            this.btn_DeleteReach.Size = new System.Drawing.Size(21, 21);
            this.btn_DeleteReach.TabIndex = 70;
            this.toolTip.SetToolTip(this.btn_DeleteReach, "Delete reach");
            this.btn_DeleteReach.UseVisualStyleBackColor = false;
            // 
            // lb_ReachList
            // 
            this.lb_ReachList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ReachList.FormattingEnabled = true;
            this.lb_ReachList.ItemHeight = 14;
            this.lb_ReachList.Location = new System.Drawing.Point(12, 16);
            this.lb_ReachList.Margin = new System.Windows.Forms.Padding(1);
            this.lb_ReachList.Name = "lb_ReachList";
            this.lb_ReachList.Size = new System.Drawing.Size(72, 172);
            this.lb_ReachList.Sorted = true;
            this.lb_ReachList.TabIndex = 68;
            this.lb_ReachList.Tag = "/Reaches";
            // 
            // btn_AddReach
            // 
            this.btn_AddReach.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AddReach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddReach.Location = new System.Drawing.Point(86, 16);
            this.btn_AddReach.Margin = new System.Windows.Forms.Padding(1);
            this.btn_AddReach.Name = "btn_AddReach";
            this.btn_AddReach.Size = new System.Drawing.Size(21, 21);
            this.btn_AddReach.TabIndex = 28;
            this.toolTip.SetToolTip(this.btn_AddReach, "Add reach");
            this.btn_AddReach.UseVisualStyleBackColor = false;
            // 
            // verticalLabel3
            // 
            this.verticalLabel3.Flip180 = true;
            this.verticalLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel3.Location = new System.Drawing.Point(1, 75);
            this.verticalLabel3.Name = "verticalLabel3";
            this.verticalLabel3.Size = new System.Drawing.Size(12, 44);
            this.verticalLabel3.TabIndex = 118;
            this.verticalLabel3.Text = "←→";
            this.verticalLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verticalLabel2
            // 
            this.verticalLabel2.Flip180 = true;
            this.verticalLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel2.Location = new System.Drawing.Point(1, 119);
            this.verticalLabel2.Name = "verticalLabel2";
            this.verticalLabel2.Size = new System.Drawing.Size(12, 70);
            this.verticalLabel2.TabIndex = 117;
            this.verticalLabel2.Text = "downstream";
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.Flip180 = true;
            this.verticalLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel1.Location = new System.Drawing.Point(1, 16);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.Size = new System.Drawing.Size(12, 59);
            this.verticalLabel1.TabIndex = 116;
            this.verticalLabel1.Text = "upstream";
            this.verticalLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(5, 23);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(63, 14);
            this.lbl2.TabIndex = 64;
            this.lbl2.Text = "Stream ID:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_Description
            // 
            this.gb_Description.BorderColor = System.Drawing.Color.Black;
            this.gb_Description.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gb_Description.Location = new System.Drawing.Point(5, 247);
            this.gb_Description.Name = "gb_Description";
            this.gb_Description.Size = new System.Drawing.Size(477, 244);
            this.gb_Description.TabIndex = 78;
            this.gb_Description.TabStop = false;
            this.gb_Description.Text = "Placeholder Text";
            // 
            // Tb_StreamID
            // 
            this.Tb_StreamID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tb_StreamID.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Tb_StreamID.Location = new System.Drawing.Point(67, 20);
            this.Tb_StreamID.Margin = new System.Windows.Forms.Padding(1);
            this.Tb_StreamID.Name = "Tb_StreamID";
            this.Tb_StreamID.Size = new System.Drawing.Size(59, 20);
            this.Tb_StreamID.TabIndex = 63;
            this.Tb_StreamID.Tag = "/";
            this.toolTip.SetToolTip(this.Tb_StreamID, "Stream ID");
            // 
            // gb_GeographicProperties
            // 
            this.gb_GeographicProperties.BorderColor = System.Drawing.Color.Black;
            this.gb_GeographicProperties.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_GeographicProperties.Location = new System.Drawing.Point(5, 42);
            this.gb_GeographicProperties.Name = "gb_GeographicProperties";
            this.gb_GeographicProperties.Size = new System.Drawing.Size(360, 200);
            this.gb_GeographicProperties.TabIndex = 77;
            this.gb_GeographicProperties.TabStop = false;
            this.gb_GeographicProperties.Text = "Placeholder Text";
            // 
            // Btn_EditNotes
            // 
            this.Btn_EditNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_EditNotes.Location = new System.Drawing.Point(461, 1);
            this.Btn_EditNotes.Name = "Btn_EditNotes";
            this.Btn_EditNotes.Size = new System.Drawing.Size(21, 21);
            this.Btn_EditNotes.TabIndex = 114;
            this.Btn_EditNotes.Tag = "/Properties/Notes";
            this.toolTip.SetToolTip(this.Btn_EditNotes, "View or edit notes");
            this.Btn_EditNotes.UseVisualStyleBackColor = true;
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Back.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_Back.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Btn_Back.Location = new System.Drawing.Point(3, 1);
            this.Btn_Back.Margin = new System.Windows.Forms.Padding(1);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(21, 21);
            this.Btn_Back.TabIndex = 75;
            this.toolTip.SetToolTip(this.Btn_Back, "Back one level");
            this.Btn_Back.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(23, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Back to Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StreamEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_EditNotes);
            this.Controls.Add(this.Btn_Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_Main);
            this.Name = "StreamEditor";
            this.Size = new System.Drawing.Size(493, 523);
            this.gb_Main.ResumeLayout(false);
            this.gb_Main.PerformLayout();
            this.gb_Reaches.ResumeLayout(false);
            this.gb_Reaches.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gb_Main;
        private Custom_Controls.GroupBox_Bordered gb_Reaches;
        private Button btn_GoToReach;
        private Button btn_DeleteReach;
        private ListBox lb_ReachList;
        private Button btn_AddReach;
        private Label lbl2;
        private Custom_Controls.GroupBox_Bordered gb_Description;
        private TextBox Tb_StreamID;
        private Custom_Controls.GroupBox_Bordered gb_GeographicProperties;
        private Label label2;
        private TextBox tb_StreamAlternateName;
        private Button Btn_MoveDown;
        private Button Btn_MoveUp;
        private Button Btn_Back;
        private Label label1;
        private Button Btn_EditNotes;
        private Button button1;
        private ToolTip toolTip;
        private CheckBox checkBox1;
        private Custom_Controls.Label_Vertical verticalLabel1;
        private Custom_Controls.Label_Vertical verticalLabel2;
        private Custom_Controls.Label_Vertical verticalLabel3;
    }
}
