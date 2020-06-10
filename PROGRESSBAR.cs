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
    public partial class PROGRESSBAR : Form
    {
        public Action Worker { get; set; }
        public PROGRESSBAR( Action worker)
        {
            InitializeComponent();
            if (worker == null)
            
                throw new ArgumentNullException();
            
            Worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void PROGRESSBAR_Load(object sender, EventArgs e)
        {
            bunifuTransition1.ShowSync(bunifuProgressBar1);
            this.timer1.Start();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value += 1;
        }
    }
}
