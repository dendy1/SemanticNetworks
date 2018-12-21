using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;

namespace CG_Task6
{
    public partial class NetworkForm : Form
    {
        //public DrawConfig DrawingConfig { get; set; }
        //public Converter Converter { get; set; }
        //Bitmap bmp = new Bitmap(100, 100);
        //Font edgeFont, nodeFont;
        //int w, h;

        public NetworkForm()
        {
            InitializeComponent();
            //w = bmp.Width - 30; h = bmp.Height - 30;

            //var buttonsCollection = Utils.GetAll(this, typeof(Button));
            //foreach (Button button in buttonsCollection)
            //{
            //    if (button.DialogResult != DialogResult.OK)
            //        button.Click += SetColorBTN_Click;
            //}
        }

        private void SetColorBTN_Click(object sender, EventArgs e)
        {
            SetColor(sender as Button);
        }

        private SolidBrush GetBrush(Button button)
        {
            return new SolidBrush(button.BackColor);
        }

        private Pen GetPen(Button button, decimal width)
        {
            return new Pen(button.BackColor, (int)width);
        }

        private void SetColor(Button button)
        {
            //if (ColorDialog.ShowDialog() == DialogResult.OK)
            //{
            //    Color color = ColorDialog.Color;
            //    button.BackColor = color;
            //}
        }

        public void Default()
        {
            //FillNodeBrushBTN.BackColor = Color.White;
            //NodePenColorBTN.BackColor = Color.Black;
            //SelectedNodePenColorBTN.BackColor = Color.Red;
            //SelectedEdgeBTN.BackColor = Color.Red;
            //EdgeBTN.BackColor = Color.Black;
            //NodeFontBrushBTN.BackColor = Color.Black;
            //EdgeFontBrushBTN.BackColor = Color.Black;
            //FillSelectedNodeBrushBTN.BackColor = Color.White;

            //edgeFont = new Font("Arial", 24);
            //nodeFont = new Font("Arial", 24);
        }

        private void NetworkForm_Load(object sender, EventArgs e)
        {
            //if (DrawingConfig == null)
            //    Default();
            //else
            //{
            //    DrawConfig dc = DrawingConfig;

            //    FillNodeBrushBTN.BackColor = dc.FillNodeBrush.Color;
            //    NodePenColorBTN.BackColor = dc.NodePen.Color;
            //    SelectedNodePenColorBTN.BackColor = dc.SelectedNodePen.Color;

            //    EdgeBTN.BackColor = dc.EdgePen.Color;
            //    SelectedEdgeBTN.BackColor = dc.SelectedEdgePen.Color;

            //    NodeNUD.Value = (decimal)dc.NodePen.Width;
            //    SelectedNodeNUD.Value = (decimal)dc.SelectedNodePen.Width;
            //    EdgeNUD.Value = (decimal)dc.EdgePen.Width;
            //    SelectedEdgeNUD.Value = (decimal)dc.SelectedEdgePen.Width;

            //    nodeFont = dc.NodeFont;
            //    edgeFont = dc.EdgeFont;

            //    NodeFontBrushBTN.BackColor = dc.NodeFontBrush.Color;
            //    EdgeFontBrushBTN.BackColor = dc.EdgeFontBrush.Color;

            //    FillSelectedNodeBrushBTN.BackColor = dc.FillSelectedNodeBrush.Color;

            //    arrowHeightNUD.Value = (int)dc.ArrowHeight;
            //    arrowWidthNUD.Value = (int)dc.ArrowWidth;

            //    if (dc.NodeForm == DrawingConfig.NodeFormTypes.Ellipse)
            //        EllipseNodeFormRB.Checked = true;
            //    else
            //        RectangleNodeFormRB.Checked = true;
            //}
        }

        public string NameSN
        {
            get { return TextBoxSMname.Text; }
            set { TextBoxSMname.Text = value; }
        }

        private void FillNodeBTN_MouseHover(object sender, EventArgs e)
        {
            //Node(sender as Button);
        }

        private void DrawNodeBTN_MouseHover(object sender, EventArgs e)
        {
            //Node(sender as Button);
        }

        private void SelectedNodeBTN_MouseHover(object sender, EventArgs e)
        {
            //SelectedNode(sender as Button);
        }

        private void EdgeBTN_MouseHover(object sender, EventArgs e)
        {
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Transparent);
            //    g.DrawLine(new Pen(EdgeBTN.BackColor, (int)EdgeNUD.Value), 10, 10, bmp.Width - 20, bmp.Height - 20);
            //}
            //MyToolTip tooltip = new MyToolTip(bmp);
            //tooltip.SetToolTip((sender as Button), " ");
        }

        private void SelectedEdgeBTN_MouseHover(object sender, EventArgs e)
        {
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Transparent);
            //    g.DrawLine(new Pen(SelectedEdgeBTN.BackColor, (int)SelectedEdgeNUD.Value), 10, 10, bmp.Width - 20, bmp.Height - 20);
            //}
            //MyToolTip tooltip = new MyToolTip(bmp);
            //tooltip.SetToolTip((sender as Button), " ");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //DrawingConfig = new DrawConfig(
            //    nodeFont,
            //    GetBrush(NodeFontBrushBTN),
            //    edgeFont,
            //    GetBrush(EdgeFontBrushBTN),
            //    GetPen(NodePenColorBTN, NodeNUD.Value),
            //    GetPen(SelectedNodePenColorBTN, NodeNUD.Value),
            //    GetBrush(FillNodeBrushBTN),
            //    GetBrush(FillSelectedNodeBrushBTN),
            //    GetPen(EdgeBTN, EdgeNUD.Value),
            //    GetPen(SelectedEdgeBTN, EdgeNUD.Value),
            //    EllipseNodeFormRB.Checked
            //        ? DrawingConfig.NodeFormTypes.Ellipse
            //        : DrawingConfig.NodeFormTypes.Rectangle,
            //    (float) arrowWidthNUD.Value,
            //    (float) arrowHeightNUD.Value,
            //    Converter
            //);
        }

        private void Node(Control c)
        {
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Transparent);

            //    if (EllipseNodeFormRB.Checked)
            //        DrawingAlghoritms.Circle(g,
            //            new SolidBrush(FillNodeBrushBTN.BackColor),
            //            new Pen(NodePenColorBTN.BackColor, (int)NodeNUD.Value),
            //            (bmp.Width - w) / 2,
            //            (bmp.Height - h) / 2,
            //            w, h);
            //    else
            //        DrawingAlghoritms.Rectangle(g,
            //          new SolidBrush(FillNodeBrushBTN.BackColor),
            //          new Pen(NodePenColorBTN.BackColor, (int)NodeNUD.Value),
            //          (bmp.Width - w) / 2,
            //          (bmp.Height - h) / 2,
            //          w, h);
            //}
            //MyToolTip tooltip = new MyToolTip(bmp);
            //tooltip.SetToolTip(c, " ");
        }

        private void SelectedNode(Control c)
        {
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.Transparent);

            //    if (EllipseNodeFormRB.Checked)
            //        DrawingAlghoritms.Circle(g,
            //            new SolidBrush(FillNodeBrushBTN.BackColor),
            //            new Pen(SelectedNodePenColorBTN.BackColor, (int)SelectedNodeNUD.Value),
            //            (bmp.Width - w) / 2,
            //            (bmp.Height - h) / 2,
            //            w, h);
            //    else
            //        DrawingAlghoritms.Rectangle(g,
            //          new SolidBrush(FillNodeBrushBTN.BackColor),
            //          new Pen(SelectedNodePenColorBTN.BackColor, (int)SelectedNodeNUD.Value),
            //          (bmp.Width - w) / 2,
            //          (bmp.Height - h) / 2,
            //          w, h);
            //}
            //MyToolTip tooltip = new MyToolTip(bmp);
            //tooltip.SetToolTip(c, " ");
        }
    }
}
