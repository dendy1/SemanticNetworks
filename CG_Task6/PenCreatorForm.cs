using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task6
{
    public partial class PenCreatorForm : Form
    {
        Bitmap exampleBitmap = new Bitmap(95, 95);

        public PenCreatorForm()
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(DashStyle)))
            {
                DashStyleListBox.Items.Add(item);
            }
            DashStyleListBox.SelectedIndex = 0;
        }

        public Pen Pen
        {
            get
            {
                Pen pen = new Pen(ColorBTN.BackColor, (float)WidthNUD.Value);
                pen.DashStyle = (DashStyle)DashStyleListBox.SelectedItem;
                return pen;
            }
            set
            {
                WidthNUD.Value = (decimal)value.Width;
                ColorBTN.BackColor = value.Color;
                DashStyleListBox.SelectedItem = value.DashStyle;
            }
        }

        private void PenCreatorForm_Load(object sender, EventArgs e)
        {

        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ColorBTN_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorBTN.BackColor = ColorDialog.Color;
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            Pen pen = new Pen(ColorBTN.BackColor, (float)WidthNUD.Value);
            pen.DashStyle = (DashStyle)DashStyleListBox.SelectedItem;
            using (Graphics g = Graphics.FromImage(exampleBitmap))
            {
                g.Clear(Color.White);
                g.DrawLine(pen, 10, 10, 85, 85);
            }

            ExamplePB.Image = exampleBitmap;
        }

        private void PenCreatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DrawTimer.Stop();
            exampleBitmap.Dispose();
        }
    }
}
