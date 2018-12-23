using SemanticNetworksLibrary;
using SemanticNetworksLibrary._Nodes;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CG_Task6
{
    public partial class MainForm : Form
    {
        private Converter converter;
        private SemanticNetwork SemanticNetwork;
        private DrawConfig drawConfig;
        private float coeff = 1;
        private Node selected1, selected2;
        private bool AddingNewEdgeFlag;
        private MouseEventArgs e0;

        public MainForm()
        {
            InitializeComponent();
            Utils.EnableDoubleBuffer(DrawPanel);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Drawing.DrawSemanticNetwork(e.Graphics, SemanticNetwork);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DrawPanel.MouseWheel += DrawPanel_MouseWheel;
            (DrawPanel as Control).KeyUp += DrawPanel_KeyUp;
            (DrawPanel as Control).KeyDown += DrawPanel_KeyDown;
           
            SemanticNetwork = new SemanticNetwork(new List<Node>(), new List<Edge>(), "Семантическая сеть");
            converter = new Converter(DrawPanel.Width, DrawPanel.Height, -5, 5, -5, 5);
            Test();
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Drawing.Select(e.Location, SemanticNetwork);

            if (SemanticNetwork.SelectedNode != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    NodeForm nf = new NodeForm();
                    nf.Info = SemanticNetwork.SelectedNode.Concept;
                    nf.Converter = converter;
                    if (nf.ShowDialog() == DialogResult.OK)
                    {
                        NodeConfig nc = nf.NodeConfig;
                        SemanticNetwork.SelectedNode.Concept = nf.Info;
                        SemanticNetwork.SelectedNode.NodeConfig = nc;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Вы уверены?", "Подтвердите действие", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                        SemanticNetwork.DeleteNode(SemanticNetwork.SelectedNode);
                }
            }
            else if (SemanticNetwork.SelectedEdge != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    EdgeForm addNewEdgeForm = new EdgeForm();
                    addNewEdgeForm.SetRelations = SemanticNetwork.Relations;
                    addNewEdgeForm.Relation = SemanticNetwork.SelectedEdge.Relation;
                    addNewEdgeForm.Converter = converter;
                    addNewEdgeForm.EdgeConfig = SemanticNetwork.SelectedEdge.EdgeConfig;
                    if (addNewEdgeForm.ShowDialog() == DialogResult.OK)
                    {
                        Relation relation = addNewEdgeForm.Relation;
                        EdgeConfig ec = addNewEdgeForm.EdgeConfig;
                        ec.Selected = true;
                        SemanticNetwork.SelectedEdge.EdgeConfig = ec;
                        SemanticNetwork.SelectedEdge.Relation = relation;
                        SemanticNetwork.DeSelectEditing();
                        
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Вы уверены?", "Подтвердите действие", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        SemanticNetwork.DeleteEdge(SemanticNetwork.SelectedEdge);
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    NodeForm nf = new NodeForm();
                    nf.Converter = converter;
                    if (nf.ShowDialog() == DialogResult.OK)
                    {
                        NodeConfig nc = nf.NodeConfig;
                        SemanticNetwork.AddNode(new Node(nf.Info, converter.IJtoXY(e.Location), nc));
                    }
                }
            }
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            DrawPanel.Focus();
            Drawing.Editing(e.Location, SemanticNetwork);
            if (e.Button == MouseButtons.Left)
            {
                SemanticNetwork.Deselect();
            }

            if (AddingNewEdgeFlag)
            {
                for (int i = 0; i < SemanticNetwork.Nodes.Count; i++)
                {
                    Node node = Drawing.CheckNode(e.X, e.Y, SemanticNetwork);
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
                        addNewEdgeForm.Converter = converter;
                        if (addNewEdgeForm.ShowDialog() == DialogResult.OK)
                        {
                            Relation relation = addNewEdgeForm.Relation;
                            EdgeConfig ec = addNewEdgeForm.EdgeConfig;
                            Edge edge = new Edge(relation, selected1, selected2, ec);
                            //edge.EdgeConfig.SetDefaultValues(edge.NodeOne, edge.NodeTwo);
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
            Drawing.Select(e.Location, SemanticNetwork);
            if (SemanticNetwork.SelectedNode != null) SemanticNetwork.DeSelectEdges();

            if (e.Button == MouseButtons.Left)
            {
                if (SemanticNetwork.SelectedNode != null)
                {
                    SemanticNetwork.SelectedNode.Position = converter.IJtoXY(e.Location);                  
                }

                if (SemanticNetwork.EditingEdge != null)
                {
                    PointF mark = Drawing.CheckMark(e.Location, SemanticNetwork.EditingEdge);
                    if (mark != PointF.Empty)
                    {
                        if (mark == SemanticNetwork.EditingEdge.EdgeConfig.Markers[Utils.MarkerType.Center])
                        {
                            SemanticNetwork.EditingEdge.EdgeConfig.Y = converter.JJtoYY(e.Y);
                        }
                        else if (mark == SemanticNetwork.EditingEdge.EdgeConfig.Markers[Utils.MarkerType.CenterStart])
                        {
                            SemanticNetwork.EditingEdge.EdgeConfig.XStart = (e.Location.X - (converter.XXtoII(SemanticNetwork.EditingEdge.NodeOne.X) - Drawing.GetSizeF(SemanticNetwork.EditingEdge.NodeOne).Width / 2)) / converter.Scale;
                        }
                        else if (mark == SemanticNetwork.EditingEdge.EdgeConfig.Markers[Utils.MarkerType.CenterEnd])
                        {
                            SemanticNetwork.EditingEdge.EdgeConfig.XEnd = (e.Location.X - (converter.XXtoII(SemanticNetwork.EditingEdge.NodeTwo.X) - Drawing.GetSizeF(SemanticNetwork.EditingEdge.NodeTwo).Width / 2)) / converter.Scale;
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                double dx = converter.IItoXX(e.X) - converter.IItoXX(e0.X);
                double dy = converter.JJtoYY(e.Y) - converter.JJtoYY(e0.Y);

                e0 = e;

                converter.Xmin -= dx;
                converter.Ymin -= dy;
                converter.Xmax -= dx;
                converter.Ymax -= dy;
            }
            else if (e.Button == MouseButtons.Right)
            {

            }
            DrawPanel.Invalidate();
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

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
        }

        private void DrawPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                AddingNewEdgeFlag = true;
            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {

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
            EdgeConfig ec = new EdgeConfig(
                new CurvedLine(), 
                new CustomArrow(), new CustomArrow(),
                converter.ToRealSize(new SizeF(15, 25)),
                converter.ToRealSize(new SizeF(30, 30)),
                new Pen(Color.Black, 5),
                new Pen(Color.Red, 5),
                converter.ToRealFont(new Font(FontFamily.GenericMonospace, 24)),
                Color.Black, converter);

            Node n1 = new Node("qwe", new PointF(-2.14f, -0.88f), new NodeConfig(
                new RoundedRectangle(),
                converter,
                new Pen(Color.Black, 5),
                new Pen(Color.Red, 5),
                Color.White,
                Color.White,
                converter.ToRealFont(new Font(FontFamily.GenericMonospace, 24)),
                Color.Black));

            Node n2 = new Node("qwe", new PointF(2.31f, 3.4f), new NodeConfig(
                new RoundedRectangle(),
                converter,
                new Pen(Color.Black, 5),
                new Pen(Color.Red, 5),
                Color.White,
                Color.White,
                converter.ToRealFont(new Font(FontFamily.GenericMonospace, 24)),
                Color.Black));

            SemanticNetwork.AddNode(n1);
            SemanticNetwork.AddNode(n2);
            Edge e = new Edge(new Relation("test"), SemanticNetwork.Nodes[0], SemanticNetwork.Nodes[1], ec);
            SemanticNetwork.AddEdge(e);
        }
    }
}
