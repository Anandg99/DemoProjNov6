using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Collections;
//using Dotnetselenium
using System.IO;
using System.Collections.Generic;


namespace DemoProjNov6
{
    public class LoginTests
    {
        IWebDriver dr;
       
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("I am from setup method");
            dr = new ChromeDriver();//@"C:\Users\Anand.Gummadilli\Desktop"
                                    //objLogger.logsEnabled = true;

        }
        [Test]
        public void OpenGoogleSite()
        {
            Console.WriteLine("I am test case1");
        }
        

        [Test]
        public void OpenMySite()
        {

            dr.Navigate().GoToUrl("http://google.com");
            dr.Manage().Window.Maximize();

            dr.FindElement(By.Name("q")).SendKeys("techtutorialz");
            dr.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            dr.Close();
        }
        [Test]
        public void NavigateToGmail()
        {
            dr.Navigate().GoToUrl("http://google.com");
            IWebElement linkGmail = dr.FindElement(By.XPath("//a[text()='Gmail']"));
            linkGmail.Click();

            //dr.FindElement(By.XPath("//a[text()='Gmail']")).Click();
        }
        [Test]
        public void NavigateToAdbTutorial()
        {
            dr.Navigate().GoToUrl("http://techtutorialz.com");
            dr.Manage().Window.Maximize();
            dr.FindElement(By.XPath("//a[@title='Tutorials']")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.XPath("//a[@title='ADB Tutorial']")).Click();
            ////a[@title='ADB Tutorial']
        }

        [Test]
        public void VerifyAllLinks()
        {
            dr.Navigate().GoToUrl("http://google.com");
            dr.Manage().Window.Maximize();
            IReadOnlyCollection<IWebElement> allLinks = dr.FindElements(By.XPath("//a"));
            Console.WriteLine("Link count is:" + allLinks.Count);
            foreach (var item in allLinks)
            {
                Console.WriteLine(item.Text);
            }
        }
        
        [Test]
        public void SearchIndia()
        {
            dr.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(2000);
            dr.FindElement(By.Name("q")).SendKeys("Beeramguda");
            dr.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }
        [Test]
        public void GetUsername()
        {

            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string userName = "Anand.Gummadilli";
            string path = "";
            string[] arrUsername = userName.Split('\\');
            if (arrUsername.Length > 1)
            {
                path = @"C:\\Users\\" + arrUsername[1] + "\\Downloads\\" + "data.json";
            }
            else
            {
                path = @"C:\\Users\\" + userName + "\\Downloads\\" + "data.json";
            }

            Console.WriteLine(path);
        }
        [Test]
        public void VerifyValidPANNumber()
        {
            dr.Navigate().GoToUrl("http://axismf.com");
            dr.Manage().Window.Maximize();
            dr.FindElement(By.XPath("//ion-button[@class='new-investor new-login ng-star-inserted ion-color ion-color-burgundy md button button-round button-solid ion-activatable ion-focusable hydrated']")).Click();
            Thread.Sleep(3000);
            dr.FindElement(By.XPath("(//input[@class='native-input sc-ion-input-md'])[6]")).SendKeys("");
            Thread.Sleep(3000);

            IReadOnlyCollection<IWebElement> listerrMsg = dr.FindElements(By.XPath("//div[text()='Please enter a correct PAN']"));
            Assert.IsTrue(listerrMsg.Count == 0); //not displayed

            IWebElement btnOTP = dr.FindElement(By.Id("btn-1"));
            Assert.IsTrue(btnOTP.Enabled == true, "Generate OTP button is disabled"); //disabled
        }

        [Test]
        public void VerifyMaxlength()
        {
            dr.Navigate().GoToUrl("http://google.com");
            dr.Manage().Window.Maximize();
            IWebElement txtSearch = dr.FindElement(By.Name("q"));

            string strMaxlength = txtSearch.GetAttribute("maxlength");

            Assert.IsTrue(strMaxlength == "2048", "Max length is not matching");

            IWebElement linkSignin = dr.FindElement(By.XPath("//a[text()='Sign in']"));
            Console.WriteLine(linkSignin.GetAttribute("href"));

        }

        [Test]
        public void VerifyGetattribute()
        {
            dr.Navigate().GoToUrl("http://google.com");
            dr.Manage().Window.Maximize();
            IWebElement txtSearch = dr.FindElement(By.Name("q"));
            txtSearch.SendKeys("India");

            Console.WriteLine("Text is:" + txtSearch.GetAttribute("value"));
            string maxlength = txtSearch.GetAttribute("maxlength");
            Console.WriteLine("maxlength of text box is:" + maxlength);
        }
        [Test]
        public void VerifyLinkText()
        {
            dr.Navigate().GoToUrl("http://google.com");
            dr.Manage().Window.Maximize();
            IWebElement linkGmail = dr.FindElement(By.LinkText("Gmail"));

            Console.WriteLine("Gmail link is enabled:" + linkGmail.Enabled);
            if (linkGmail.Size == Size.Empty) //gamil link not exists
            {
                Console.WriteLine("Gmail link not displayed");
            }
            else
            {
                linkGmail.Click();
            }


            string strTitle = dr.Title;
            Console.WriteLine(strTitle);
            Assert.IsTrue(strTitle.Contains("Gmail") == true, "Gmail page is not loaded");

            string strUrl = dr.Url;
            Assert.IsTrue(strUrl.Contains("gmail"), "Gmail page is not loaded");
        }

        [Test]
        public void SearchCourse()
        {
            dr.Navigate().GoToUrl("http://techtutorialz.com");
            dr.Manage().Window.Maximize();
            dr.FindElement(By.Id("s")).SendKeys("Manual Testing");
            dr.FindElement(By.XPath("//button[text()='search']")).Click();
            dr.Navigate().Back();
            Thread.Sleep(2000);
            dr.Navigate().Forward();
            dr.Navigate().Refresh();
        }
       


        [Test]
        public void VerifySearch()
        {

            dr.Navigate().GoToUrl("https://google.com");
            dr.FindElement(By.Name("q")).SendKeys("India");
            dr.FindElement(By.Name("q")).SendKeys(Keys.Enter);

        }
        [Test]
        public void VerifyNavigationCommands()
        {
            dr.Navigate().GoToUrl("https://techtutorialz.com");
            dr.Manage().Window.Maximize();
            dr.FindElement(By.XPath("//a[@title='Resumes']")).Click(); //Navigate to Resumes page
            dr.Navigate().Back(); //browser back
            //string expectedURL = "https://techtutorialz.com/";
            //Assert.IsTrue(dr.Url == expectedURL, "Home page is not loaded");

            IWebElement viewLibrary = dr.FindElement(By.XPath("//a[text()='View Tutorial Library']"));
            Assert.IsTrue(viewLibrary.Size != Size.Empty); //Element presents
            dr.Navigate().Forward(); //navigate to resumes page

            IWebElement bcLink = dr.FindElement(By.XPath("//div[@class='page-breadcrum']/div/ul/li/a[text()='Resumes']"));
            Assert.IsTrue(bcLink.Text == "Resumes", "Resumes page is not loaded");
            Thread.Sleep(2000);
            dr.Navigate().Refresh();
        }
        [Test]
        public void VerifyResumes()
        {
            dr.Navigate().GoToUrl("https://techtutorialz.com");
            dr.Manage().Window.Maximize();

            dr.FindElement(By.XPath("//a[@title='Resumes']")).Click();
            //string actualUrl = dr.Url;
            //Assert.AreEqual("https://techtutorialz.com/category/resumes/", actualUrl,"Resumes page is not loaded");

            //IWebElement heading = dr.FindElement(By.XPath("//h2[@class='category-page-title']"));
            //Assert.IsTrue(heading.Text == "RESUMES", "Resumes page not loaded");

            IWebElement bcLink = dr.FindElement(By.XPath("//div[@class='page-breadcrum']/div/ul/li/a[text()='Resumes']"));
            Assert.IsTrue(bcLink.Text == "Resumes", "Resumes page is not loaded");
        }
        [Test]
        public void VerifyTraining()
        {
            dr.Navigate().GoToUrl("https://techtutorialz.com");
            dr.Manage().Window.Maximize();

            //dr.FindElement(By.XPath("//a[@title='Training']")).Click();
            dr.FindElement(By.LinkText("TRAINING")).Click();
            //string actualUrl = dr.Url;
            //Assert.AreEqual("https://techtutorialz.com/category/resumes/", actualUrl,"Resumes page is not loaded");

            //IWebElement heading = dr.FindElement(By.XPath("//h2[@class='category-page-title']"));
            //Assert.IsTrue(heading.Text == "RESUMES", "Resumes page not loaded");

            IWebElement bcLink = dr.FindElement(By.XPath("//div[@class='page-breadcrum']/div/ul/li/a[text()='training']"));
            Assert.IsTrue(bcLink.Text == "training", "training page is not loaded");
        }
        [Test]
        public void OpenGmail()
        {
            dr.Navigate().GoToUrl("https://google.com");
            Console.WriteLine("Title is:" + dr.Title);

            dr.FindElement(By.LinkText("Gmail")).Click();
            dr.FindElement(By.LinkText("Sign in")).Click();
            dr.FindElement(By.Id("identifierId")).SendKeys("agummadilli@gmail.com");
            dr.FindElement(By.XPath("//span[text()='Next']")).Click();
        }

        

        [Test]
        [TestCase("India")]
        [TestCase("Daton")]
        [TestCase("Cleveland")]

        public void Errormsg(string city)
        {
            dr.Navigate().GoToUrl("https://www.axismf.com");

            dr.FindElement(By.XPath("(//ion-button[@id='origin'])[2]")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.XPath("(//input[@name='pan'])[2]")).SendKeys(city);
            IWebElement pan = dr.FindElement(By.XPath("//div[text()='Please enter a correct PAN']"));
            Thread.Sleep(2000);
            Assert.IsTrue(pan.Displayed == true, "Error message is not displayed");

        }

        [Test]
        public void VerifyImplicitWait()
        {
            //dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            String eTitle = "Demo Guru99 Page";
            String aTitle = "";
            // launch Chrome and redirect it to the Base URL
            dr.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            //Maximizes the browser window
            dr.Manage().Window.Maximize();
            //get the actual value of the title
            aTitle = dr.Title;
            //compare the actual title with the expected title
            if (aTitle.Contains(eTitle))
            {
                Console.WriteLine("Test Passed");
                dr.Close();
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Test Failed");
                Assert.Fail();
            }
            //close browser

        }

        [Test]
        public void VerifyFileUplaod()
        {
            dr.Navigate().GoToUrl("https://www.naukri.com/registration/createAccount?othersrcp=11499&wExp=N");
            string filePath = @"C:\Anand_Details\CSharp_Sessions.docx";
            dr.FindElement(By.XPath("//input[@type='file']")).SendKeys(filePath);
        }
        
        [Test]
        public void VerifyTryCtach()
        {
            try
            {
                int x = 10;
                int y = 0;
                //Console.WriteLine("Z is:" + x / y);
                int[] nums = new int[2] { 10, 20 };
                Console.WriteLine(nums[5]);
            }
            catch (IndexOutOfRangeException dbyzex)
            {
                Console.WriteLine(dbyzex.Message);
                Console.WriteLine(dbyzex.StackTrace);
            }
            catch (DivideByZeroException dbyzex)
            {
                Console.WriteLine(dbyzex.Message);
                Console.WriteLine(dbyzex.StackTrace);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


        }
        [Test]
        public void Devide2Numbers()
        {
            try
            {
                int x = 10;
                int y = 0;
                int z = x / y;
                Console.WriteLine("z value is:" + z);

            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [Test]

        public void Getscreenshot()
        {
            try
            {
                dr.Navigate().GoToUrl("https://www.axismf.com");
                dr.FindElement(By.XPath("(//ion-button[@id='origin'])[2]")).Click(); //click on Login button

                IWebElement elementPan = dr.FindElement(By.XPath("(//input[@name='pan'])[2]"));
                elementPan.SendKeys("India"); //enter india in PAn number

                IWebElement panError = dr.FindElement(By.XPath("//div[text()='Please enter a correct PAN']"));
                //Thread.Sleep(2000);
                Assert.IsTrue(panError.Size != Size.Empty, "validation error is not displayed for PAN"); //Error is displayed

            }
            catch (ElementClickInterceptedException clickex)
            {
                Console.WriteLine(clickex.Message);

                ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                // Creating UIScreenshot folder if not exists
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
                string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";

            }
            catch (NoSuchElementException nosuchex)
            {
                Console.WriteLine(nosuchex.Message);
                ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                // Creating UIScreenshot folder if not exists
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
                string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";

                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
            catch (NoSuchWindowException ex)
            {
                ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                // Creating UIScreenshot folder if not exists
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
                //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";

                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [Test]
        public void HandleMultipleTabs()
        {
            dr.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            string windowhandleParent = dr.CurrentWindowHandle; //getting parentwindow handle
            IWebElement btnNewwindow = dr.FindElement(By.XPath("//button[@id='tabButton']"));
            btnNewwindow.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> lstWindow = dr.WindowHandles;
            foreach (var handle in lstWindow)
            {
                Console.WriteLine(handle);
            }
            //Switching the driver to 2nd window
            dr.SwitchTo().Window(lstWindow[1]);
            IWebElement sampleText = dr.FindElement(By.XPath("//h1[@id='sampleHeading']"));
            Assert.IsTrue(sampleText.Displayed, "Sample text is not displayed");
            dr.Navigate().GoToUrl("http://google.com");
            dr.SwitchTo().Window(windowhandleParent); //return to parent window
            Console.WriteLine(dr.Title); //get the parent window title and print
        }

        [Test]
        public void HandleMultipleWindows()
        {
            dr.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            string windowhandleParent = dr.CurrentWindowHandle;
            IWebElement btnNewwindow = dr.FindElement(By.XPath("//button[@id='windowButton']"));
            btnNewwindow.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> lstWindow = dr.WindowHandles;
            foreach (var handle in lstWindow)
            {
                Console.WriteLine(handle);
            }
            //Switching the driver to 2nd window
            dr.SwitchTo().Window(lstWindow[1]);
            IWebElement sampleText = dr.FindElement(By.XPath("//h1[@id='sampleHeading']"));
            Assert.IsTrue(sampleText.Displayed, "Sample text is not displayed");
            dr.SwitchTo().Window(windowhandleParent); //return to parent window
            Console.WriteLine(dr.Title);
        }
        [Test]
        public void Devidebyzero()
        {
            try
            {
                int x = 10;
                int y = 0;
                int z = x / y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [Test]
        public void NavigationCommands()
        {

            dr.Navigate().GoToUrl("http://axismf.com");
            dr.Manage().Window.Maximize();
            //dr.FindElement(By.XPath("//a[@href='about-us']")).Click();
            //dr.FindElement(By.LinkText("About Us")).Click();
            //dr.FindElement(By.XPath("//a[text()=' About Us ']")).Click();
            dr.FindElement(By.XPath("(//a[@id='top-pane-label'])[2]")).Click();
            string currenturl = dr.Url;
            Assert.IsTrue(currenturl == "https://www.axismf.com/about-us", "Aboutus page is not loaded");
            string pageTitle = dr.Title;
            Assert.IsTrue(pageTitle.Contains("About Us"), "Aboutus page is not loaded");
            Assert.AreEqual("About Us - Axis Mutual Fund Company in India| Axis MF", pageTitle, "Page title is not matching");
            dr.Navigate().Back();
            currenturl = dr.Url;
            Assert.IsTrue(currenturl == "https://www.axismf.com/", "Home page is not loaded");
            //dr.Navigate().Forward();
            //pageTitle = dr.Title;
            //Assert.IsTrue(pageTitle.Contains("About Us"), "Aboutus page is not loaded");
            dr.Navigate().Refresh();
        }

        [Test]
        public void Testcase2()
        {

            DisplayName("Arun");
            //Assert.Pass();
            string dateTime = DateTime.Now.ToString("yyyyMMdd");
            Console.WriteLine(dateTime);
        }
        [Test]
        public void LoginGmail()
        {
            dr.Navigate().GoToUrl("https://www.gmail.com");
            dr.Manage().Window.Maximize();
            //  dr.FindElement(By.XPath("//input[@type='email']")).Click();
            IWebElement uid = dr.FindElement(By.Name("identifier"));
            uid.Clear();
            //dr.FindElement(By.Name("identifier")).Clear();
            //dr.FindElement(By.Name("identifier")).SendKeys("pallavi.pulivarthy@myplanet.com");
            uid.SendKeys("pallavi.pulivarthy@myplanet.com");
            Console.WriteLine("Uid text is:" + uid.GetAttribute("value"));
            Console.WriteLine("Uid type is:" + uid.GetAttribute("type"));
            Console.WriteLine("area label is:" + uid.GetAttribute("aria-label"));

            dr.FindElement(By.XPath("(//span[@jsname='V67aGc'])[2]")).Click();

        }

        public void DisplayName(string sname)
        {
            Console.WriteLine("My name is:" + sname);
        }

        //        Returns Course Fee
        //Parameter: Course name
        //Manual Testing: 15000
        //Selenium: 25000

        [Test]
        public void VerifyFeeDetails()
        {
            int fee = GetFeeDetails("Manual Testing");
            //Assert.IsTrue(fee == 15000, "Fee is not same as expected");
            Assert.AreEqual(fee, 25000, "Fee is not same as expected");
        }
        public int GetFeeDetails(string cname)
        {
            int fee = 0;
            if (cname == "Manual Testing")
            {
                fee = 15000;
            }
            else
            {
                fee = 25000;
            }
            return fee;
        }
        [TearDown]
        public void Cleanup()
        {
            Console.WriteLine("I am cleanup method");
            //dr.Close();
        }
    }
}