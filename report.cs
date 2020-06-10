using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using Bunifu.UI.WinForms;
using Bunifu.Framework.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Data.SqlClient;
using System.IO;


namespace webs
{
    public partial class report : Form
    {
        public report(String name)
        {
            string nam = name;
          
            

        }
        public report()
        {
            InitializeComponent();
           
           
        }
        private void report_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                SqlConnection coni = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                coni.Open();
                SqlCommand cndi = coni.CreateCommand();
                cndi.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    cndi.CommandText = "select * from Report where Password='" + textBox8.Text + "' update Report set Remarks ='" + radioButton1.Text + "' where Password='" + textBox8.Text + "'";

                 //   cndi.CommandText = "insert into Remarks values('" + radioButton1.Text + "')";
                    cndi.ExecuteNonQuery();
                    coni.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                coni.Close();
            }
           
            if (radioButton2.Checked)
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    cnd.CommandText = "select * from Report where Password='" + textBox8.Text + "' update Report set Remarks ='" + radioButton1.Text + "' where Password='" + textBox8.Text + "'";
                    cnd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            if (radioButton3.Checked)
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    cnd.CommandText = "select * from Report where Password='" + textBox8.Text + "' update Report set Remarks ='" + radioButton1.Text + "' where Password='" + textBox8.Text + "'";
                    cnd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            if (radioButton4.Checked)
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    cnd.CommandText = "select * from Report where Password='" + textBox8.Text + "' update Report set Remarks ='" + radioButton1.Text + "' where Password='" + textBox8.Text + "'";
                    cnd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            if (radioButton5.Checked)
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
                try
                {
                    cnd.CommandText = "select * from Report where Password='" + textBox8.Text + "' update Report set Remarks ='" + radioButton1.Text + "' where Password='" + textBox8.Text + "'";
                    cnd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            MessageBox.Show("Submitted Successfully!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            perform per = new perform();
            per.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            cnd.CommandText = "SELECT * FROM Report WHERE Password='" + textBox8.Text + "'";
            try
            {
                SqlDataReader dr = cnd.ExecuteReader();
                while (dr.Read())
                {



                    textBox1.AppendText(dr["Name"].ToString());
                    textBox2.AppendText(dr["Query"].ToString());
                    textBox3.AppendText(dr["Language"].ToString());
                    textBox4.AppendText(dr["Source"].ToString());
                    //textBox5.AppendText(dr["Query"].ToString());
                    textBox5.AppendText(dr["Search"].ToString());
                    textBox6.AppendText(dr["Date"].ToString());
                    textBox7.AppendText(dr["Time"].ToString());
                    textBox10.AppendText(dr["Email"].ToString());
                    listBox1.Items.Add(dr["Recommended"].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //   View v = new View();
            //   v.ShowDialog();
            RawView rv = new RawView();
            rv.ShowDialog();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }

        
    }
