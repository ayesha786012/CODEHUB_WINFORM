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
using System.IO;

using System.Data.SqlClient;

namespace webs
{
    public partial class Middle : Form
    {
        public IWebDriver driver;
        public string source { get; set; }
        public bool Option2Selected { get; set; }
        public Middle(string source, string language,string query)
        { InitializeComponent();
           
            MessageBox.Show("Before Move to Rank the Repositories Example You must Firstly to Filter The Examples", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            string s = source;
            textBox4.AppendText(source);
            textBox4.ReadOnly = true;
            textBox5.AppendText(query);
            textBox5.ReadOnly = true;
            /* SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

             con.Open();
             SqlCommand cnd = con.CreateCommand();
             cnd.CommandType = System.Data.CommandType.Text;
             //   cnd.CommandText = "select * from Codehub";
             cnd.CommandText = "SELECT * FROM Report WHERE Source ='"+s+"'";
             try
             {
                 SqlDataReader dr = cnd.ExecuteReader();
                 while (dr.Read())
                 {
                     // TreeNode n = new TreeNode(dr["link"].ToString());
                     textBox4.AppendText(dr["Source"].ToString());
                     textBox4.ReadOnly = true;

                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             con.Close();*/
            string lan = language;
            /*  if (lan == "C#")
              {
                  textBox1.AppendText(".cs");
                  textBox1.ReadOnly = true;
              }
              /*  else if (lan == "C++")
                {
                    textBox1.AppendText(".cpp");
                    textBox1.ReadOnly = true;
                }
                /*   else if (lan == "C")
                   {
                       textBox1.AppendText(".c");
                       textBox1.ReadOnly = true;
                   }
                   /*  else if (lan == "PYTHON")
                     {
                         textBox1.AppendText(".py");
                         textBox1.ReadOnly = true;
                     }
                     /*  else if (lan == "HTML")
                       {
                           textBox1.Text = ".html";
                           textBox1.ReadOnly = true;
                       }
                       /*  if (lan == "RUBY")
                         {
                             textBox1.AppendText( ".ruby");
                             textBox1.ReadOnly = true;
                         }
                         /* else if (lan == "ASP.NET")
                          {
                              textBox1.AppendText(".aspx");
                              textBox1.ReadOnly = true;
                          }
                          /*  else if (lan == "PHP")
                            {
                                textBox1.AppendText(".php");
                                textBox1.ReadOnly = true;
                            }
                            /*  else if (lan == "JAVASCRIPT")
                              {
                                  textBox1.AppendText(".json");
                                  textBox1.ReadOnly = true;
                              }
                             /* else if (lan == "GOLANG")
                              {
                                  textBox1.AppendText( ".go");
                                  textBox1.ReadOnly = true;
                              }*/


           




            SqlConnection conp = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                conp.Open();
                SqlCommand cndp = conp.CreateCommand();
                cndp.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";
                cndp.CommandText = "SELECT * FROM system";
                try
                {
                    SqlDataReader dr = cndp.ExecuteReader();
                    while (dr.Read())
                    {
                        // TreeNode n = new TreeNode(dr["link"].ToString());
                        listBox1.Items.Add(dr["link"].ToString());

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        
           // List<string> listcolllection = new List<string>();
            foreach (string str in listBox1.Items)
            {
                listcolllection.Add(str);
                textBox1.CharacterCasing = CharacterCasing.Lower;
            }
        }
        private void Middle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        List<string> listcolllection = new List<string>();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                listBox1.Items.Clear();
                foreach (string s in listcolllection)
                {
                    if (s.Contains(textBox1.Text))
                    // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                    {
                        listBox1.Items.Add(s);

                    }


                }

            }
            else if (textBox1.Text == "")
            {
                listBox1.Items.Clear();
                foreach (string str in listcolllection)
                {
                    listBox1.Items.Add(str);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Github") { 
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = System.Data.CommandType.Text;
            cd.CommandText = "DELETE FROM Ushine";
            try
            {
                cd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            // var options = new ChromeOptions();
            //options.AddArgument("headless");
            driver = new ChromeDriver(driverService);

            List<string> listcolllection = new List<string>();
            foreach (string str in listBox1.Items)
            {
                listcolllection.Add(str);
                textBox1.CharacterCasing = CharacterCasing.Lower;
                checkgithub(str);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Ushine(link,star,watches,code,Query) values('" + str + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','"+textBox5.Text+"')";
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                richTextBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
            if (textBox4.Text == "Geeks for Geeks")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cd = con.CreateCommand();
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "DELETE FROM Ugeeks";
                try
                {
                    cd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                // var options = new ChromeOptions();
                //options.AddArgument("headless");
                driver = new ChromeDriver(driverService);

                List<string> listcolllection = new List<string>();
                foreach (string str in listBox1.Items)
                {
                    listcolllection.Add(str);
                    textBox1.CharacterCasing = CharacterCasing.Lower;
                    checkgeeks(str);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;


                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                        cmd.CommandText = "insert into Ugeeks(link,code,Query) values('" + str + "','" + richTextBox1.Text + "','" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            if (textBox4.Text == "Programiz")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cd = con.CreateCommand();
                cd.CommandType = System.Data.CommandType.Text;
                cd.CommandText = "DELETE FROM Uprogramiz";
                try
                {
                    cd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                // var options = new ChromeOptions();
                //options.AddArgument("headless");
                driver = new ChromeDriver(driverService);

                List<string> listcolllection = new List<string>();
                foreach (string str in listBox1.Items)
                {
                    listcolllection.Add(str);
                    textBox1.CharacterCasing = CharacterCasing.Lower;
                    checkprogramiz(str);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;


                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                        cmd.CommandText = "insert into Uprogramiz(link,code,Query) values('" + str + "','" + richTextBox1.Text + "','"+textBox5.Text+"')";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }

        }

        private void checkprogramiz(string str)
        {
            string selected = str;

            driver.Navigate().GoToUrl("https://www.programiz.com" + selected);
            // webBrowser1.Navigate(selected);

            IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//div[@class='content']"));

            foreach (IWebElement i in searchElements)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);
                var inputs = htmlDocument.DocumentNode.Descendants("pre").ToList();
                foreach (var items in inputs)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument1.LoadHtml(items.InnerHtml);

                    var tds = htmlDocument1.DocumentNode.Descendants("code").ToList();
                    var links = htmlDocument1.DocumentNode.Descendants("a");


                    if (tds.Count != 0)
                        foreach (var node in tds)
                        {
                           // richTextBox1.AppendText("\t\n");

                            richTextBox1.AppendText(node.InnerText.Trim() ?? " ");
                           // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                            //richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                            //richTextBox1.Font = new Font("Georgia", 8);

                        }

                }
            }
        }

        private void checkgeeks(string str)
        {
            string selected = str;
            driver.Navigate().GoToUrl(selected);

            // webBrowser1.Navigate(selected);

            IList<IWebElement> searchElements = driver.FindElements(By.Id("content"));

            foreach (IWebElement i in searchElements)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);
                var inputs = htmlDocument.DocumentNode.Descendants("article").ToList();
                foreach (var items in inputs)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument1.LoadHtml(items.InnerHtml);

                    var tds = htmlDocument1.DocumentNode.Descendants("div").ToList();
                    var links = htmlDocument1.DocumentNode.Descendants("a");


                    if (tds.Count != 0)
                        foreach (var node in tds)
                        {
                            richTextBox1.AppendText("\t\n");

                            richTextBox1.AppendText(node.InnerText.Trim() ?? " ");
                            // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                            //  richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                            //  richTextBox1.Font = new Font("Georgia", 8);

                        }
                }
            }
        }

        private void checkgithub(string str)
        {
            string selected = str;



            driver.Navigate().GoToUrl("https://github.com" + selected);
            //webBrowser1.Navigate("https://github.com" + selected);

            IList<IWebElement> SER = driver.FindElements(By.TagName("main"));
            foreach (IWebElement i in SER)
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                var text = i.GetAttribute("innerHTML");
                htmlDocument.LoadHtml(text);

                var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                foreach (var items in inputs)
                {

                    IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//ul[@class='pagehead-actions flex-shrink-0 ']"));
                    foreach (IWebElement iM in searchElements)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocumentM = new HtmlAgilityPack.HtmlDocument();
                        var textM = i.GetAttribute("innerHTML");
                        htmlDocumentM.LoadHtml(text);
                        //var tds = htmlDocument.DocumentNode.Descendants("li").ToList();
                        var watches = htmlDocumentM.DocumentNode.SelectSingleNode(".//a[@class='social-count js-social-count']");
                        // var star = htmlDocument.DocumentNode.SelectSingleNode(".// foam[@class='starred js-social-form']  a[@class='social-count js-social-count']");
                        var folk = htmlDocumentM.DocumentNode.SelectSingleNode(".//a[@class='social-count']");

                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);


                        var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {
                                //

                                richTextBox1.AppendText(node.InnerText + "\t\r");


                            }
                        textBox2.AppendText(watches.InnerText);
                        textBox3.AppendText(folk.InnerText);

                    }
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string Selected = listBox1.SelectedItem.ToString();
            
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (textBox4.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "'";
            try
            {
                SqlDataReader dr = cnd.ExecuteReader();
                while (dr.Read())
                {


                    textBox2.AppendText(dr["star"].ToString());
                    textBox3.AppendText(dr["watches"].ToString());
                    richTextBox1.AppendText(dr["Code"].ToString());

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            if (textBox4.Text == "Geeks for Geeks")
            {
                cnd.CommandText = "SELECT * FROM Ugeeks WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        richTextBox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox4.Text == "Programiz")
            {
                cnd.CommandText = "SELECT * FROM Uprogramiz WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        richTextBox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //driver.Close();
            Recommand rank = new Recommand(textBox4.Text,textBox5.Text);
            rank.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Here Are the Language Extensions\n\n\n " +
               "C#-->.cs\n" +
               "C++-->.cpp\n" +
               "C--->.c\n" +
               "PYTHON-->.py\n" +
               "HTML-->.html\n" +
               "RUBY-->.ruby\n" +
               "GOLANG-->.go\n" +
               "JAVASCRIPT-->.json\n" +
               "PHP-->.php\n" +
               "ASP.NET-->.aspx\n");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Language Extension";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Language Extension")
            {
               textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
    }
}
