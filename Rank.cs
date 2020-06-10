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

    public partial class Recommand : Form
    {
        public IWebDriver driver;
        public bool Option1Selected { get; set; }
        public bool Option2Selected { get; set; }
        public TreeNode node { get; set; }
        //  public NodeLabelEditEventArgs node { get; set; }
        public Recommand(string source,string query)
        {
            InitializeComponent();
            textBox4.AppendText(query);
            textBox4.ReadOnly = true;
            
            textBox3.AppendText(source);
            textBox3.ReadOnly = true;
            if (source == "Github")
            {
               // textBox3.Text = source;
                panel1.Visible = true;
               // panel2.Visible = true;
               // panel3.Visible = false;
            }

            else if(source=="Geeks for Geeks")
            {
                //panel2.Visible = false;
                panel1.Visible = false;
              //  panel3.Visible = true;
            }
            else if (source == "Programiz")
            {
                panel1.Visible = false;
            }
            //  option1Selected = Option1Selected;
        }
        public Recommand()
        {
            InitializeComponent();

        }

        /*  public Rank(TreeNode node)
           {
              //string rankg= node.Text;
               // TreeNode note = new TreeNode(rankg);

               treeView1.Nodes.Add(node);
           }
        public void Rank_Load(object sender, EventArgs e)
        {
            // Userguide();
        }
        /* private void Userguide()
         {
             MessageBox.Show("CODEHUB USER GUIDE");
             MessageBox.Show("STOP Here Before Proceed, FOLLOW THE User guide---Click OK to see The User guide", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Hand);
             MessageBox.Show("Dear User/Developer Welcome To  CODEHUB User Guide \n Before Move to Rank or click any link You have to Follow these step very Carefully \n  1-Choose Atleast Five Code files e.g The link which contain example.cs" +
                 "\n2-When you Select a Perticular Link of Codefile Then click on -YES- " +
                 "\n3-Otherwise Click -NO-" +
                 "\n4-when you Select  At lest five(5) the Codefiles From Above repositoreis Then Click -Cancel-" +
                 "\n5-when you select one codefile link then Donot Select again \n6-Donot select more more Than 10 Repositories" +
                 "\n7-After Perform Update of Treeview You must Have to double Click to select any node", "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
             MessageBox.Show("ONLY SINGLE CLICK ALLOW TO HAVE TO SELECT THE CODE LINK BY ONLY SINGLE CLICK", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }*/
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            t1.Start();
            if (Opacity == 0)
            {
                Form1 frm1 = new Form1();
                frm1.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
             Recommend recomend = new Recommend(textBox3.Text,textBox4.Text);
                recomend.ShowDialog();
            
            
        
            

        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            richTextBox2.Text = "";

          //  treeView1.Nodes.Clear();
            // this.BackgroundImage = Properties.Resources.images__3_;
            // tburl.Text = "Enter Query";
            // comboBox1.Text = "Select Technique";
            // comboBox2.Text = "Sort By";

        }

        private void Rank_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        Timer t1 = new Timer();
        private void Rank_FormClosing(object sender, FormClosingEventArgs e)
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
                Close();   //and we try to close the form
            }
            else
                Opacity -= 0.05;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {

        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {

        }
        public void hidePanels()
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {

        }


        int ite = 0;



     

        



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   




        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
          //  readfile();
            writefile();
        }
     /*   private async void readfile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Text Document|*.txt", ValidateNames = true, Multiselect = false
            }) 
        
        if(ofd.ShowDialog()==DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                        richTextBox2.Text = await sr.ReadToEndAsync();
                }

    }*/
            private  async  void writefile()
        {

            using (SaveFileDialog sdf = new SaveFileDialog()
            {
                Filter = "Text Document|*.txt",
                ValidateNames = true,

            })

                if (sdf.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sdf.FileName))
                        await sw.WriteLineAsync(richTextBox2.Text);
                    MessageBox.Show("Successfully Saved !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Context Based Ranking")
            {
                richTextBox2.Text = "";
                listBox1.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";
                if (textBox3.Text == "Github")
                {
                    cnd.CommandText = "SELECT link FROM Ushine";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {
                            listBox1.Items.Add(dr["link"].ToString());

                           // textBox2.AppendText(dr["star"].ToString());
                           // textBox3.AppendText(dr["watches"].ToString());
                           // richTextBox2.AppendText(dr["Code"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (textBox3.Text == "Geeks for Geeks")
                {
                    cnd.CommandText = "SELECT link FROM Ugeeks";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {


                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());

                            listBox1.Items.Add(dr["link"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (textBox3.Text == "Programiz")
                {
                    cnd.CommandText = "SELECT link FROM Uprogramiz";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {


                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());

                            listBox1.Items.Add(dr["link"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            if (comboBox1.Text == "Popularity Based Ranking")
            {
                richTextBox2.Text = "";
                listBox1.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=CODEHUB;Integrated Security=True");
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = System.Data.CommandType.Text;
                //   cnd.CommandText = "select * from Codehub";
             //   cnd.CommandText = "SELECT link FROM system ORDER BY star,watches DESC ";
                if (textBox3.Text == "Github")
                {
                    cnd.CommandText = "SELECT link FROM Ushine ORDER BY star,watches DESC";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {

                            listBox1.Items.Add(dr["link"].ToString());
                            //textBox2.AppendText(dr["star"].ToString());
                           // textBox3.AppendText(dr["watches"].ToString());
                           // richTextBox2.AppendText(dr["Code"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (textBox3.Text == "Geeks for Geeks")
                {
                    cnd.CommandText = "SELECT link FROM Ugeeks ORDER BY star,watches DESC";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {

                            listBox1.Items.Add(dr["link"].ToString());
                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());

                           // richTextBox2.AppendText(dr["Code"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (textBox3.Text == "Programiz")
                {
                    cnd.CommandText = "SELECT link FROM Uprogramiz ORDER BY star,watches DESC";
                    try
                    {
                        SqlDataReader dr = cnd.ExecuteReader();
                        while (dr.Read())
                        {
                            listBox1.Items.Add(dr["link"].ToString());

                            // textBox2.AppendText(dr["star"].ToString());
                            //textBox3.AppendText(dr["watches"].ToString());

                            //richTextBox2.AppendText(dr["Code"].ToString());

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (textBox3.Text == "Github")
            {
                cnd.CommandText = "SELECT * FROM Ushine WHERE link='" + Selected + "'";
                try
                {
                    SqlDataReader dr = cnd.ExecuteReader();
                    while (dr.Read())
                    {


                        textBox2.AppendText(dr["star"].ToString());
                        textBox1.AppendText(dr["watches"].ToString());
                        richTextBox2.AppendText(dr["Code"].ToString());

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
                        
                        richTextBox2.AppendText(dr["Code"].ToString());

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
                        
                        richTextBox2.AppendText(dr["Code"].ToString());

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Recommand_Load(object sender, EventArgs e)
        {

        }
    }
}







/*  private void listView1_MouseClick(object sender, MouseEventArgs e)
       {
           DialogResult resultoo = MessageBox.Show("Are you Selected Geeks For Geeks in previous Tab", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (resultoo == DialogResult.Yes)
           {

               richTextBox2.Text = "";
               string selected = listView1.SelectedItems[0].SubItems[0].Text;
               var driverService = ChromeDriverService.CreateDefaultService();
               driverService.HideCommandPromptWindow = true;
               var options = new ChromeOptions();
               options.AddArgument("headless");
               driver = new ChromeDriver(driverService, options);

               driver.Navigate().GoToUrl("https://www.geeksforgeeks.org/?s=" + selected);

               // webBrowser1.Navigate(selected);

               IList<IWebElement> searchElements = driver.FindElements(By.TagName("tbody"));

               foreach (IWebElement i in searchElements)
               {
                   HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                   var text = i.GetAttribute("innerHTML");
                   htmlDocument.LoadHtml(text);
                   var inputs = htmlDocument.DocumentNode.Descendants("td").ToList();
                   foreach (var items in inputs)
                   {
                       HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                       htmlDocument1.LoadHtml(items.InnerHtml);

                       var tds = htmlDocument1.DocumentNode.Descendants("div").ToList();
                       var links = htmlDocument1.DocumentNode.Descendants("a");


                       if (tds.Count != 0)
                           foreach (var node in tds)
                           {
                               richTextBox2.AppendText("\t\n");

                               richTextBox2.AppendText(node.InnerText.Trim() ?? " ");
                               this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                               richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                               richTextBox2.Font = new Font("Georgia", 8);

                           }
                       try
                       {
                           var read = htmlDocument.DocumentNode.Descendants("pre");
                           //  richTextBox1.AppendText("\t\nREADME \n");
                           foreach (var red in read)
                           {


                               richTextBox2.AppendText(red.InnerText.Trim() ?? " ");
                               this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                               richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                               // MessageBox.Show(red.InnerText);

                           }
                           richTextBox2.AppendText("\n\n\n");
                       }
                       catch
                       {
                           MessageBox.Show("ReadMe Does't Exits");
                       }
                       richTextBox2.AppendText("\n\n\n");                 // richTextBox1.AppendText("\n\nSOURCE_CODE\n");
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



                       treeView1.Font = new Font("calibiri", 10);
                       richTextBox2.Font = new Font("Georgia", 10);
                       //listView2.BackColor = Color.Blue;
                       //     string selectedo = treeView1.SelectedNode.Text;
                       // MessageBox.Show(selectedo);
                   }
                   richTextBox2.AppendText("\n\n\n");

               }
           }
           if (resultoo == DialogResult.No)



           {

               richTextBox2.Text = "";
               string selected = listView1.SelectedItems[0].SubItems[0].Text;
               var driverService = ChromeDriverService.CreateDefaultService();
               driverService.HideCommandPromptWindow = true;
               var options = new ChromeOptions();
               options.AddArgument("headless");
               driver = new ChromeDriver(driverService, options);


               driver.Navigate().GoToUrl("https://www.programiz.com/search/" + selected);

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
                               richTextBox2.AppendText("\t\n");

                               richTextBox2.AppendText(node.InnerText.Trim() ?? " ");
                               this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                               richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                               richTextBox2.Font = new Font("Georgia", 8);

                           }
                       try
                       {
                           var read = htmlDocument.DocumentNode.Descendants("pre");
                           //  richTextBox1.AppendText("\t\nREADME \n");
                           foreach (var red in read)
                           {


                               richTextBox2.AppendText(red.InnerText.Trim() ?? " ");
                               this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                               richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                               // MessageBox.Show(red.InnerText);

                           }
                           richTextBox2.AppendText("\n\n\n");
                       }
                       catch
                       {
                           MessageBox.Show("ReadMe Does't Exits");
                       }
                       richTextBox2.AppendText("\n\n\n");                 // richTextBox1.AppendText("\n\nSOURCE_CODE\n");
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



                       treeView1.Font = new Font("calibiri", 10);
                       richTextBox2.Font = new Font("Georgia", 10);
                       //listView2.BackColor = Color.Blue;
                       //     string selectedo = treeView1.SelectedNode.Text;
                       // MessageBox.Show(selectedo);
                   }
                   richTextBox2.AppendText("\n\n\n");

               }
           }



       }*/







/*  private void Array(string node)
  {
      if (ite > 5)
      {
          ArrayList arrayList = new ArrayList();

          string bio = node;

          arrayList.Add(bio);

          DialogResult resultoo = MessageBox.Show("You selected More than Five code file Click Ok To save the Repositories", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Question);

          if (resultoo == DialogResult.OK)
          {

              con.Open();
              SqlCommand cmd = con.CreateCommand();
              cmd.CommandType = System.Data.CommandType.Text;
              for (int i = 0; i < arrayList.Count; i++)
              {
                  if (i.ToString() == bio)
                  {
                      MessageBox.Show("YOU SELECTED THIS BEFORE", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
                  else
                  {
                      cmd.CommandText = "insert into url values('" + i.ToString() + "')";
                      cmd.ExecuteNonQuery();
                      con.Close();
                  }
              }
              update();
          }
      }

  }

  private void update()
  {



      //  MessageBox.Show("");


      DialogResult resulto = MessageBox.Show("You selected More than Five code file Do you want To update the Repositories", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (resulto == DialogResult.Yes)
      {

          treeView1.Nodes.Clear();
          con.Open();
          SqlCommand cnd = con.CreateCommand();
          cnd.CommandType = System.Data.CommandType.Text;
          cnd.CommandText = "select * from url";
          try
          {
              SqlDataReader dr = cnd.ExecuteReader();
              while (dr.Read())
              {
                  TreeNode n = new TreeNode(dr["URL"].ToString());
                  treeView1.Nodes.Add(n);
              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          MessageBox.Show("You selected More than Five code file Do you want To update the Repositories", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      }
      if (resulto == DialogResult.No)
      {

      }
      MessageBox.Show("Now If you want to choose Any link After Update Then \nThen Only Double Click on that", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  }*/


/*   private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)

  {
      if (e.Node.Nodes.Count > 0)
      {
          MessageBox.Show("You are Selected!", "Selected",
MessageBoxButtons.OK,
MessageBoxIcon.Information);


      }
      else
      {


          SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True");

      richTextBox2.Text = "";
      string selected = e.Node.Text;

      //    DialogResult result = MessageBox.Show("Do you want to select this" + e.Node.Text, "Notify", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      var driverService = ChromeDriverService.CreateDefaultService();
      driverService.HideCommandPromptWindow = true;
      var options = new ChromeOptions();
      options.AddArgument("headless");
      driver = new ChromeDriver(driverService, options);


      driver.Navigate().GoToUrl("https://github.com" + selected);
      //webBrowser1.Navigate("https://github.com" + selected);

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

              //  if (result == DialogResult.Yes)
              //  {

              //  Array(selected);

              //  ite++;
              var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();

              if (tds.Count != 0)
                  foreach (var node in tds)
                  {
                      richTextBox2.AppendText("\t\n");

                      richTextBox2.AppendText(node.InnerText + "\t\r");
                      // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                      // richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                      // richTextBox1.Font = new Font("Georgia", 8);

                  }
              con.Open();
              SqlCommand cnd = con.CreateCommand();
              cnd.CommandType = System.Data.CommandType.Text;
              //   cnd.CommandText = "select * from Codehub";
              cnd.CommandText = "SELECT * FROM system WHERE link ='" + selected + "'";
              try
              {
                  SqlDataReader dr = cnd.ExecuteReader();
                  while (dr.Read())
                  {

                      textBox1.AppendText(dr["watches"].ToString());
                      textBox2.AppendText(dr["star"].ToString());
                      //  richTextBox2.AppendText(dr["code"].ToString());
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
              }

              richTextBox2.AppendText("\t\r");


              try
              {
                  var read = htmlDocument.DocumentNode.Descendants("pre");
                  //  richTextBox1.AppendText("\t\nREADME \n");
                  foreach (var red in read)
                  {


                      richTextBox2.AppendText(red.InnerText.Trim() ?? " ");
                      this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                      richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                      // MessageBox.Show(red.InnerText);

                  }
                  richTextBox2.AppendText("\n\n\n");
              }
              catch
              {
                  MessageBox.Show("ReadMe Does't Exits");
              }
              richTextBox2.AppendText("\n\n\n");
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
              richTextBox2.Font = new Font("Georgia", 10);
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
              richTextBox2.Font = new Font("Georgia", 10);
              //listView2.BackColor = Color.Blue;
              //     string selectedo = treeView1.SelectedNode.Text;
              // MessageBox.Show(selectedo);
          }
          richTextBox2.AppendText("\n\n\n");


      }

  }
}/*
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


/*   private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
       {
           richTextBox2.Text = "";
           string selected = e.Node.Text;
           DialogResult result = MessageBox.Show("Do you want to select this" + e.Node.Text, "Notify", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

           /* var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("headless");
            driver = new ChromeDriver(driverService, options);


           driver.Navigate().GoToUrl("https://github.com" + selected);
           //webBrowser1.Navigate("https://github.com" + selected);

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

                   if (result == DialogResult.Yes)
                   {

                       Array(selected);

                       ite++;
                       var tds = htmlDocument1.DocumentNode.Descendants("tr").ToList();

                       if (tds.Count != 0)
                           foreach (var node in tds)
                           {
                               richTextBox2.AppendText("\t\n");

                               richTextBox2.AppendText(node.InnerText + "\t\r");
                               // this.richTextBox1.Text = this.richTextBox1.Text.Trim();
                               // richTextBox1.Text = Regex.Replace(richTextBox1.Text, "", "");
                               // richTextBox1.Font = new Font("Georgia", 8);

                           }


                       richTextBox2.AppendText("\t\r");


                       try
                       {
                           var read = htmlDocument.DocumentNode.Descendants("pre");
                           //  richTextBox1.AppendText("\t\nREADME \n");
                           foreach (var red in read)
                           {


                               richTextBox2.AppendText(red.InnerText.Trim() ?? " ");
                               this.richTextBox2.Text = this.richTextBox2.Text.Trim();
                               richTextBox2.Text = Regex.Replace(richTextBox2.Text, "", "");
                               // MessageBox.Show(red.InnerText);

                           }
                           richTextBox2.AppendText("\n\n\n");
                       }
                       catch
                       {
                           MessageBox.Show("ReadMe Does't Exits");
                       }
                       richTextBox2.AppendText("\n\n\n");
                       // richTextBox1.AppendText("\n\nSOURCE_CODE\n");
                       treeView1.Font = new Font("calibiri", 10);
                       richTextBox2.Font = new Font("Georgia", 10);
                       //listView2.BackColor = Color.Blue;
                       //     string selectedo = treeView1.SelectedNode.Text;
                       // MessageBox.Show(selectedo);
                   }
                   richTextBox2.AppendText("\n\n\n");
               }*/
