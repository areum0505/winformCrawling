using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace winformCrawling
{
    public partial class Form1 : Form
    {
        private ChromeDriverService _driverService = null;
        private ChromeOptions _options = null;
        private ChromeDriver _driver = null;

        public Form1()
        {
            InitializeComponent();

            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;

            _options = new ChromeOptions();
            _options.AddArgument("disable-gpu");
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tboxPW = new System.Windows.Forms.TextBox();
            this.tboxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tboxUrl = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tboxNow = new System.Windows.Forms.TextBox();
            this.btnPre = new System.Windows.Forms.Button();
            this.pboxMain = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.tboxPW);
            this.groupBox1.Controls.Add(this.tboxID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. 특정 Site Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(220, 23);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 62);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tboxPW
            // 
            this.tboxPW.Location = new System.Drawing.Point(69, 60);
            this.tboxPW.Name = "tboxPW";
            this.tboxPW.PasswordChar = '*';
            this.tboxPW.Size = new System.Drawing.Size(125, 25);
            this.tboxPW.TabIndex = 3;
            // 
            // tboxID
            // 
            this.tboxID.Location = new System.Drawing.Point(69, 24);
            this.tboxID.Name = "tboxID";
            this.tboxID.Size = new System.Drawing.Size(125, 25);
            this.tboxID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "PW : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tboxUrl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.tboxSearch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.1. 이미지 검색";
            // 
            // tboxUrl
            // 
            this.tboxUrl.Location = new System.Drawing.Point(74, 52);
            this.tboxUrl.Name = "tboxUrl";
            this.tboxUrl.Size = new System.Drawing.Size(258, 240);
            this.tboxUrl.TabIndex = 4;
            this.tboxUrl.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "URL : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(245, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(74, 18);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(165, 25);
            this.tboxSearch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "검색어 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnGo);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.tboxNow);
            this.groupBox3.Controls.Add(this.btnPre);
            this.groupBox3.Controls.Add(this.pboxMain);
            this.groupBox3.Location = new System.Drawing.Point(356, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 404);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2.2. 이미지 검색 상세";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(245, 361);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 26);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(181, 361);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(58, 25);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(149, 365);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(26, 15);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "/ 0";
            // 
            // tboxNow
            // 
            this.tboxNow.Location = new System.Drawing.Point(106, 362);
            this.tboxNow.Name = "tboxNow";
            this.tboxNow.Size = new System.Drawing.Size(37, 25);
            this.tboxNow.TabIndex = 2;
            this.tboxNow.Text = "0";
            this.tboxNow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(42, 361);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(58, 26);
            this.btnPre.TabIndex = 1;
            this.btnPre.Text = "◀";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // pboxMain
            // 
            this.pboxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxMain.Location = new System.Drawing.Point(0, 23);
            this.pboxMain.Name = "pboxMain";
            this.pboxMain.Size = new System.Drawing.Size(338, 320);
            this.pboxMain.TabIndex = 0;
            this.pboxMain.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(712, 428);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMain)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = tboxID.Text;
            string pw = tboxPW.Text;

            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://www.daum.net"); // 웹사이트 접속
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var element = _driver.FindElementByXPath("//*[@id='inner_login']/a[1]");   // Main 로그인 버튼
            element.Click();

            Thread.Sleep(3000);

            element = _driver.FindElementByXPath("//*[@id='id']");    // ID 입력창
            element.SendKeys(id);

            element = _driver.FindElementByXPath("//*[@id='inputPwd']");   // PW 입력창 

            element.SendKeys(pw);

            element = _driver.FindElementByXPath("//*[@id='loginBtn']");  // 로그인 버튼
            element.Click();
        }

        List<string> Lsrc = null;
        int i = 0;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strURL = "https://www.google.com/search?q=" + tboxSearch.Text + "&source=lnms&tbm=isch";

            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl(strURL);                     // 웹 사이트에 접속
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.ExecuteScript("window.scrollBy(0, 10000)");     // 창을 띄우고 스크롤 진행

            Lsrc = new List<string>();

            foreach (IWebElement item in _driver.FindElementsByClassName("rg_i"))
            {
                if (item.GetAttribute("src") != null)
                    Lsrc.Add(item.GetAttribute("src"));
            }

            lblTotal.Text = "/ " + Lsrc.Count.ToString();

            this.Invoke(new Action(delegate ()
            {
                try
                {
                    foreach (string strsrc in Lsrc)
                    {
                        i++;

                        GetMapImage(Lsrc[i]);
                        tboxNow.Text = i.ToString();
                        Refresh();
                        Thread.Sleep(50);
                    }
                }
                catch (Exception)
                {

                }
            }));
        }

        private void GetMapImage(string base64String)
        {
            try
            {
                var base64Data = Regex.Match(base64String, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;  // 정규식 검색
                var binData = Convert.FromBase64String(base64Data);

                using (var stream = new MemoryStream(binData))
                {
                    if (stream.Length == 0)
                    {
                        pboxMain.Load(base64String);
                        tboxNow.Text = i.ToString();
                        tboxUrl.Text = base64String;
                    }
                    else
                    {
                        var image = Image.FromStream(stream);
                        pboxMain.Image = image;
                        tboxUrl.Text = base64String;
                    }
                }
            }
            catch
            {
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                i--;

                GetMapImage(Lsrc[i]);
                tboxNow.Text = i.ToString();
            }));
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                i = int.Parse(tboxNow.Text);

                GetMapImage(Lsrc[i]);
                tboxNow.Text = i.ToString();
            }));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                i++;

                GetMapImage(Lsrc[i]);
                tboxNow.Text = i.ToString();
            }));
        }
    }
}
