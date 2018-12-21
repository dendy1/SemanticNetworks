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
            this.RelationsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // RelationsListBox
            // 
            this.RelationsListBox.FormattingEnabled = true;
            this.RelationsListBox.Location = new System.Drawing.Point(12, 12);
            this.RelationsListBox.Name = "RelationsListBox";
            this.RelationsListBox.Size = new System.Drawing.Size(196, 212);
            this.RelationsListBox.TabIndex = 0;
            this.RelationsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RelationsListBox_MouseDoubleClick);
            // 
            // EdgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 235);
            this.Controls.Add(this.RelationsListBox);
            this.Name = "EdgeForm";
            this.Text = "EdgeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox RelationsListBox;
    }
}