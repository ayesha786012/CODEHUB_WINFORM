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
using System.IO;

using System.Data.SqlClient;
using System.Linq.Expressions;

namespace webs
{
    public partial class Recommend : Form
    {
        public IWebDriver driver;
        public TreeNode Node { get; set; }
        public string NODE { get; set; }
        public Recommend(string source, string query)
        {
            InitializeComponent();

            textBox4.AppendText( query);
            textBox4.ReadOnly = true;

            textBox3.AppendText(source);
            textBox3.ReadOnly = true;
          

            // string recg = node.Text;
            // TreeNode note = new TreeNode(recg);

            // treeView1.Nodes.Add(node);


        }
        /*  public Recommend(TreeNode node)
            {
                var href = node.Text;
                // array(href);
                TreeNode note = new TreeNode(href);
                try
                {
                    treeView1.Nodes.Add(note);
                }
                     catch  {
                    MessageBox.Show("no");
                        }
            }*/



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Recommend_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recommand rank = new Recommand();
            rank.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //End end = new End();
            // end.ShowDialog();
            report report = new report();
            report.ShowDialog();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            listBox1.Items.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (textBox3.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine ";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listBox1.Items.Add(dt.Rows[0]["link"].ToString());
                        listBox1.Items.Add(dt.Rows[1]["link"].ToString());
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();



                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox3.Text == "Geeks for Geeks")
            {
                cnd.CommandText = "SELECT * FROM Ugeeks ";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listBox1.Items.Add(dt.Rows[0]["link"].ToString());
                        listBox1.Items.Add(dt.Rows[1]["link"].ToString());
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();



                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox3.Text == "Programiz")
            {
                cnd.CommandText = "SELECT * FROM Uprogramiz ";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        listBox1.Items.Add(dt.Rows[0]["link"].ToString());
                        listBox1.Items.Add(dt.Rows[1]["link"].ToString());
                        // textBox4.Text = "\t";
                        //  textBox5.Text = dt.Rows[1]["link"].ToString();
                        //  textBox6.Text = dt.Rows[2]["link"].ToString();


                        // listBox1.Items.Add(dr["link"]);
                        //   textBox4.AppendText(dr();



                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            con.Close();
            
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //  readfile();
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
                        await sw.WriteLineAsync(richTextBox1.Text);
                    MessageBox.Show("Successfully Saved !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection coni = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            coni.Open();
            SqlCommand cndi = coni.CreateCommand();
            cndi.CommandType = System.Data.CommandType.Text;
            // cnd.CommandText = "SELECT URL FROM Codehub WHERE id = 1";
            try
            {
                cndi.CommandText = "select * from Report where Query='"+textBox4.Text+"' update Report set Recommended ='"+listBox1.Items.ToString()+"' where Query='"+textBox4.Text+"'" ;
                cndi.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            coni.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        

        {
            string Selected = listBox1.SelectedItem.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandType = System.Data.CommandType.Text;
            //   cnd.CommandText = "select * from Codehub";
            if (textBox3.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                       // textBox2.AppendText(dr["star"].ToString());
                       // textBox1.AppendText(dr["watches"].ToString());
                        richTextBox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox3.Text == "Geeks for Geeks")
            {
                cnd.CommandText = "SELECT * FROM Ugeeks WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());

                        richTextBox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox3.Text == "Programiz")
            {
                cnd.CommandText = "SELECT * FROM Uprogramiz WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        // textBox2.AppendText(dr["star"].ToString());
                        //textBox3.AppendText(dr["watches"].ToString());

                        richTextBox1.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Recommend_Load_1(object sender, EventArgs e)
        {

        }
    }
}

     /*   private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                MessageBox.Show("You are Selected!", "Selected",
      MessageBoxButtons.OK,
      MessageBoxIcon.Information);


            }
            else
            {

                // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                richTextBox1.Text = "";
            string selected = e.Node.Text;
            DialogResult result = MessageBox.Show("Are You Select The Github Source in previous", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("headless");
            driver = new ChromeDriver(driverService, options);
            if (result == DialogResult.Yes)

            {
                driver.Navigate().GoToUrl("https://github.com" + selected);
                IList<IWebElement> searchElements = driver.FindElements(By.TagName("main"));

                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    // var ulitem = htmlDocument.DocumentNode.SelectNodes(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                    var ulitem = htmlDocument.DocumentNode.Descendants(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                    var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);





                        var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {
                                richTextBox1.AppendText("\t\n");

                                richTextBox1.AppendText(node.InnerText + "\t\r");
                                // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                // richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                // richTextBox1.Font = new Font("Georgia", 8);

                            }


                        richTextBox1.AppendText("\t\r");


                        try
                        {
                            var read = htmlDocument.DocumentNode.Descendants("pre");
                            //  richTextBox1.AppendText("\t\nREADME \n");
                            foreach (var red in read)
                            {


                                richTextBox1.AppendText(red.InnerText.Trim() ?? " ");
                                this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                // MessageBox.Show(red.InnerText);

                            }
                            richTextBox1.AppendText("\n\n\n");
                        }
                        catch
                        {
                            MessageBox.Show("ReadMe Does't Exits");
                        }
                        richTextBox1.AppendText("\n\n\n");
                        // richTextBox1.AppendText("\n\nSOURCE_CODE\n");

                        try

                        {
                            var links = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();




                            foreach (var link in links)
                            {
                                string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                // array(href);
                                TreeNode node = new TreeNode(href);
                                treeView1.SelectedNode = e.Node;

                                treeView1.SelectedNode.Nodes.Add(node);

                                /*  string[] sentences =
            {                                        };
                                  _ = e.Node;
                                  string sPattern = ".cs";
                                  foreach (string s in sentences)
                                  {


                                      if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                      {
                                          treeView1.SelectedNode.Nodes.Add(node);
                                          //MessageBox.Show($"  (match for '{sPattern}' found)");
                                      }
                                      else
                                      {

                                          MessageBox.Show("none");
                                      }
                                  }
                            }

                        }
                        catch
                        {
                            /*  MessageBox.Show("furthur Links", "Information",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
                            // MessageBox.Show("hello");
                        }

                        treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);



                        try

                        {
                            var links = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();




                            foreach (var link in links)
                            {
                                string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                // array(href);
                                TreeNode node = new TreeNode(href);
                                treeView1.SelectedNode = e.Node;

                                treeView1.SelectedNode.Nodes.Add(node);

                                /*  string[] sentences =
            {                                        };
                                  _ = e.Node;
                                  string sPattern = ".cs";
                                  foreach (string s in sentences)
                                  {


                                      if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                      {
                                          treeView1.SelectedNode.Nodes.Add(node);
                                          //MessageBox.Show($"  (match for '{sPattern}' found)");
                                      }
                                      else
                                      {

                                          MessageBox.Show("none");
                                      }
                                  }
                            }

                        }
                        catch
                        {
                            /*  MessageBox.Show("furthur Links", "Information",
      MessageBoxButtons.OK,
      MessageBoxIcon.Information);
                            // MessageBox.Show("hello");
                        }

                        treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);
                        // }
                        richTextBox1.AppendText("\n\n\n");

                        /*foreach (var it in ulitem)
                        {
                            HtmlAgilityPack.HtmlDocument htmlDocument2 = new HtmlAgilityPack.HtmlDocument();
                            htmlDocument2.LoadHtml(it.InnerHtml);
                            var td = htmlDocument2.DocumentNode.SelectNodes("li").ToList();

                           foreach (var boy in td)
                            {
                                HtmlAgilityPack.HtmlDocument htmlDocument3 = new HtmlAgilityPack.HtmlDocument();
                                htmlDocument3.LoadHtml(boy.InnerHtml);
                                richTextBox1.AppendText("\t\n");
                                var reffer = htmlDocument3.DocumentNode.SelectSingleNode(".//a[@class='social-count js-social-count']");
                                // foreach (var rw in reffer)
                                //{
                                richTextBox1.AppendText(reffer.InnerText + "\t\r");
                                // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                // richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                // richTextBox1.Font = new Font("Georgia", 8);
                                richTextBox1.AppendText("\n\n\n");
                                //}
                            }

                        }

                    }



                        treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);

                        richTextBox1.AppendText("\n\n\n");

                    }
                }
                //webBrowser1.Navigate("https://github.com" + selected);
                if (result == DialogResult.No)
                {
                    DialogResult resulto = MessageBox.Show("Are You Select The GeeksSource Source in previous", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulto == DialogResult.Yes)
                    {
                        var driverServicegeeks = ChromeDriverService.CreateDefaultService();
                        driverService.HideCommandPromptWindow = true;
                        var optionsgeeks = new ChromeOptions();
                        options.AddArgument("headless");
                        driver = new ChromeDriver(driverServicegeeks, optionsgeeks);
                        driver.Navigate().GoToUrl(selected);




                        IList<IWebElement> searchElementsg = driver.FindElements(By.Id("content"));

                        foreach (IWebElement i in searchElementsg)
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
                                        this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                        richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                        richTextBox1.Font = new Font("Georgia", 8);

                                    }
                                try
                                {
                                    var read = htmlDocument.DocumentNode.Descendants("p");
                                    //  richTextBox1.AppendText("\t\nREADME \n");
                                    foreach (var red in read)
                                    {


                                        richTextBox1.AppendText(red.InnerText.Trim() ?? " ");
                                        this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                        richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                        // MessageBox.Show(red.InnerText);

                                    }
                                    // richTextBox1.AppendText("\n\n\n");
                                }
                                catch
                                {
                                    MessageBox.Show("ReadMe Does't Exits");
                                }
                                richTextBox1.AppendText("\n\n\n");                 // richTextBox1.AppendText("\n\nSOURCE_CODE\n");
                                /*  foreach (var link in links)
                                  {

                                      string href = link.GetAttributeValue("href", string.Empty);
                                      // richTextBox2.AppendText("-----------------------------\n\n\n");
                                      // array(href);
                                      TreeNode node = new TreeNode(href);
                                      treeView1.SelectedNode = e.Node;
                                      treeView1.SelectedNode.Nodes.Add(node);

                                      /*  string[] sentences =
                  {                                        };
                                        _ = e.Node;
                                        string sPattern = ".cs";
                                        foreach (string s in sentences)
                                        {


                                            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                            {
                                                treeView1.SelectedNode.Nodes.Add(node);
                                                //MessageBox.Show($"  (match for '{sPattern}' found)");
                                            }
                                            else
                                            {

                                                MessageBox.Show("none");
                                            }
                                        }



                                //  treeView1.Font = new Font("calibiri", 10);
                                richTextBox1.Font = new Font("Georgia", 10);
                                //listView2.BackColor = Color.Blue;
                                //     string selectedo = treeView1.SelectedNode.Text;
                                // MessageBox.Show(selectedo);
                            }
                            richTextBox1.AppendText("\n\n\n");

                        }


                    }
                    if (resulto == DialogResult.No)
                    {

                        var driverServicepro = ChromeDriverService.CreateDefaultService();
                        driverService.HideCommandPromptWindow = true;
                        var optionspro = new ChromeOptions();
                        options.AddArgument("headless");
                        driver = new ChromeDriver(driverServicepro, optionspro);

                        driver.Navigate().GoToUrl("https://www.programiz.com" + selected);
                        // webBrowser1.Navigate(selected);

                        IList<IWebElement> searchElementsp = driver.FindElements(By.XPath(".//div[@class='content']"));

                        foreach (IWebElement i in searchElementsp)
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
                                        richTextBox1.AppendText("\t\n");

                                        richTextBox1.AppendText(node.InnerText.Trim() ?? " ");
                                        this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                        richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                        richTextBox1.Font = new Font("Georgia", 8);

                                    }
                                try
                                {
                                    var read = htmlDocument.DocumentNode.Descendants("pre");
                                    //  richTextBox1.AppendText("\t\nREADME \n");
                                    foreach (var red in read)
                                    {


                                        richTextBox1.AppendText(red.InnerText.Trim() ?? " ");
                                        this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                        richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                        // MessageBox.Show(red.InnerText);

                                    }
                                    richTextBox1.AppendText("\n\n\n");
                                }
                                catch
                                {
                                    MessageBox.Show("ReadMe Does't Exits");
                                }
                                richTextBox1.AppendText("\n\n\n");                 // richTextBox1.AppendText("\n\nSOURCE_CODE\n");
                                /*  foreach (var link in links)
                                  {

                                      string href = link.GetAttributeValue("href", string.Empty);
                                      // richTextBox2.AppendText("-----------------------------\n\n\n");
                                      // array(href);
                                      TreeNode node = new TreeNode(href);
                                      treeView1.SelectedNode = e.Node;
                                      treeView1.SelectedNode.Nodes.Add(node);

                                      /*  string[] sentences =
                  {                                        };
                                        _ = e.Node;
                                        string sPattern = ".cs";
                                        foreach (string s in sentences)
                                        {


                                            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                            {
                                                treeView1.SelectedNode.Nodes.Add(node);
                                                //MessageBox.Show($"  (match for '{sPattern}' found)");
                                            }
                                            else
                                            {

                                                MessageBox.Show("none");
                                            }
                                        }



                                //  treeView1.Font = new Font("calibiri", 10);
                                richTextBox1.Font = new Font("Georgia", 10);
                                //listView2.BackColor = Color.Blue;
                                //     string selectedo = treeView1.SelectedNode.Text;
                                // MessageBox.Show(selectedo);
                            }
                            richTextBox1.AppendText("\n\n\n");

                        }


                    }

                }




            }



        }
    }
    }
}*/