using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemanticNetworksLibrary;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using SemanticNetworksLibrary._Arrows;
using SemanticNetworksLibrary._Nodes;
using Rectangle = SemanticNetworksLibrary._Nodes.Rectangle;

namespace CG_Task6
{
    public partial class NodeForm : Form
    {
        private Pen nodePen = Pens.Black;
        private Pen selectedNodePen = Pens.Red;
        private Font font = new Font(FontFamily.GenericMonospace, 24);
        private Bitmap exampleBitmap;
        private bool selected;
        public Converter Converter { get; set; }

        public NodeForm()
        {
            InitializeComponent();
            ShapeListBox.Items.AddRange(new INodeShape[]
            {
                new None(),
                new Ellipse(), 
                new Rectangle(),
                new RoundedRectangle(), 
            });
            ShapeListBox.SelectedIndex = 1;
            exampleBitmap = new Bitmap(DrawPictureBox.Width, DrawPictureBox.Height);
            FillNodeColorBTN.BackColor = Color.White;
            SelectedFillNodeBTN.BackColor = Color.White;
        }

        private void NameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }

        public string Info
        {
            get { return NameTB.Text; }
            set { NameTB.Text = value.ToString(); }
        }

        private void NodePenBTN_Click(object sender, EventArgs e)
        {
            PenCreatorForm penCreator = new PenCreatorForm();
            penCreator.Pen = nodePen;
            if (penCreator.ShowDialog() == DialogResult.OK)
            {
                nodePen = penCreator.Pen;
            }
        }

        private void SelecteNodePenBTN_Click(object sender, EventArgs e)
        {
            PenCreatorForm penCreator = new PenCreatorForm();
            penCreator.Pen = selectedNodePen;
            if (penCreator.ShowDialog() == DialogResult.OK)
            {
                selectedNodePen = penCreator.Pen;
            }
        }

        private void FontBTN_Click(object sender, EventArgs e)
        {
            FontDialog.Font = font;
            if (FontDialog.ShowDialog() == DialogResult.OK)
            {
                font = FontDialog.Font;
            }
        }

        private void FontColorBTN_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.Color = FontColorBTN.BackColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                FontColorBTN.BackColor = c.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.Color = FillNodeColorBTN.BackColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                FillNodeColorBTN.BackColor = c.Color;
            }
        }

        private void SelectedFillNodeBTN_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.Color = SelecteNodePenBTN.BackColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                SelectedFillNodeBTN.BackColor = c.Color;
            }
        }

        private void DrawPictureBox_MouseEnter(object sender, EventArgs e)
        {
            selected = true;
        }

        private void DrawPictureBox_MouseLeave(object sender, EventArgs e)
        {
            selected = false;
        }

        private void NodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DrawTimer.Stop();
            if (exampleBitmap != null)
                exampleBitmap.Dispose();
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (ShapeListBox.SelectedItem == null) return;
            Converter c;
            using (Graphics g = Graphics.FromImage(exampleBitmap))
            {
                c = new Converter(DrawPictureBox.Width, DrawPictureBox.Height, -1, 1, -5, 5);
                NodeConfig nc = new NodeConfig(
                    (INodeShape)ShapeListBox.SelectedItem,
                    c,
                    nodePen,
                    selectedNodePen,
                    FillNodeColorBTN.BackColor,
                    SelectedFillNodeBTN.BackColor,
                    c.ToRealFont(font),
                    FontColorBTN.BackColor
                );
                Node testNode = new Node(NameTB.Text, c.IJtoXY(new Point(DrawPictureBox.Width / 2, DrawPictureBox.Height / 2)), nc);
                testNode.NodeConfig.Selected = selected;
                g.Clear(Color.White);
                Drawing.DrawNode(g, testNode);
                DrawPictureBox.Image = exampleBitmap;
            }
        }

        public NodeConfig NodeConfig
        {
            get
            {
                return new NodeConfig(
                    (INodeShape)ShapeListBox.SelectedItem,
                    Converter,
                    nodePen,
                    selectedNodePen,
                    FillNodeColorBTN.BackColor,
                    SelectedFillNodeBTN.BackColor,
                    Converter.ToRealFont(font),
                    FontColorBTN.BackColor
                    );
            }
            set
            {
                ShapeListBox.SelectedItem = value.Shape;
                nodePen = value.NodePen;
                selectedNodePen = value.SelectedNodePen;
                FillNodeColorBTN.BackColor = value.FillNodeColor;
                SelectedFillNodeBTN.BackColor = value.FillSelectedNodeColor;
                Font = Converter.ToScreenFont(value.Font);
                FontColorBTN.BackColor = value.FontColor;
            }
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
