namespace CG_Task6
{
    partial class NodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SelectedFillNodeBTN = new System.Windows.Forms.Button();
            this.FillNodeColorBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FontColorBTN = new System.Windows.Forms.Button();
            this.FontBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SelecteNodePenBTN = new System.Windows.Forms.Button();
            this.NodePenBTN = new System.Windows.Forms.Button();
            this.ShapeListBox = new System.Windows.Forms.ListBox();
            this.DrawPictureBox = new System.Windows.Forms.PictureBox();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.OKBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название объекта";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(129, 12);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(100, 20);
            this.NameTB.TabIndex = 2;
            this.NameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTB_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SelectedFillNodeBTN);
            this.groupBox1.Controls.Add(this.FillNodeColorBTN);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FontColorBTN);
            this.groupBox1.Controls.Add(this.FontBTN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SelecteNodePenBTN);
            this.groupBox1.Controls.Add(this.NodePenBTN);
            this.groupBox1.Controls.Add(this.ShapeListBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 303);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки визуализации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "Цвет заливки для\r\nвыбранного узла";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Цвет заливки";
            // 
            // SelectedFillNodeBTN
            // 
            this.SelectedFillNodeBTN.Location = new System.Drawing.Point(6, 207);
            this.SelectedFillNodeBTN.Name = "SelectedFillNodeBTN";
            this.SelectedFillNodeBTN.Size = new System.Drawing.Size(75, 23);
            this.SelectedFillNodeBTN.TabIndex = 20;
            this.SelectedFillNodeBTN.UseVisualStyleBackColor = true;
            this.SelectedFillNodeBTN.Click += new System.EventHandler(this.SelectedFillNodeBTN_Click);
            // 
            // FillNodeColorBTN
            // 
            this.FillNodeColorBTN.Location = new System.Drawing.Point(6, 178);
            this.FillNodeColorBTN.Name = "FillNodeColorBTN";
            this.FillNodeColorBTN.Size = new System.Drawing.Size(75, 23);
            this.FillNodeColorBTN.TabIndex = 19;
            this.FillNodeColorBTN.UseVisualStyleBackColor = true;
            this.FillNodeColorBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Цвет шрифта";
            // 
            // FontColorBTN
            // 
            this.FontColorBTN.BackColor = System.Drawing.Color.Black;
            this.FontColorBTN.Location = new System.Drawing.Point(108, 236);
            this.FontColorBTN.Name = "FontColorBTN";
            this.FontColorBTN.Size = new System.Drawing.Size(75, 46);
            this.FontColorBTN.TabIndex = 16;
            this.FontColorBTN.UseVisualStyleBackColor = false;
            this.FontColorBTN.Click += new System.EventHandler(this.FontColorBTN_Click);
            // 
            // FontBTN
            // 
            this.FontBTN.Location = new System.Drawing.Point(24, 236);
            this.FontBTN.Name = "FontBTN";
            this.FontBTN.Size = new System.Drawing.Size(75, 46);
            this.FontBTN.TabIndex = 17;
            this.FontBTN.Text = "Шрифт надписи";
            this.FontBTN.UseVisualStyleBackColor = true;
            this.FontBTN.Click += new System.EventHandler(this.FontBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "Тип пера для \r\nвыбранной ячейки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Тип пера для ячейки";
            // 
            // SelecteNodePenBTN
            // 
            this.SelecteNodePenBTN.Location = new System.Drawing.Point(6, 149);
            this.SelecteNodePenBTN.Name = "SelecteNodePenBTN";
            this.SelecteNodePenBTN.Size = new System.Drawing.Size(75, 23);
            this.SelecteNodePenBTN.TabIndex = 13;
            this.SelecteNodePenBTN.UseVisualStyleBackColor = true;
            this.SelecteNodePenBTN.Click += new System.EventHandler(this.SelecteNodePenBTN_Click);
            // 
            // NodePenBTN
            // 
            this.NodePenBTN.Location = new System.Drawing.Point(6, 120);
            this.NodePenBTN.Name = "NodePenBTN";
            this.NodePenBTN.Size = new System.Drawing.Size(75, 23);
            this.NodePenBTN.TabIndex = 12;
            this.NodePenBTN.UseVisualStyleBackColor = true;
            this.NodePenBTN.Click += new System.EventHandler(this.NodePenBTN_Click);
            // 
            // ShapeListBox
            // 
            this.ShapeListBox.FormattingEnabled = true;
            this.ShapeListBox.Location = new System.Drawing.Point(6, 19);
            this.ShapeListBox.Name = "ShapeListBox";
            this.ShapeListBox.Size = new System.Drawing.Size(202, 95);
            this.ShapeListBox.TabIndex = 5;
            // 
            // DrawPictureBox
            // 
            this.DrawPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawPictureBox.Location = new System.Drawing.Point(235, 12);
            this.DrawPictureBox.Name = "DrawPictureBox";
            this.DrawPictureBox.Size = new System.Drawing.Size(207, 329);
            this.DrawPictureBox.TabIndex = 4;
            this.DrawPictureBox.TabStop = false;
            this.DrawPictureBox.MouseEnter += new System.EventHandler(this.DrawPictureBox_MouseEnter);
            this.DrawPictureBox.MouseLeave += new System.EventHandler(this.DrawPictureBox_MouseLeave);
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 10;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(191, 347);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 5;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // NodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 375);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.DrawPictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label1);
            this.Name = "NodeForm";
            this.Text = "Добавить объект";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NodeForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ShapeListBox;
        private System.Windows.Forms.PictureBox DrawPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelecteNodePenBTN;
        private System.Windows.Forms.Button NodePenBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FontColorBTN;
        private System.Windows.Forms.Button FontBTN;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SelectedFillNodeBTN;
        private System.Windows.Forms.Button FillNodeColorBTN;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.Button OKBTN;
    }
}