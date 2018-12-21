using SemanticNetworksLibrary;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SemanticNetworksLibrary._Nodes;
using SemanticNetworksLibrary._Arrows;

namespace CG_Task6
{
    public partial class MainForm : Form
    {
        private Converter converter;
        private SemanticNetwork SemanticNetwork;
        private DrawConfig drawConfig;

        private bool AddingNewEdgeFlag;
        private bool MultiSelectingFlag;
        private bool SelectingAreaFlag;
        private bool moving;

        private float coeff = 1;

        Node selected1, selected2;
        Point start, end;
        MouseEventArgs e0;
        PointF mouseClick;
        float deltaX = 0, deltaY = 0;

        public MainForm()
        {
            InitializeComponent();
            Utils.EnableDoubleBuffer(DrawPanel);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Drawing.DrawSemanticNetwork(e.Graphics, SemanticNetwork, drawConfig);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DrawPanel.MouseWheel += DrawPanel_MouseWheel;
            (DrawPanel as Control).KeyUp += DrawPanel_KeyUp;
            (DrawPanel as Control).KeyDown += DrawPanel_KeyDown;
           
            Test();
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Node node = Drawing.CheckNode(e.Location, SemanticNetwork, drawConfig);
            if (node != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    NodeForm nf = new NodeForm();
                    nf.Info = node.Concept;
                    if (nf.ShowDialog() == DialogResult.OK)
                    {
                        node.Concept = nf.Info;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Вы уверены?", "Подтвердите действие", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                        SemanticNetwork.DeleteNode(node);
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    NodeForm nf = new NodeForm();
                    if (nf.ShowDialog() == DialogResult.OK)
                    {
                        SemanticNetwork.AddNode(new Node(nf.Info, converter.IJtoXY(e.Location), new RectangleNode()));
                    }
                }
            }
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            DrawPanel.Focus();

            Node checkNode = Drawing.CheckNode(e.Location, SemanticNetwork, drawConfig);

            if (e.Button == MouseButtons.Left && SelectingAreaFlag && checkNode == null)
            {
                SemanticNetwork.Deselect();
                SelectingAreaFlag = false;
            }

            if (AddingNewEdgeFlag)
            {
                for (int i = 0; i < SemanticNetwork.Nodes.Count; i++)
                {
                    PointF mousePoint = converter.IJtoXY(e.Location);
                    Node node = Drawing.CheckNode(e.X, e.Y, SemanticNetwork, drawConfig);
                    if (node == null) return;

                    if (selected1 == null)
                    {
                        selected1 = node;
                        break;
                    }
                    if (selected2 == null)
                    {
                        selected2 = node;
                        if (selected1 == null) return;

                        EdgeForm addNewEdgeForm = new EdgeForm();
                        addNewEdgeForm.SetRelations = SemanticNetwork.Relations;
                        if (addNewEdgeForm.ShowDialog() == DialogResult.OK)
                        {
                            Relation relation = addNewEdgeForm.GetRelation;
                            Edge edge = new Edge(relation, selected1, selected2, new CurvedLineEdge(), new CustomArrow(), new CustomArrow());
                            edge.Calculate(drawConfig);
                            SemanticNetwork.AddEdge(edge);
                            AddingNewEdgeFlag = false;
                        }
                        DrawPanel.Invalidate();
                        selected1 = null;
                        selected2 = null;
                        break;
                    }
                }
            }
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Drawing.Select(e.Location, SemanticNetwork, drawConfig);
            if (SemanticNetwork.SelectedNode != null) SemanticNetwork.DeSelectEdges();

            if (e.Button == MouseButtons.Left)
            {
                if (SemanticNetwork.SelectedNode != null)
                {
                    SemanticNetwork.SelectedNode.Position = converter.IJtoXY(e.Location);                  
                }

                if (SemanticNetwork.SelectedEdge != null)
                {
                    PointF mark = Drawing.CheckMark(e.Location, SemanticNetwork.SelectedEdge, drawConfig);
                    if (mark != PointF.Empty)
                    {
                        
                        List<PointF> marksFs = SemanticNetwork.SelectedEdge.MovementPoints;
                        if (mark == marksFs[0])
                        {
                            SemanticNetwork.SelectedEdge.LinePoints[0] = converter.IJtoXY(e.Location);
                        }
                        else if (mark == marksFs[1]) //start
                        {
                            SemanticNetwork.SelectedEdge.XStart = e.Location.X - (converter.XXtoII(SemanticNetwork.SelectedEdge.NodeOne.X) - Drawing.GetSizeF(SemanticNetwork.SelectedEdge.NodeOne, drawConfig).Width / 2);
                        }
                        else if (mark == marksFs[2]) //center
                        {
                            SemanticNetwork.SelectedEdge.Y = converter.JJtoYY(e.Location.Y);
                        }
                        else if (mark == marksFs[3]) //end
                        {
                            SemanticNetwork.SelectedEdge.XEnd = e.Location.X - (converter.XXtoII(SemanticNetwork.SelectedEdge.NodeTwo.X) -
                                                                    Drawing.GetSizeF(SemanticNetwork.SelectedEdge.NodeTwo, drawConfig).Width / 2);
                        }
                        else if (mark == marksFs[marksFs.Count - 1])
                        {
                            SemanticNetwork.SelectedEdge.LinePoints[SemanticNetwork.SelectedEdge.LinePoints.Count - 1] = e.Location;
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Converter convert = SemanticNetwork.DC.Converter;

                double dx = converter.IItoXX(e.X) - converter.IItoXX(e0.X);
                double dy = converter.JJtoYY(e.Y) - converter.JJtoYY(e0.Y);

                e0 = e;

                convert.Xmin -= dx;
                convert.Ymin -= dy;
                convert.Xmax -= dx;
                convert.Ymax -= dy;
            }
            else if (e.Button == MouseButtons.Right)
            {
                end = e.Location;
            }
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moving = true;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                e0 = e;
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else if (e.Button == MouseButtons.Middle)
            {

            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void DrawPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            double x = converter.IItoXX(e.X);
            double y = converter.JJtoYY(e.Y);
            coeff = e.Delta < 0 ?  1.03f :  0.97f;
            converter.Xmin = x - (x - converter.Xmin) * coeff;
            converter.Xmax = x + (converter.Xmax - x) * coeff;
            converter.Ymin = y - (y - converter.Ymin) * coeff;
            converter.Ymax = y + (converter.Ymax - y) * coeff;
            DrawPanel.Invalidate();
        }

        private void DrawPanel_KeyUp(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.ShiftKey)
            {
                AddingNewEdgeFlag = false;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                MultiSelectingFlag = false;
            }
        }

        private void DrawPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                AddingNewEdgeFlag = true;
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                MultiSelectingFlag = true;
            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            //NetworkForm anf = new NetworkForm();
            //anf.DrawingConfig = SemanticNetwork.DC;
            //anf.Converter = converter;
            //anf.NameSN = SemanticNetwork.Name;
            //if (anf.ShowDialog() == DialogResult.OK)
            //{
            //    SemanticNetwork.DC = anf.DrawingConfig;
            //    SemanticNetwork.Name = anf.NameSN;
            //}
        }

        private void edgeSettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (SemanticNetwork == null)
            {
                MessageBox.Show("Вы не создали сеть!");
                return;
            }

            RelationSettingsForm relationSettingsForm = new RelationSettingsForm();
            relationSettingsForm.Relations = SemanticNetwork.Relations;
            if (relationSettingsForm.ShowDialog() == DialogResult.OK)
            {
                SemanticNetwork.Relations = relationSettingsForm.Relations;
            }
        }

        private void Test()
        {
            converter = new Converter(DrawPanel.Width, DrawPanel.Height, -5, 5, -5, 5);
            NodeConfig nodeConfig = new NodeConfig()
            {
                NodePen = new Pen(Color.Black, 5),
                SelectedNodePen = new Pen(Color.Red, 5),
                FillNodeColor = Color.White,
                FillSelectedNodeColor = Color.White,
                Font = converter.ToRealFont(new Font(FontFamily.GenericSansSerif, 24)),
                FontColor = Color.Black,
                NodeShape = NodeConfig.Shape.Rectangle
            };
            EdgeConfig edgeConfig = new EdgeConfig()
            {
                EdgePen = new Pen(Color.Black, 3),
                SelectedEdgePen = new Pen(Color.Red, 3),
                Font = converter.ToRealFont(new Font(FontFamily.GenericSansSerif, 24)),
                FontColor = Color.Black,
                ArrowSize = new Size(15, 40),
                EdgeShape = EdgeConfig.Shape.BrokenLine,
                ArrowHead = EdgeConfig.ArrowShape.My,
                ArrowTail = EdgeConfig.ArrowShape.My,
                MarkSize = new Size(10, 10)
            };
            drawConfig = new DrawConfig(converter, nodeConfig, edgeConfig);
            SemanticNetwork = new SemanticNetwork(new List<Node>(), new List<Edge>(), drawConfig, "TEST");
            SemanticNetwork.AddNode(new Node("qwe", new PointF(-2.14f, -0.88f), new RectangleNode()));
            SemanticNetwork.AddNode(new Node("qwe", new PointF(2.31f, 3.4f), new EllipseNode()));
            foreach (var VARIABLE in SemanticNetwork.Nodes)
            {
                VARIABLE.CalclulateMarks(drawConfig);
            }
            Edge e = new Edge(new Relation("test"), SemanticNetwork.Nodes[0], SemanticNetwork.Nodes[1], new BrokenLineEdge(), new NoneArrow(), new CustomArrow());
            e.Calculate(drawConfig);
            SemanticNetwork.AddEdge(e);

        }
    }
}
