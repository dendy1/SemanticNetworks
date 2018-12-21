namespace CG_Task6
{
    partial class RelationSettingsForm
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
            this.RelationsListBox = new System.Windows.Forms.ListBox();
            this.RelationNameTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddNewRelationBTN = new System.Windows.Forms.Button();
            this.OkBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RelationsListBox
            // 
            this.RelationsListBox.FormattingEnabled = true;
            this.RelationsListBox.Location = new System.Drawing.Point(12, 12);
            this.RelationsListBox.Name = "RelationsListBox";
            this.RelationsListBox.Size = new System.Drawing.Size(158, 212);
            this.RelationsListBox.TabIndex = 0;
            // 
            // RelationNameTB
            // 
            this.RelationNameTB.Location = new System.Drawing.Point(6, 28);
            this.RelationNameTB.Name = "RelationNameTB";
            this.RelationNameTB.Size = new System.Drawing.Size(146, 20);
            this.RelationNameTB.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddNewRelationBTN);
            this.groupBox1.Controls.Add(this.RelationNameTB);
            this.groupBox1.Location = new System.Drawing.Point(176, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 92);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить новое отношение";
            // 
            // AddNewRelationBTN
            // 
            this.AddNewRelationBTN.Location = new System.Drawing.Point(41, 54);
            this.AddNewRelationBTN.Name = "AddNewRelationBTN";
            this.AddNewRelationBTN.Size = new System.Drawing.Size(75, 23);
            this.AddNewRelationBTN.TabIndex = 2;
            this.AddNewRelationBTN.Text = "Добавить";
            this.AddNewRelationBTN.UseVisualStyleBackColor = true;
            this.AddNewRelationBTN.Click += new System.EventHandler(this.addNewRelationBTN_Click);
            // 
            // OkBTN
            // 
            this.OkBTN.Location = new System.Drawing.Point(217, 137);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 3;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // RelationSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 241);
            this.Controls.Add(this.OkBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RelationsListBox);
            this.Name = "RelationSettingsForm";
            this.Text = "RelationSettingsFomr";
            this.Load += new System.EventHandler(this.RelationSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RelationsListBox;
        private System.Windows.Forms.TextBox RelationNameTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddNewRelationBTN;
        private System.Windows.Forms.Button OkBTN;
    }
}