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
    public partial class EdgeForm : Form
    {
        public EdgeForm()
        {
            InitializeComponent();
        }

        public List<Relation> SetRelations
        {
            set
            {
                RelationsListBox.Items.AddRange(value.ToArray());
            }
        }

        public Relation GetRelation
        {
            get
            {
                return RelationsListBox.SelectedItem as Relation;
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
    }
}
