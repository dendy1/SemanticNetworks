using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemanticNetworksLibrary.Semantic_Network;

namespace CG_Task6
{
    public partial class RelationSettingsForm : Form
    {
        public List<Relation> Relations { get; set; }

        public RelationSettingsForm()
        {
            InitializeComponent();
        }

        private void addNewRelationBTN_Click(object sender, EventArgs e)
        {
            Relation newrelation = new Relation(RelationNameTB.Text);
            Relations.Add(newrelation);
            RelationsListBox.Items.Add(newrelation);
        }

        private void RelationSettingsForm_Load(object sender, EventArgs e)
        {
            RelationsListBox.Items.AddRange(Relations.ToArray());
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
