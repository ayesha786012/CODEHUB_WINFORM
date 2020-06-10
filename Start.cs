using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Speech.Synthesis;
namespace webs
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Both;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            writefile();
        }

        private async void writefile()
        {

            using (SaveFileDialog sdf = new SaveFileDialog()
            {
                Filter = "Text Document|*.txt",
                ValidateNames = true,

            })

                if (sdf.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sdf.FileName))
                        await sw.WriteLineAsync(textBox1.Text);
                    MessageBox.Show("Successfully Saved !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Load(object sender, EventArgs e)
        {
            
        }
    }
}
