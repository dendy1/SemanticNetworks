namespace CG_Task6
{
    partial class NetworkForm
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
            this.SMnameLabel = new System.Windows.Forms.Label();
            this.TextBoxSMname = new System.Windows.Forms.TextBox();
            this.DrawConfigGB = new System.Windows.Forms.GroupBox();
            this.FontsGB = new System.Windows.Forms.GroupBox();
            this.EdgeFontBrushBTN = new System.Windows.Forms.Button();
            this.NodeFontBrushBTN = new System.Windows.Forms.Button();
            this.EdgeFontBTN = new System.Windows.Forms.Button();
            this.NodeFontBTN = new System.Windows.Forms.Button();
            this.EdgesColorGB = new System.Windows.Forms.GroupBox();
            this.arrowHeightNUD = new System.Windows.Forms.NumericUpDown();
            this.arrowWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.SelectedEdgeNUD = new System.Windows.Forms.NumericUpDown();
            this.EdgeNUD = new System.Windows.Forms.NumericUpDown();
            this.SelectedEdgeBTN = new System.Windows.Forms.Button();
            this.EdgeBTN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NodesColorGB = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FillSelectedNodeBrushBTN = new System.Windows.Forms.Button();
            this.SelectedNodeNUD = new System.Windows.Forms.NumericUpDown();
            this.NodeNUD = new System.Windows.Forms.NumericUpDown();
            this.SelectedNodePenColorBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.NodePenColorBTN = new System.Windows.Forms.Button();
            this.FillNodeBrushBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeTypeGB = new System.Windows.Forms.GroupBox();
            this.EllipseNodeFormRB = new System.Windows.Forms.RadioButton();
            this.RectangleNodeFormRB = new System.Windows.Forms.RadioButton();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.OKButton = new System.Windows.Forms.Button();
            this.NodeFontDialog = new System.Windows.Forms.FontDialog();
            this.EdgeFontDialog = new System.Windows.Forms.FontDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.DrawConfigGB.SuspendLayout();
            this.FontsGB.SuspendLayout();
            this.EdgesColorGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowHeightNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowWidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedEdgeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgeNUD)).BeginInit();
            this.NodesColorGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedNodeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeNUD)).BeginInit();
            this.NodeTypeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // SMnameLabel
            // 
            this.SMnameLabel.AutoSize = true;
            this.SMnameLabel.Location = new System.Drawing.Point(12, 9);
            this.SMnameLabel.Name = "SMnameLabel";
            this.SMnameLabel.Size = new System.Drawing.Size(136, 13);
            this.SMnameLabel.TabIndex = 0;
            this.SMnameLabel.Text = "Имя семантической сети";
            // 
            // TextBoxSMname
            // 
            this.TextBoxSMname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxSMname.Location = new System.Drawing.Point(163, 6);
            this.TextBoxSMname.Name = "TextBoxSMname";
            this.TextBoxSMname.Size = new System.Drawing.Size(395, 20);
            this.TextBoxSMname.TabIndex = 1;
            // 
            // DrawConfigGB
            // 
            this.DrawConfigGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawConfigGB.Controls.Add(this.FontsGB);
            this.DrawConfigGB.Controls.Add(this.EdgesColorGB);
            this.DrawConfigGB.Controls.Add(this.NodesColorGB);
            this.DrawConfigGB.Controls.Add(this.NodeTypeGB);
            this.DrawConfigGB.Location = new System.Drawing.Point(12, 32);
            this.DrawConfigGB.Name = "DrawConfigGB";
            this.DrawConfigGB.Size = new System.Drawing.Size(546, 244);
            this.DrawConfigGB.TabIndex = 3;
            this.DrawConfigGB.TabStop = false;
            this.DrawConfigGB.Text = "Настройки представления графа";
            // 
            // FontsGB
            // 
            this.FontsGB.Controls.Add(this.EdgeFontBrushBTN);
            this.FontsGB.Controls.Add(this.NodeFontBrushBTN);
            this.FontsGB.Controls.Add(this.EdgeFontBTN);
            this.FontsGB.Controls.Add(this.NodeFontBTN);
            this.FontsGB.Location = new System.Drawing.Point(12, 157);
            this.FontsGB.Name = "FontsGB";
            this.FontsGB.Size = new System.Drawing.Size(141, 87);
            this.FontsGB.TabIndex = 5;
            this.FontsGB.TabStop = false;
            this.FontsGB.Text = "Шрифты";
            // 
            // EdgeFontBrushBTN
            // 
            this.EdgeFontBrushBTN.Location = new System.Drawing.Point(108, 48);
            this.EdgeFontBrushBTN.Name = "EdgeFontBrushBTN";
            this.EdgeFontBrushBTN.Size = new System.Drawing.Size(25, 23);
            this.EdgeFontBrushBTN.TabIndex = 6;
            this.EdgeFontBrushBTN.Tag = "1";
            this.EdgeFontBrushBTN.UseVisualStyleBackColor = true;
            // 
            // NodeFontBrushBTN
            // 
            this.NodeFontBrushBTN.Location = new System.Drawing.Point(108, 19);
            this.NodeFontBrushBTN.Name = "NodeFontBrushBTN";
            this.NodeFontBrushBTN.Size = new System.Drawing.Size(25, 23);
            this.NodeFontBrushBTN.TabIndex = 5;
            this.NodeFontBrushBTN.Tag = "1";
            this.NodeFontBrushBTN.UseVisualStyleBackColor = true;
            // 
            // EdgeFontBTN
            // 
            this.EdgeFontBTN.Location = new System.Drawing.Point(6, 48);
            this.EdgeFontBTN.Name = "EdgeFontBTN";
            this.EdgeFontBTN.Size = new System.Drawing.Size(96, 23);
            this.EdgeFontBTN.TabIndex = 1;
            this.EdgeFontBTN.Tag = "1";
            this.EdgeFontBTN.Text = "Ребро";
            this.EdgeFontBTN.UseVisualStyleBackColor = true;
            // 
            // NodeFontBTN
            // 
            this.NodeFontBTN.Location = new System.Drawing.Point(6, 19);
            this.NodeFontBTN.Name = "NodeFontBTN";
            this.NodeFontBTN.Size = new System.Drawing.Size(96, 23);
            this.NodeFontBTN.TabIndex = 0;
            this.NodeFontBTN.Tag = "1";
            this.NodeFontBTN.Text = "Узел";
            this.NodeFontBTN.UseVisualStyleBackColor = true;
            // 
            // EdgesColorGB
            // 
            this.EdgesColorGB.Controls.Add(this.arrowHeightNUD);
            this.EdgesColorGB.Controls.Add(this.arrowWidthNUD);
            this.EdgesColorGB.Controls.Add(this.SelectedEdgeNUD);
            this.EdgesColorGB.Controls.Add(this.EdgeNUD);
            this.EdgesColorGB.Controls.Add(this.SelectedEdgeBTN);
            this.EdgesColorGB.Controls.Add(this.EdgeBTN);
            this.EdgesColorGB.Controls.Add(this.label7);
            this.EdgesColorGB.Controls.Add(this.label8);
            this.EdgesColorGB.Location = new System.Drawing.Point(180, 177);
            this.EdgesColorGB.Name = "EdgesColorGB";
            this.EdgesColorGB.Size = new System.Drawing.Size(359, 67);
            this.EdgesColorGB.TabIndex = 8;
            this.EdgesColorGB.TabStop = false;
            this.EdgesColorGB.Text = "Цвет рёбер";
            // 
            // arrowHeightNUD
            // 
            this.arrowHeightNUD.Location = new System.Drawing.Point(301, 42);
            this.arrowHeightNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arrowHeightNUD.Name = "arrowHeightNUD";
            this.arrowHeightNUD.Size = new System.Drawing.Size(40, 20);
            this.arrowHeightNUD.TabIndex = 15;
            this.arrowHeightNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // arrowWidthNUD
            // 
            this.arrowWidthNUD.Location = new System.Drawing.Point(301, 19);
            this.arrowWidthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.arrowWidthNUD.Name = "arrowWidthNUD";
            this.arrowWidthNUD.Size = new System.Drawing.Size(40, 20);
            this.arrowWidthNUD.TabIndex = 14;
            this.arrowWidthNUD.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // SelectedEdgeNUD
            // 
            this.SelectedEdgeNUD.Location = new System.Drawing.Point(105, 42);
            this.SelectedEdgeNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SelectedEdgeNUD.Name = "SelectedEdgeNUD";
            this.SelectedEdgeNUD.Size = new System.Drawing.Size(40, 20);
            this.SelectedEdgeNUD.TabIndex = 12;
            this.SelectedEdgeNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EdgeNUD
            // 
            this.EdgeNUD.Location = new System.Drawing.Point(105, 19);
            this.EdgeNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EdgeNUD.Name = "EdgeNUD";
            this.EdgeNUD.Size = new System.Drawing.Size(40, 20);
            this.EdgeNUD.TabIndex = 13;
            this.EdgeNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SelectedEdgeBTN
            // 
            this.SelectedEdgeBTN.Location = new System.Drawing.Point(6, 39);
            this.SelectedEdgeBTN.Name = "SelectedEdgeBTN";
            this.SelectedEdgeBTN.Size = new System.Drawing.Size(93, 23);
            this.SelectedEdgeBTN.TabIndex = 6;
            this.SelectedEdgeBTN.Tag = "1";
            this.SelectedEdgeBTN.UseVisualStyleBackColor = true;
            this.SelectedEdgeBTN.MouseHover += new System.EventHandler(this.SelectedEdgeBTN_MouseHover);
            // 
            // EdgeBTN
            // 
            this.EdgeBTN.Location = new System.Drawing.Point(6, 16);
            this.EdgeBTN.Name = "EdgeBTN";
            this.EdgeBTN.Size = new System.Drawing.Size(93, 23);
            this.EdgeBTN.TabIndex = 5;
            this.EdgeBTN.Tag = "1";
            this.EdgeBTN.UseVisualStyleBackColor = true;
            this.EdgeBTN.MouseHover += new System.EventHandler(this.EdgeBTN_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Выбранное";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Цвет выбранного ребра";
            // 
            // NodesColorGB
            // 
            this.NodesColorGB.Controls.Add(this.label3);
            this.NodesColorGB.Controls.Add(this.FillSelectedNodeBrushBTN);
            this.NodesColorGB.Controls.Add(this.SelectedNodeNUD);
            this.NodesColorGB.Controls.Add(this.NodeNUD);
            this.NodesColorGB.Controls.Add(this.SelectedNodePenColorBTN);
            this.NodesColorGB.Controls.Add(this.label5);
            this.NodesColorGB.Controls.Add(this.NodePenColorBTN);
            this.NodesColorGB.Controls.Add(this.FillNodeBrushBTN);
            this.NodesColorGB.Controls.Add(this.label2);
            this.NodesColorGB.Controls.Add(this.label1);
            this.NodesColorGB.Location = new System.Drawing.Point(180, 31);
            this.NodesColorGB.Name = "NodesColorGB";
            this.NodesColorGB.Size = new System.Drawing.Size(366, 140);
            this.NodesColorGB.TabIndex = 3;
            this.NodesColorGB.TabStop = false;
            this.NodesColorGB.Text = "Цвет узлов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Заливка выбранного узла";
            // 
            // FillSelectedNodeBrushBTN
            // 
            this.FillSelectedNodeBrushBTN.Location = new System.Drawing.Point(6, 45);
            this.FillSelectedNodeBrushBTN.Name = "FillSelectedNodeBrushBTN";
            this.FillSelectedNodeBrushBTN.Size = new System.Drawing.Size(93, 23);
            this.FillSelectedNodeBrushBTN.TabIndex = 12;
            this.FillSelectedNodeBrushBTN.Tag = "1";
            this.FillSelectedNodeBrushBTN.UseVisualStyleBackColor = true;
            // 
            // SelectedNodeNUD
            // 
            this.SelectedNodeNUD.Location = new System.Drawing.Point(105, 106);
            this.SelectedNodeNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SelectedNodeNUD.Name = "SelectedNodeNUD";
            this.SelectedNodeNUD.Size = new System.Drawing.Size(40, 20);
            this.SelectedNodeNUD.TabIndex = 11;
            this.SelectedNodeNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NodeNUD
            // 
            this.NodeNUD.Location = new System.Drawing.Point(105, 80);
            this.NodeNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NodeNUD.Name = "NodeNUD";
            this.NodeNUD.Size = new System.Drawing.Size(40, 20);
            this.NodeNUD.TabIndex = 10;
            this.NodeNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SelectedNodePenColorBTN
            // 
            this.SelectedNodePenColorBTN.Location = new System.Drawing.Point(6, 103);
            this.SelectedNodePenColorBTN.Name = "SelectedNodePenColorBTN";
            this.SelectedNodePenColorBTN.Size = new System.Drawing.Size(93, 23);
            this.SelectedNodePenColorBTN.TabIndex = 8;
            this.SelectedNodePenColorBTN.Tag = "1";
            this.SelectedNodePenColorBTN.UseVisualStyleBackColor = true;
            this.SelectedNodePenColorBTN.MouseHover += new System.EventHandler(this.SelectedNodeBTN_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Цвет и толщина обводки выбран. узла";
            // 
            // NodePenColorBTN
            // 
            this.NodePenColorBTN.Location = new System.Drawing.Point(6, 74);
            this.NodePenColorBTN.Name = "NodePenColorBTN";
            this.NodePenColorBTN.Size = new System.Drawing.Size(93, 23);
            this.NodePenColorBTN.TabIndex = 6;
            this.NodePenColorBTN.Tag = "1";
            this.NodePenColorBTN.UseVisualStyleBackColor = true;
            this.NodePenColorBTN.MouseHover += new System.EventHandler(this.DrawNodeBTN_MouseHover);
            // 
            // FillNodeBrushBTN
            // 
            this.FillNodeBrushBTN.Location = new System.Drawing.Point(6, 16);
            this.FillNodeBrushBTN.Name = "FillNodeBrushBTN";
            this.FillNodeBrushBTN.Size = new System.Drawing.Size(93, 23);
            this.FillNodeBrushBTN.TabIndex = 5;
            this.FillNodeBrushBTN.Tag = "1";
            this.FillNodeBrushBTN.UseVisualStyleBackColor = true;
            this.FillNodeBrushBTN.MouseHover += new System.EventHandler(this.FillNodeBTN_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Цвет и толщина обводки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Заливка узла";
            // 
            // NodeTypeGB
            // 
            this.NodeTypeGB.Controls.Add(this.radioButton1);
            this.NodeTypeGB.Controls.Add(this.EllipseNodeFormRB);
            this.NodeTypeGB.Controls.Add(this.RectangleNodeFormRB);
            this.NodeTypeGB.Location = new System.Drawing.Point(6, 31);
            this.NodeTypeGB.Name = "NodeTypeGB";
            this.NodeTypeGB.Size = new System.Drawing.Size(114, 80);
            this.NodeTypeGB.TabIndex = 2;
            this.NodeTypeGB.TabStop = false;
            this.NodeTypeGB.Text = "Вид узлов";
            // 
            // EllipseNodeFormRB
            // 
            this.EllipseNodeFormRB.AutoSize = true;
            this.EllipseNodeFormRB.Enabled = false;
            this.EllipseNodeFormRB.Location = new System.Drawing.Point(6, 42);
            this.EllipseNodeFormRB.Name = "EllipseNodeFormRB";
            this.EllipseNodeFormRB.Size = new System.Drawing.Size(62, 17);
            this.EllipseNodeFormRB.TabIndex = 1;
            this.EllipseNodeFormRB.Text = "Эллипс";
            this.EllipseNodeFormRB.UseVisualStyleBackColor = true;
            // 
            // RectangleNodeFormRB
            // 
            this.RectangleNodeFormRB.AutoSize = true;
            this.RectangleNodeFormRB.Checked = true;
            this.RectangleNodeFormRB.Location = new System.Drawing.Point(6, 19);
            this.RectangleNodeFormRB.Name = "RectangleNodeFormRB";
            this.RectangleNodeFormRB.Size = new System.Drawing.Size(105, 17);
            this.RectangleNodeFormRB.TabIndex = 0;
            this.RectangleNodeFormRB.TabStop = true;
            this.RectangleNodeFormRB.Text = "Прямоугольник";
            this.RectangleNodeFormRB.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(239, 282);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Tag = "2";
            this.OKButton.Text = "Сохранить";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(6, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(174, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Скругленный прямоукольник";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 317);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.DrawConfigGB);
            this.Controls.Add(this.TextBoxSMname);
            this.Controls.Add(this.SMnameLabel);
            this.Name = "NetworkForm";
            this.Text = "Добавление новой сети";
            this.Load += new System.EventHandler(this.NetworkForm_Load);
            this.DrawConfigGB.ResumeLayout(false);
            this.FontsGB.ResumeLayout(false);
            this.EdgesColorGB.ResumeLayout(false);
            this.EdgesColorGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowHeightNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowWidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedEdgeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgeNUD)).EndInit();
            this.NodesColorGB.ResumeLayout(false);
            this.NodesColorGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedNodeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NodeNUD)).EndInit();
            this.NodeTypeGB.ResumeLayout(false);
            this.NodeTypeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SMnameLabel;
        private System.Windows.Forms.TextBox TextBoxSMname;
        private System.Windows.Forms.GroupBox DrawConfigGB;
        private System.Windows.Forms.GroupBox NodesColorGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox NodeTypeGB;
        private System.Windows.Forms.RadioButton EllipseNodeFormRB;
        private System.Windows.Forms.RadioButton RectangleNodeFormRB;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button NodePenColorBTN;
        private System.Windows.Forms.Button FillNodeBrushBTN;
        private System.Windows.Forms.GroupBox EdgesColorGB;
        private System.Windows.Forms.Button SelectedEdgeBTN;
        private System.Windows.Forms.Button EdgeBTN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SelectedNodePenColorBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox FontsGB;
        private System.Windows.Forms.Button EdgeFontBTN;
        private System.Windows.Forms.Button NodeFontBTN;
        private System.Windows.Forms.FontDialog NodeFontDialog;
        private System.Windows.Forms.NumericUpDown SelectedEdgeNUD;
        private System.Windows.Forms.NumericUpDown EdgeNUD;
        private System.Windows.Forms.NumericUpDown SelectedNodeNUD;
        private System.Windows.Forms.NumericUpDown NodeNUD;
        private System.Windows.Forms.Button EdgeFontBrushBTN;
        private System.Windows.Forms.Button NodeFontBrushBTN;
        private System.Windows.Forms.FontDialog EdgeFontDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FillSelectedNodeBrushBTN;
        private System.Windows.Forms.NumericUpDown arrowHeightNUD;
        private System.Windows.Forms.NumericUpDown arrowWidthNUD;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}