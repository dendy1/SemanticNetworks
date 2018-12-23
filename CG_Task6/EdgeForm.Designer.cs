namespace CG_Task6
{
    partial class EdgeForm
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
            this.components = new System.ComponentModel.Container();
            this.RelationsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FontColorBTN = new System.Windows.Forms.Button();
            this.FontBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedEdgePenBTN = new System.Windows.Forms.Button();
            this.EdgePenBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MarkerHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.MarkerWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ArrowHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.ArrowWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.ArrowTailComboBox = new System.Windows.Forms.ComboBox();
            this.ArrowHeadComboBox = new System.Windows.Forms.ComboBox();
            this.ShapeComboBox = new System.Windows.Forms.ComboBox();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerHeightNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerWidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowHeightNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowWidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RelationsListBox
            // 
            this.RelationsListBox.FormattingEnabled = true;
            this.RelationsListBox.Location = new System.Drawing.Point(12, 12);
            this.RelationsListBox.Name = "RelationsListBox";
            this.RelationsListBox.Size = new System.Drawing.Size(201, 82);
            this.RelationsListBox.TabIndex = 0;
            this.RelationsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RelationsListBox_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FontColorBTN);
            this.groupBox1.Controls.Add(this.FontBTN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SelectedEdgePenBTN);
            this.groupBox1.Controls.Add(this.EdgePenBTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MarkerHeightNUD);
            this.groupBox1.Controls.Add(this.MarkerWidthNUD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ArrowHeightNUD);
            this.groupBox1.Controls.Add(this.ArrowWidthNUD);
            this.groupBox1.Controls.Add(this.ArrowTailComboBox);
            this.groupBox1.Controls.Add(this.ArrowHeadComboBox);
            this.groupBox1.Controls.Add(this.ShapeComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 320);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки визуализации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Цвет шрифта";
            // 
            // FontColorBTN
            // 
            this.FontColorBTN.BackColor = System.Drawing.Color.Black;
            this.FontColorBTN.Location = new System.Drawing.Point(90, 248);
            this.FontColorBTN.Name = "FontColorBTN";
            this.FontColorBTN.Size = new System.Drawing.Size(75, 46);
            this.FontColorBTN.TabIndex = 3;
            this.FontColorBTN.UseVisualStyleBackColor = false;
            this.FontColorBTN.Click += new System.EventHandler(this.FontColorBTN_Click);
            // 
            // FontBTN
            // 
            this.FontBTN.Location = new System.Drawing.Point(6, 248);
            this.FontBTN.Name = "FontBTN";
            this.FontBTN.Size = new System.Drawing.Size(75, 46);
            this.FontBTN.TabIndex = 4;
            this.FontBTN.Text = "Шрифт надписи";
            this.FontBTN.UseVisualStyleBackColor = true;
            this.FontBTN.Click += new System.EventHandler(this.FontBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Тип пера для \r\nвыбранного ребра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип пера для ребра";
            // 
            // SelectedEdgePenBTN
            // 
            this.SelectedEdgePenBTN.Location = new System.Drawing.Point(6, 209);
            this.SelectedEdgePenBTN.Name = "SelectedEdgePenBTN";
            this.SelectedEdgePenBTN.Size = new System.Drawing.Size(75, 23);
            this.SelectedEdgePenBTN.TabIndex = 9;
            this.SelectedEdgePenBTN.UseVisualStyleBackColor = true;
            this.SelectedEdgePenBTN.Click += new System.EventHandler(this.SelectedEdgePenBTN_Click);
            // 
            // EdgePenBTN
            // 
            this.EdgePenBTN.Location = new System.Drawing.Point(6, 180);
            this.EdgePenBTN.Name = "EdgePenBTN";
            this.EdgePenBTN.Size = new System.Drawing.Size(75, 23);
            this.EdgePenBTN.TabIndex = 3;
            this.EdgePenBTN.UseVisualStyleBackColor = true;
            this.EdgePenBTN.Click += new System.EventHandler(this.EdgePenBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ширина и длина маркеров";
            // 
            // MarkerHeightNUD
            // 
            this.MarkerHeightNUD.Location = new System.Drawing.Point(109, 154);
            this.MarkerHeightNUD.Name = "MarkerHeightNUD";
            this.MarkerHeightNUD.Size = new System.Drawing.Size(56, 20);
            this.MarkerHeightNUD.TabIndex = 7;
            this.MarkerHeightNUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // MarkerWidthNUD
            // 
            this.MarkerWidthNUD.Location = new System.Drawing.Point(36, 154);
            this.MarkerWidthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MarkerWidthNUD.Name = "MarkerWidthNUD";
            this.MarkerWidthNUD.Size = new System.Drawing.Size(56, 20);
            this.MarkerWidthNUD.TabIndex = 6;
            this.MarkerWidthNUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ширина и длина стрелок";
            // 
            // ArrowHeightNUD
            // 
            this.ArrowHeightNUD.Location = new System.Drawing.Point(109, 113);
            this.ArrowHeightNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ArrowHeightNUD.Name = "ArrowHeightNUD";
            this.ArrowHeightNUD.Size = new System.Drawing.Size(56, 20);
            this.ArrowHeightNUD.TabIndex = 4;
            this.ArrowHeightNUD.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ArrowWidthNUD
            // 
            this.ArrowWidthNUD.Location = new System.Drawing.Point(36, 113);
            this.ArrowWidthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ArrowWidthNUD.Name = "ArrowWidthNUD";
            this.ArrowWidthNUD.Size = new System.Drawing.Size(56, 20);
            this.ArrowWidthNUD.TabIndex = 3;
            this.ArrowWidthNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ArrowTailComboBox
            // 
            this.ArrowTailComboBox.FormattingEnabled = true;
            this.ArrowTailComboBox.Location = new System.Drawing.Point(6, 73);
            this.ArrowTailComboBox.Name = "ArrowTailComboBox";
            this.ArrowTailComboBox.Size = new System.Drawing.Size(189, 21);
            this.ArrowTailComboBox.TabIndex = 2;
            this.ArrowTailComboBox.Text = "Тип стрелки хвоста";
            // 
            // ArrowHeadComboBox
            // 
            this.ArrowHeadComboBox.FormattingEnabled = true;
            this.ArrowHeadComboBox.Location = new System.Drawing.Point(6, 46);
            this.ArrowHeadComboBox.Name = "ArrowHeadComboBox";
            this.ArrowHeadComboBox.Size = new System.Drawing.Size(189, 21);
            this.ArrowHeadComboBox.TabIndex = 1;
            this.ArrowHeadComboBox.Text = "Тип стрелки головы";
            // 
            // ShapeComboBox
            // 
            this.ShapeComboBox.FormattingEnabled = true;
            this.ShapeComboBox.Location = new System.Drawing.Point(6, 19);
            this.ShapeComboBox.Name = "ShapeComboBox";
            this.ShapeComboBox.Size = new System.Drawing.Size(189, 21);
            this.ShapeComboBox.TabIndex = 0;
            this.ShapeComboBox.Text = "Вид ребра";
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 10;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // DrawPictureBox
            // 
            this.DrawPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawPictureBox.Location = new System.Drawing.Point(219, 12);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(203, 417);
            this.DrawPictureBox.TabIndex = 2;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.MouseEnter += new System.EventHandler(this.DrawPictureBox_MouseEnter);
            this.DrawPictureBox.MouseLeave += new System.EventHandler(this.DrawPictureBox_MouseLeave);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(173, 435);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(75, 23);
            this.SaveBTN.TabIndex = 3;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // EdgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 463);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RelationsListBox);
            this.Name = "EdgeForm";
            this.Text = "EdgeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EdgeForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerHeightNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerWidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowHeightNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowWidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RelationsListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ArrowTailComboBox;
        private System.Windows.Forms.ComboBox ArrowHeadComboBox;
        private System.Windows.Forms.ComboBox ShapeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ArrowHeightNUD;
        private System.Windows.Forms.NumericUpDown ArrowWidthNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MarkerHeightNUD;
        private System.Windows.Forms.NumericUpDown MarkerWidthNUD;
        private System.Windows.Forms.Button EdgePenBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectedEdgePenBTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FontColorBTN;
        private System.Windows.Forms.Button FontBTN;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.PictureBox DrawPictureBox;
        private System.Windows.Forms.Button SaveBTN;
    }
}