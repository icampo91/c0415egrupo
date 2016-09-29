using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorAtributosWeb.Tests
{
    [TestClass]
    public class AtributoTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        private Process _iisProcess;
        private string CurrentPath;
        private string AppLocation = @"\GestorAtributosWeb";
        private int Port = 12004;

        [TestInitialize]
        public void SetupTest()
        {
            var thread = new Thread(StartIisExpress) { IsBackground = true };

            thread.Start();
            Thread.Sleep(2000);

            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            baseURL = "http://localhost:" + Port + "/";
            verificationErrors = new StringBuilder();
        }

        [TestMethod]
        public void TestAtributoCrear()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.LinkText("Atributos")).Click();
            driver.FindElement(By.CssSelector("button.col-lg-1")).Click();
            driver.FindElement(By.XPath("//input")).Clear();
            driver.FindElement(By.XPath("//input")).SendKeys("prueba");
            driver.FindElement(By.XPath("//div[2]/input")).Clear();
            driver.FindElement(By.XPath("//div[2]/input")).SendKeys("prueba");
            driver.FindElement(By.XPath("//div[3]/input")).Clear();
            driver.FindElement(By.XPath("//div[3]/input")).SendKeys("prueba");
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//li[2]/span"))).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//li[1]/span"))).Click();
            driver.FindElement(By.XPath("//button[3]")).Click();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
            _iisProcess.Kill();
            Assert.AreEqual("", verificationErrors.ToString());
        }

        private void StartIisExpress()
        {

            CurrentPath = Directory.GetCurrentDirectory();
            CurrentPath = CurrentPath.Substring(0, CurrentPath.LastIndexOf("\\"));
            CurrentPath = CurrentPath.Substring(0, CurrentPath.LastIndexOf("\\"));
            CurrentPath = CurrentPath.Substring(0, CurrentPath.LastIndexOf("\\"));
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                RedirectStandardInput = true,
                Arguments = string.Format("/path:\"{0}\" /port:{1}", CurrentPath + AppLocation, Port)
            };

            var programfiles = string.IsNullOrEmpty(startInfo.EnvironmentVariables["programfiles"])
                                ? startInfo.EnvironmentVariables["programfiles(x86)"]
                                : startInfo.EnvironmentVariables["programfiles"];

            startInfo.FileName = programfiles + "\\IIS Express\\iisexpress.exe";

            try
            {
                _iisProcess = new Process { StartInfo = startInfo };
                _iisProcess.Start();

                _iisProcess.WaitForExit();
                return;
            }
            catch (Exception e)
            {
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
