namespace CG_Task6
{
    partial class PenCreatorForm
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
            this.DashStyleListBox = new System.Windows.Forms.ListBox();
            this.OKBTN = new System.Windows.Forms.Button();
            this.ColorBTN = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.WidthNUD = new System.Windows.Forms.NumericUpDown();
            this.ExamplePB = new System.Windows.Forms.PictureBox();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamplePB)).BeginInit();
            this.SuspendLayout();
            // 
            // DashStyleListBox
            // 
            this.DashStyleListBox.FormattingEnabled = true;
            this.DashStyleListBox.Location = new System.Drawing.Point(12, 12);
            this.DashStyleListBox.Name = "DashStyleListBox";
            this.DashStyleListBox.Size = new System.Drawing.Size(120, 95);
            this.DashStyleListBox.TabIndex = 0;
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(138, 77);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(68, 23);
            this.OKBTN.TabIndex = 1;
            this.OKBTN.Text = "ОК";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // ColorBTN
            // 
            this.ColorBTN.Location = new System.Drawing.Point(138, 12);
            this.ColorBTN.Name = "ColorBTN";
            this.ColorBTN.Size = new System.Drawing.Size(68, 33);
            this.ColorBTN.TabIndex = 2;
            this.ColorBTN.UseVisualStyleBackColor = true;
            this.ColorBTN.Click += new System.EventHandler(this.ColorBTN_Click);
            // 
            // WidthNUD
            // 
            this.WidthNUD.Location = new System.Drawing.Point(138, 51);
            this.WidthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthNUD.Name = "WidthNUD";
            this.WidthNUD.Size = new System.Drawing.Size(68, 20);
            this.WidthNUD.TabIndex = 3;
            this.WidthNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ExamplePB
            // 
            this.ExamplePB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ExamplePB.Location = new System.Drawing.Point(212, 12);
            this.ExamplePB.Name = "ExamplePB";
            this.ExamplePB.Size = new System.Drawing.Size(95, 95);
            this.ExamplePB.TabIndex = 4;
            this.ExamplePB.TabStop = false;
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 20;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // PenCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 115);
            this.Controls.Add(this.ExamplePB);
            this.Controls.Add(this.WidthNUD);
            this.Controls.Add(this.ColorBTN);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.DashStyleListBox);
            this.Name = "PenCreatorForm";
            this.Text = "Создать перо";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PenCreatorForm_FormClosed);
            this.Load += new System.EventHandler(this.PenCreatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamplePB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox DashStyleListBox;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.Button ColorBTN;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.NumericUpDown WidthNUD;
        private System.Windows.Forms.PictureBox ExamplePB;
        private System.Windows.Forms.Timer DrawTimer;
    }
}