using HtmlAgilityPack;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

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
    
    public partial class Form1 : Form
    {
        public IWebDriver driver;

        public Form1()
        {
            
            InitializeComponent();
            Start start = new Start();
            start.ShowDialog();
        }

        public void Open_Browser()
        {


            string search = tburl.Text;

            string language = comboBox1.Text;

            if (Radiogit.Checked == true)

            {
                panel2.Visible = false;
                panel1.Visible = true;
               
                this.BackgroundImage = Properties.Resources.black_polygonal_background_1055_564;


                //pictureBox1.Image = null;
                pictureBox1.BackgroundImage = Properties.Resources._39_394908_github_octocat;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            opengit();
                            break;
                        case "C#":
                            language = "C%23";
                            opengit();
                            break;
                        default:
                            opengit();
                            break;
                    }

                }


                catch
                {
                    throw;
                }

                void opengit()
                {

                    var searchString = search;
                    searchString = searchString.Replace(" ", "+");
                    /* HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                       // document.Load(@"C:\Users\Windows 10\Documents\git.txt");
                       var Webget = new HtmlWeb();
                       document = Webget.Load("https://github.com/search?utf8=%E2%9C%93&q=" + searchString + "&type=");
                       HtmlNode[] aNodes2 = document.DocumentNode.SelectNodes("//ul[@class='repo-list']").ToArray();
                       string htmlString = aNodes2.FirstOrDefault().InnerHtml.Trim();
                       htmlString = htmlString.Replace("href=\"", "href=\"https://github.com");*/


                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                  //  var options = new ChromeOptions();
                  //  options.AddArgument("headless");
                    driver = new ChromeDriver(driverService);
                    driver.Navigate().GoToUrl("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                    //webBrowser1.Navigate("https://github.com/search?l=" + language + "&q=" + searchString + "&type=" + "Repositories");

                }

            }
         else   if (radiogeeks.Checked == true)
            {
                panel2.Visible = true;
                
               // panel1.Visible = false;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            opengeeks();
                            break;


                        case "C#":

                            language = "C%23";
                            opengeeks();
                            break;
                        default:
                            opengeeks();
                            break;
                    }



                }


                catch
                {
                    throw;
                }
                void opengeeks()
                {

                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService, options);
                    driver.Navigate().GoToUrl("https://www.geeksforgeeks.org/?s=" + search + "+in+" + language);
                    //  webBrowser1.Navigate("https://www.geeksforgeeks.org/?s=" + search + "in" + language);

                }
            }
         else   if (radioprogramiz.Checked == true)
            {
                
                panel2.Visible = true;
               // panel1.Visible = false;
                try
                {

                    switch (language)
                    {
                        case "C++":

                            language = "C%2B%2B";
                            openprogramiz();
                            break;


                        case "C#":
                            language = "C%23";
                            openprogramiz();

                            break;
                        default:
                            openprogramiz();
                            break;
                    }



                }


                catch
                {
                    throw;
                }
                void openprogramiz()
                {


                    var driverService = ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(driverService, options);
                    driver.Navigate().GoToUrl("https://www.programiz.com/search/" + search + " " + "in" + " " + language);
                    //webBrowser1.Navigate("https://www.programiz.com/search/" + search + " " + "in" + " " + language);
                }

            }
        }
       // string query = tburl.Text;
        private void btnopenbrowser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
           /* con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = System.Data.CommandType.Text;
            cd.CommandText = "DELETE FROM Report";
            try
            {
                cd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            con.Close();
            string name = textBox1.Text;
            string languge=comboBox1.Text;
            string query = tburl.Text;
            string password = textBox2.Text;
            string time = DateTime.Now.ToLongTimeString();
            string date = DateTime.Now.ToLongDateString();
            string search = "Keyword-Based-Search";
            string Email = textBox3.Text;
            //  int remark = 5;
            if (Radiogit.Checked)
            {
                string source = "Github";

                try
                {
                   // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','"+source+"','"+time+"','"+date+ "','" + search + "','" + password + "','"+Email+"')";
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            if (radiogeeks.Checked)
            {
                string source = "Geeks for Geeks";

                try
                {
                  //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                    cmd.ExecuteNonQuery();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            if (radioprogramiz.Checked)
            {
                string source = "Programiz";

                try
                {
                    //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;


                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                    cmd.CommandText = "insert into Report(Name,Language,Query,Source,Time,Date,Search,password,Email) values('" + name + "','" + languge + "','" + query + "','" + source + "','" + time + "','" + date + "','" + search + "','" + password + "','" + Email + "')";
                    cmd.ExecuteNonQuery();
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            if (comboBox1.Text == "Select Language" || tburl.Text == "Enter Query")
            {

                MessageBox.Show("Mendatory Fields Must Be Filled!", "NullExceptions",
     MessageBoxButtons.OK,
     MessageBoxIcon.Warning // for Warning  
                            //MessageBoxIcon.Error // for Error 
                            //MessageBoxIcon.Information  // for Information
                            //MessageBoxIcon.Question // for Question
    );


                //  MessageBox.Show("Mendatory Fields Must Be Filled!");
              
            }
           
            else
            {


                using (PROGRESSBAR pr = new PROGRESSBAR(savedata))
                {


                    pr.ShowDialog(this);

                    Open_Browser();
                }
            }

        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            if (driver != null)
                driver.Quit();
            richTextBox1.Text = "";
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView1.BackColor = System.Drawing.Color.White;
            listView2.BackColor = System.Drawing.Color.White;
            treeView1.Nodes.Clear();
            this.BackgroundImage = Properties.Resources.images__3_;
            tburl.Text = "Enter Query";
            comboBox1.Text = "Select Language";
            //webBrowser1.Stop();
           // webBrowser1.Navigate("about:blank");
            if (Radiogit.Checked = true || radiogeeks.Checked == true || radioprogramiz.Checked == true) ;
            {
                Radiogit.Checked = false;
                radioprogramiz.Checked = false;
                radiogeeks.Checked = false;
            }


        }

        private void btnscrape_Click(object sender, EventArgs e)
        {
            Find_Data();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tburl_TextChanged(object sender, EventArgs e)
        {

        }

        Timer t1 = new Timer();
        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

        /*  Opacity = 0;      //first the opacity is 0

          t1.Interval = 10;  //we'll increase the opacity every 10ms
          t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
          t1.Start();
      }

      void fadeIn(object sender, EventArgs e)
      {
          if (Opacity >= 1)
              t1.Stop();   //this stops the timer if the form is completely displayed
          else
              Opacity += 0.05;
      }*/
        

        private void Find_Data()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
            con.Open();
             SqlCommand cd = con.CreateCommand();
             cd.CommandType = System.Data.CommandType.Text;
             cd.CommandText = "DELETE FROM system";
             try
             {
                 cd.ExecuteNonQuery();
                 con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

            if (Radiogit.Checked == true)
            {
                IList<IWebElement> searchElements = driver.FindElements(By.XPath(".//ul[@class='repo-list']"));
                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var tds = htmlDocument.DocumentNode.Descendants("li").ToList();

                    var links = htmlDocument.DocumentNode.SelectNodes(".//a[@class='v-align-middle']").ToList();

                    if (tds.Count != 0)

                        foreach (var node in tds)
                        {
                            //node= Regex.Replace(node.InnerText, @"( |\t|\r?\n)\1+", "$1"); 

                            /* richTextBox1.AppendText("-----------------------------\n\n\n");


                             //  string data = node.InnerText;

                             richTextBox1.AppendText(node.InnerText.Trim() ?? " ");
                             this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                             richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");*/

                            //string nodes = node;




                            listView1.View = View.List;
                            listView1.Columns.Add("", 150);
                            listView1.BackColor = System.Drawing.Color.LightPink;
                            listView1.ForeColor = System.Drawing.Color.Black;
                            listView1.Font = new Font("Georgia", 8);
                            listView1.Items.Add(node.InnerText.Trim() ?? " ");


                            this.listView1.Text = this.listView1.Text.Trim();
                            listView1.Text = Regex.Replace(listView1.Text, "", "");

                            listView1.Items.Add("__________________________________________________________________");




                        }
                    foreach (var link in links)
                    {
                        //  var linko= link.SelectSingleNode(".//a[@class='v-align-middle']");
                        // var linko = de
                        var href = link.GetAttributeValue("href", string.Empty);
                        // array(href);
                        TreeNode node = new TreeNode(href);

                        treeView1.Nodes.Add(node);
                       // Rank n = new Rank(node);
                        Collection(node);

                        //listView2.Items.Add("\n\n\n");
                        //  listView1.Items.Add("______________________________");

                        // TreeNode node = new TreeNode(textBox1.Text);
                        // treeView1.Nodes.Add(node);

                    }


                }
            }

            if (radiogeeks.Checked == true)
            {
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

                                listView1.View = View.List;
                                listView1.Columns.Add("", 150);
                                listView1.BackColor = System.Drawing.Color.LightPink;
                                listView1.ForeColor = System.Drawing.Color.Black;
                                listView1.Font = new Font("Georgia", 8);
                                listView1.Items.Add(node.InnerText.Trim() ?? " ");


                                this.listView1.Text = this.listView1.Text.Trim();
                                listView1.Text = Regex.Replace(listView1.Text, "", "");

                                listView1.Items.Add("__________________________________________________________________");

                            }

                        foreach (var link in links)
                        {
                            var href = link.GetAttributeValue("href", string.Empty);
                            listView2.View = View.List;
                            listView2.Columns.Add("", 150);
                            listView2.BackColor = System.Drawing.Color.LightGreen;
                            listView2.ForeColor = System.Drawing.Color.Black;
                            listView2.Font = new Font("Georgia", 8);
                            listView2.Items.Add(href);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = System.Data.CommandType.Text;


                            // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                           // cmd.CommandText = "insert into Codehub values('" + href + "')";
                            cmd.CommandText = "insert into system(link) values('" + href + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            this.listView2.Text = this.listView1.Text.Trim();
                            listView2.Text = Regex.Replace(listView1.Text, "", "");

                            listView2.Items.Add("__________________________________________________________________");

                        }




                    }
                }
            }
            if (radioprogramiz.Checked == true)
            {
                IList<IWebElement> searchElements = driver.FindElements(By.ClassName("col-sm-12"));
                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var inputs = htmlDocument.DocumentNode.Descendants("div").ToList();
                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);
                        var tds = htmlDocument1.DocumentNode.Descendants("p").ToList();
                        var links = htmlDocument1.DocumentNode.Descendants("a");

                        if (tds.Count != 0)
                            foreach (var node in tds)
                            {
                                //richTextBox1.AppendText("-----------------------------\n\n\n");

                                listView1.View =View.List;
                                listView1.Columns.Add("", 150);
                                listView1.BackColor = System.Drawing.Color.LightPink;
                                listView1.ForeColor = System.Drawing.Color.Black;
                                listView1.Font = new Font("Georgia", 8);
                                listView1.Items.Add(node.InnerText.Trim() ?? " ");


                                this.listView1.Text = this.listView1.Text.Trim();
                                listView1.Text = Regex.Replace(listView1.Text, "", "");

                                listView1.Items.Add("__________________________________________________________________");


                            }

                        foreach (var link in links)
                        {
                            // var href = link.GetAttributeValue("href", string.Empty);
                            // richTextBox2.AppendText("-----------------------------\n\n\n");
                            var href = link.GetAttributeValue("href", string.Empty);
                            listView2.View =View.List;
                            listView2.Columns.Add("", 150);
                            listView2.BackColor = System.Drawing.Color.Green;
                            listView2.ForeColor = System.Drawing.Color.Black;
                            listView2.Font = new Font("Georgia", 8);
                            listView2.Items.Add(href);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = System.Data.CommandType.Text;


                            // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            // cmd.CommandText = "insert into Codehub values('" + href + "')";
                            cmd.CommandText = "insert into system(link) values('" + href + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            this.listView2.Text = this.listView1.Text.Trim();
                            listView2.Text = Regex.Replace(listView1.Text, "", "");

                            listView2.Items.Add("__________________________________________________________________");

                        }


                    }

                }
            }
            /*TreeNode nodle = treeView1.SelectedNode;
            Recommend n = new Recommend( nodle
                );*/

        }


        void Collection(TreeNode node)
        {

            richTextBox1.Text = "";
            string selected = node.Text;
            driver.Navigate().GoToUrl("https://github.com" + selected);


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

                        try
                        {
                            var linkso = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();

                            foreach (var link in linkso)
                            {

                                string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                //array(href);
                                TreeNode note = new TreeNode(href);
                                treeView1.SelectedNode = node;
                                treeView1.SelectedNode.Nodes.Add(note);

                                try
                                {
                                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                                    con.Open();
                                    SqlCommand cmd = con.CreateCommand();
                                    cmd.CommandType = System.Data.CommandType.Text;


                                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                                    cmd.CommandText = "insert into system(link,star,watches) values('" + href + "','" + watches.InnerText + "','" + folk.InnerText + "')";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //con.Close();


                                collection2(note);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                  
                }
               
                treeView1.Font = new Font("calibiri", 10);
                richTextBox1.Font = new Font("Georgia", 10);
                //listView2.BackColor = Color.Blue;
                //     string selectedo = treeView1.SelectedNode.Text;
                // MessageBox.Show(selectedo);
            }
            richTextBox1.AppendText("\n\n\n");

        }

        private void collection2(TreeNode note)
        
        {

            richTextBox1.Text = "";
            string selected = note.Text;
            driver.Navigate().GoToUrl("https://github.com" + selected);


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

                        try
                        {
                            var linkso = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();

                            foreach (var link in linkso)
                            {

                                string href = link.GetAttributeValue("href", string.Empty);
                                // richTextBox2.AppendText("-----------------------------\n\n\n");
                                //array(href);
                                TreeNode notei = new TreeNode(href);
                                treeView1.SelectedNode = note;
                                treeView1.SelectedNode.Nodes.Add(notei);

                                try
                                {
                                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                                    con.Open();
                                    SqlCommand cmd = con.CreateCommand();
                                    cmd.CommandType = System.Data.CommandType.Text;


                                    // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                                    cmd.CommandText = "insert into system(link,star,watches) values('" + href + "','" + watches.InnerText + "','" + folk.InnerText + "')";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //con.Close();


                                //collection2(note);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                treeView1.Font = new Font("calibiri", 10);
                richTextBox1.Font = new Font("Georgia", 10);
                //listView2.BackColor = Color.Blue;
                //     string selectedo = treeView1.SelectedNode.Text;
                // MessageBox.Show(selectedo);
            }
            richTextBox1.AppendText("\n\n\n");

        }


        /*   private void Code(TreeNode e)
            {

                richTextBox1.Text = "";
                        string selected = e.Text;
                        //     DialogResult result = MessageBox.Show("Do you want to select this" + e.Node.Text, "Notify", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);




                        driver.Navigate().GoToUrl("https://github.com" + selected);
                        //webBrowser1.Navigate("https://github.com" + selected);

                        IList<IWebElement> searchElements = driver.FindElements(By.TagName("main"));

                        foreach (IWebElement i in searchElements)
                        {
                            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                            var text = i.GetAttribute("innerHTML");
                            htmlDocument.LoadHtml(text);
                            // var ulitem = htmlDocument.DocumentNode.SelectNodes(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                         //   var ulitem = htmlDocument.DocumentNode.Descendants(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                            var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                            foreach (var items in inputs)
                            {
                                HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                                htmlDocument1.LoadHtml(items.InnerHtml);

                                var tds = htmlDocument1.DocumentNode.SelectNodes("tr").ToList();

                                if (tds.Count != 0)
                                    foreach (var nodeb in tds)
                                {
                                    try
                                    {
                                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");
                                    con.Open();
                                        SqlCommand cmd = con.CreateCommand();
                                        cmd.CommandType = System.Data.CommandType.Text;


                                        // MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        //cmd.CommandText = "insert into Codehub (URL) values('" + note.Text+"')";
                                        cmd.CommandText = "insert into system(code) values('" + nodeb.InnerText + "')";
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                              //  con.Close();
                                richTextBox1.AppendText("\t\n");

                                        richTextBox1.AppendText(nodeb.InnerText + "\t\r");
                                        // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                                        // richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                                        // richTextBox1.Font = new Font("Georgia", 8);

                                    }


                                richTextBox1.AppendText("\t\r");




                        }

                    }


            }*/





        /* string saverepo(string innerText)
          {
              string title = innerText;
              return title;

          }*/



        /* public void Open()
         {

             var driverService = ChromeDriverService.CreateDefaultService();
             driverService.HideCommandPromptWindow = true;
             var options = new ChromeOptions();
             options.AddArgument("headless");
             driver = new ChromeDriver(driverService, options);
             try
             {
                 driver.Navigate().GoToUrl("https://money.cnn.com/data/hotstocks/index.html");
             }
             catch
             {
                 throw;
             }

         }*/
        private void radioprogramiz_CheckedChanged(object sender, EventArgs e)
        {

        }


      /*    void array(string hrefi)
            {
                string hreff = hrefi;

            Recommend = new Recommend(hreff);

          
            }
            */
        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            string selected = listView1.SelectedItems[0].SubItems[0].Text;
            MessageBox.Show(selected);
            // array(selected);
            // MessageBox.Show(selected);


        }
        /// <summary>
        /// ///////////////////
        /// </summary>


        /// <summary>
        /// //////////////////
        /// </summary>
        /// <param name="e"></param>
        /// 

        /*  void treeView(TreeNode e)
          {
              /*if (e.Nodes.Count > 0)
              {
                  MessageBox.Show("You are Selected!", "Selected",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);


              }
              else
              {

                  richTextBox1.Text = "";
                  string selected = e.Text;
                  /*var driverService = ChromeDriverService.CreateDefaultService();
                  driverService.HideCommandPromptWindow = true;
                  var options = new ChromeOptions();
                  options.AddArgument("headless");
                  driver = new ChromeDriver(driverService, options);

                  driver.Navigate().GoToUrl("https://github.com" + selected);
                 // webBrowser1.Navigate("https://github.com" + selected);

                  IList<IWebElement> searchElements = driver.FindElements(By.Name("main"));

                  foreach (IWebElement i in searchElements)
                  {
                      HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                      var text = i.GetAttribute("innerHTML");
                      htmlDocument.LoadHtml(text);
                      var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                      foreach (var items in inputs)
                      {
                          HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                          htmlDocument1.LoadHtml(items.InnerHtml);

                           var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();


                        //  var linkso = htmlDocument1.DocumentNode.Descendants("a").ToList();


                          /* if (tds.Count != 0)
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
                          try
                          {
                              var linkso = htmlDocument1.DocumentNode.SelectNodes(".//a[@class='js-navigation-open ']").ToList();

                              foreach (var link in linkso)
                              {

                                  string href = link.GetAttributeValue("href", string.Empty);
                                  // richTextBox2.AppendText("-----------------------------\n\n\n");
                                  // array(href);
                                  TreeNode node = new TreeNode(href);
                                  treeView1.SelectedNode = e;
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

                          }
                      }
                      treeView1.Font = new Font("calibiri", 10);
                      richTextBox1.Font = new Font("Georgia", 10);
                      //listView2.BackColor = Color.Blue;
                      //     string selectedo = treeView1.SelectedNode.Text;
                      // MessageBox.Show(selectedo);
                  }
                  richTextBox1.AppendText("\n\n\n");*/




        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /*   private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
           {

           }

           private void treeView_MouseClick(object sender, MouseEventArgs e)
           {

           }*/




        int ite = 0;

        //  public Recommend Recommend { get; private set; }

        private void treeView_nodemouseclick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Nodes.Count>0)
            {
                MessageBox.Show("You are Selected!", "Selected",
      MessageBoxButtons.OK,
      MessageBoxIcon.Information);


            }
            else
            {

                //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                richTextBox1.Text = "";
                string selected = e.Node.Text;

                //    DialogResult result = MessageBox.Show("Do you want to select this" + e.Node.Text, "Notify", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                /* var driverService = ChromeDriverService.CreateDefaultService();
                 driverService.HideCommandPromptWindow = true;
                 var options = new ChromeOptions();
                 options.AddArgument("headless");
                 driver = new ChromeDriver(driverService, options);*/


                driver.Navigate().GoToUrl("https://github.com" + selected);
                //webBrowser1.Navigate("https://github.com" + selected);

                IList<IWebElement> searchElements = driver.FindElements(By.TagName("main"));

                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    // var ulitem = htmlDocument.DocumentNode.SelectNodes(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                    // var ulitem = htmlDocument.DocumentNode.Descendants(".//ul[@class='pagehead-actions flex-shrink-0 ']").ToList();
                    var inputs = htmlDocument.DocumentNode.Descendants("tbody").ToList();
                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);

                        //  if (result == DialogResult.Yes)
                        //  {

                        //  Array(selected);

                        //  ite++;
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
                                  }*/
                            }

                        }
                        catch
                        {
                            /*  MessageBox.Show("furthur Links", "Information",
         MessageBoxButtons.OK,
         MessageBoxIcon.Information);*/
                            // MessageBox.Show("hello");
                        }

                        treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);

                        // }
                        // if (result == DialogResult.No)
                        // {
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
                                  }*/
                            }

                        }
                        catch
                        {
                            /*  MessageBox.Show("furthur Links", "Information",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);*/
                            // MessageBox.Show("hello");
                        }

                        treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);
                    }
                    richTextBox1.AppendText("\n\n\n");


                }

                //  }
                /* if (result == DialogResult.Cancel)
                 {
                     if (ite < 5)
                     {
                         MessageBox.Show("Plz Select Atleast 5 codefiles From Above Repositories");
                     }
                     else if (ite > 5)
                     {
                         MessageBox.Show("YOU ARE SELECTED " + ite + "Code files From Above Repositories");

                     }
                     else if (ite == 10)
                     {
                         MessageBox.Show("Stop Selecting YOU ARE SELECTED ALL" + ite + "Code files From Above Repositories");
                     }
                /// }*/




            }

        }

        
        //  SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picturebox(object sender, EventArgs e)
        {

        }

        private void textbox_enter(object sender, EventArgs e)
        {
            if (tburl.Text == "Enter Query")
            {
                tburl.Text = "";
                tburl.ForeColor = Color.Black;
            }
        }

        private void textbox_leave(object sender, EventArgs e)
        {
            if (tburl.Text == "")
            {
                tburl.Text = "Enter Query";
                tburl.ForeColor = Color.Gray;
            }
        }


        private void combo_enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select Language")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void combo_leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Select Language";
                comboBox1.ForeColor = Color.Gray;
            }
        }
        void savedata()
        {
            for (int i = 0; i <= 500; i++)
            {
                Thread.Sleep(10);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }


        private void circularProgressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //circularProgressBar1.Value = +1;
            if (this.Opacity > 0.0)
            {
                this.Opacity += 0.025;

            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* this.WindowState = FormWindowState.Maximized;
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             this.MinimumSize = this.Size;
             this.MaximumSize = this.Size;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;    //cancel the event so the form won't be closed

            t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            t1.Start();

            if (Opacity == 0)

                e.Cancel = false;

        }  //resume the event - the program can be closed



        void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)     //check if opacity is 0
            {
                t1.Stop();    //if it is, we stop the timer
                              //  Close();   //and we try to close the form
            }
            else
                Opacity -= 0.05;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select Language" || tburl.Text == "Enter Query")
            {

                MessageBox.Show("Mendatory Fields Must Be Filled!", "NullExceptions",
     MessageBoxButtons.OK,
     MessageBoxIcon.Warning // for Warning  
                            //MessageBoxIcon.Error // for Error 
                            //MessageBoxIcon.Information  // for Information
                            //MessageBoxIcon.Question // for Question
    );


                //  MessageBox.Show("Mendatory Fields Must Be Filled!");

            }
            else
            {
               // driver.Close();
                
                if (Radiogit.Checked==true)
                 {
                    string s = "Github";
                     //driver.Close();
                     //Recommand rank = new Recommand(true);
                    Middle middle = new Middle(s, comboBox1.Text,tburl.Text);
                    middle.ShowDialog();

                }
                else if(radiogeeks.Checked==true)
                {
                    string s = "Geeks for Geeks";
                    //Recommand rank = new Recommand(false);
                    // rank.ShowDialog();
                    Middle middle = new Middle(s, comboBox1.Text, tburl.Text);
                    middle.ShowDialog();
                }

                else if(radioprogramiz.Checked==true)
                 {
                    string s = "Programiz";
                    Middle middle = new Middle(s, comboBox1.Text, tburl.Text);
                    middle.ShowDialog();
                }
                //  Recommend re = new Recommend(treeView1.SelectedNode.FirstNode);


            }

        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

           
        }

        private void listView2_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (radiogeeks.Checked == true)
            {

                richTextBox1.Text = "";
                string selected = listView2.SelectedItems[0].SubItems[0].Text;
                /* var driverService = ChromeDriverService.CreateDefaultService();
                 driverService.HideCommandPromptWindow = true;
                 var options = new ChromeOptions();
                 options.AddArgument("headless");
                 driver = new ChromeDriver(driverService, options);*/


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
                              }*/
                        


                      //  treeView1.Font = new Font("calibiri", 10);
                        richTextBox1.Font = new Font("Georgia", 10);
                        //listView2.BackColor = Color.Blue;
                        //     string selectedo = treeView1.SelectedNode.Text;
                        // MessageBox.Show(selectedo);
                    }
                    richTextBox1.AppendText("\n\n\n");

                }
            }
            if (radioprogramiz.Checked)


               
                {

                    richTextBox1.Text = "";
                    string selected = listView2.SelectedItems[0].SubItems[0].Text;
                /* var driverService = ChromeDriverService.CreateDefaultService();
                 driverService.HideCommandPromptWindow = true;
                 var options = new ChromeOptions();
                 options.AddArgument("headless");
                 driver = new ChromeDriver(driverService, options);*/


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
                                    }*/



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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           // readfile();
            writefile();
        }
      /*  private async void readfile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Text Document|*.txt",
                ValidateNames = true,
                Multiselect = false
            })

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                        richTextBox1.Text = await sr.ReadToEndAsync();
                }

        }*/
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//System.NullReferenceException: 'Object reference not set to an instance of an object.'
