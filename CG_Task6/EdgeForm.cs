using SemanticNetworksLibrary;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using SemanticNetworksLibrary._Arrows;
using SemanticNetworksLibrary._Edges;
using Rectangle = SemanticNetworksLibrary._Nodes.Rectangle;

namespace CG_Task6
{
    public partial class EdgeForm : Form
    {
        private Pen edgePen = Pens.Black;
        private Pen selectedEdgePen = Pens.Red;
        private Font font = DefaultFont;
        private Bitmap exampleBitmap;
        private bool selected;
        public Converter Converter { get; set; }

        public EdgeForm()
        {
            InitializeComponent();
            exampleBitmap = new Bitmap(DrawPictureBox.Width, DrawPictureBox.Height);
            ShapeComboBox.Items.AddRange(new IEdgeShape[]
            {
                new None(),
                new StraightLine(),
                new BrokenLine(), 
                new CurvedLine()
            });
            ArrowHeadComboBox.Items.AddRange(new IArrowShape[]
            {
                new NoneArrow(),
                new TriangleArrow(), 
                new CustomArrow()
            });
            ArrowTailComboBox.Items.AddRange(new IArrowShape[]
            {
                new NoneArrow(),
                new TriangleArrow(),
                new CustomArrow()
            });
            ShapeComboBox.SelectedIndex = 0;
            ArrowHeadComboBox.SelectedIndex = 0;
            ArrowTailComboBox.SelectedIndex = 0;
            Utils.EnableDoubleBuffer(DrawPictureBox);

        }

        public List<Relation> SetRelations
        {
            set
            {
                RelationsListBox.Items.AddRange(value.ToArray());
            }
        }

        public Relation Relation
        {
            get
            {
                return RelationsListBox.SelectedItem as Relation;
            }
            set
            {
                foreach (var t in RelationsListBox.Items)
                {
                    if (t.ToString() == value.ToString())
                    {
                        RelationsListBox.SelectedItem = t;
                        break;
                    }
                }
            }
        }

        public SizeF ArrowSize
        {
            get
            {
                return new SizeF((float)ArrowWidthNUD.Value, (float)ArrowHeightNUD.Value);
            }
            set
            {
                ArrowWidthNUD.Value = (decimal) value.Width;
                ArrowHeightNUD.Value = (decimal) value.Height;
            }
        }

        public SizeF MarkerSize
        {
            get
            {
                return new SizeF((float)MarkerWidthNUD.Value, (float)MarkerHeightNUD.Value);
            }
            set
            {
                MarkerWidthNUD.Value = (decimal)value.Width;
                MarkerHeightNUD.Value = (decimal)value.Height;
            }
        }

        public EdgeConfig EdgeConfig
        {
            get
            {
                return new EdgeConfig(
                    (IEdgeShape)ShapeComboBox.SelectedItem,
                    (IArrowShape)ArrowHeadComboBox.SelectedItem,
                    (IArrowShape)ArrowTailComboBox.SelectedItem,
                    Converter.ToRealSize(ArrowSize),
                    Converter.ToRealSize(MarkerSize),
                    edgePen,
                    selectedEdgePen,
                    Converter.ToRealFont(font),
                    FontColorBTN.BackColor,
                    Converter);
            }
            set
            {
                foreach (var t in ShapeComboBox.Items)
                {
                    if (t.ToString() == value.Shape.ToString())
                    {
                        ShapeComboBox.SelectedItem = t;
                    }
                }
                foreach (var t in ArrowHeadComboBox.Items)
                {
                    if (t.ToString() == value.ArrowHeadShape.ToString())
                        ArrowHeadComboBox.SelectedItem = t;
                }
                foreach (var t in ArrowTailComboBox.Items)
                {
                    if (t.ToString() == value.ArrowTailShape.ToString())
                        ArrowTailComboBox.SelectedItem = t;
                }
                ArrowSize = Converter.ToScreenSize(value.ArrowSize);
                MarkerSize = Converter.ToScreenSize(value.MarkerSize);
                edgePen = value.EdgePen;
                selectedEdgePen = value.SelectedEdgePen;
                font = value.Font;
                FontColorBTN.BackColor = value.FontColor;
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void RelationsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.RelationsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void EdgePenBTN_Click(object sender, EventArgs e)
        {
            PenCreatorForm penCreator = new PenCreatorForm();
            penCreator.Pen = edgePen;
            if (penCreator.ShowDialog() == DialogResult.OK)
            {
                edgePen = penCreator.Pen;
            }
        }

        private void SelectedEdgePenBTN_Click(object sender, EventArgs e)
        {
            PenCreatorForm penCreator = new PenCreatorForm();
            penCreator.Pen = selectedEdgePen;
            if (penCreator.ShowDialog() == DialogResult.OK)
            {
                selectedEdgePen = penCreator.Pen;
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (ShapeComboBox.SelectedItem == null || ArrowHeadComboBox.SelectedItem == null ||
                ArrowTailComboBox.SelectedItem == null) return;
            Converter c;
            NodeConfig nc;
            Edge testEdge;
            if (RelationsListBox.SelectedItem != null)
                using (Graphics g = Graphics.FromImage(exampleBitmap))
                {
                    c = new Converter(DrawPictureBox.Width, DrawPictureBox.Height, -1, 1, -5, 5);
                    nc = new NodeConfig(new Rectangle(), c, Pens.Black, Pens.Black, Color.White, Color.White, c.ToRealFont(DefaultFont), Color.Black);
                    EdgeConfig ec = new EdgeConfig(
                        (IEdgeShape)ShapeComboBox.SelectedItem,
                        (IArrowShape)ArrowHeadComboBox.SelectedItem,
                        (IArrowShape)ArrowTailComboBox.SelectedItem,
                        c.ToRealSize(ArrowSize),
                        c.ToRealSize(MarkerSize),
                        edgePen,
                        selectedEdgePen,
                        Converter.ToRealFont(font),
                        FontColorBTN.BackColor,
                        c);
                    testEdge = new Edge(
                        new Relation(RelationsListBox.SelectedItem.ToString()),
                        new Node("One", c.IJtoXY(new Point(40, 40)), nc),
                        new Node("Two", c.IJtoXY(new Point(DrawPictureBox.Width - 40, DrawPictureBox.Height - 40)), nc),
                        ec
                    );

                    testEdge.EdgeConfig.Edit = selected;
                    g.Clear(Color.White);
                    Drawing.DrawEdge(g, testEdge);
                    DrawPictureBox.Image = exampleBitmap;
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

        private void DrawPictureBox_MouseEnter(object sender, EventArgs e)
        {
            selected = true;
        }

        private void DrawPictureBox_MouseLeave(object sender, EventArgs e)
        {
            selected = false;
        }

        private void EdgeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DrawTimer.Stop();
            exampleBitmap.Dispose();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
