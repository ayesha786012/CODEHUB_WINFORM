using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webs
{
    public partial class RawView : Form
    {
        public RawView()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sOURCEDataSet.Report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.sOURCEDataSet.Report);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you Sure you want to Delete  ", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result== DialogResult.Yes)
                {
                    reportBindingSource.RemoveCurrent();
                }
            }
        }
    }
}
