using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
    public class CategoriasTest
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
            Thread.Sleep(10000);

            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            baseURL = "http://localhost:" + Port + "/";
            verificationErrors = new StringBuilder();
        }

        [TestMethod]
        public void TestCategoriaCrear()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Categorias")).Click();
            driver.FindElement(By.CssSelector("button.col-lg-1")).Click();
            driver.FindElement(By.XPath("//input")).Clear();
            driver.FindElement(By.XPath("//input")).SendKeys("Categoria nueva");
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//tr[3]/td[3]/button")).Click();
        }

        [TestMethod]
        public void TestCategoriaModificar()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Categorias")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//tr[2]/td[3]/button[2]")).Click();
            driver.FindElement(By.XPath("//input")).Clear();
            driver.FindElement(By.XPath("//input")).SendKeys("Informes editado");
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(2000);
            string text = driver.FindElement(By.XPath("//tr[2]/td[2]")).Text;
            Assert.IsTrue(text == "Informes editado");
        }

        [TestMethod]
        public void TestCategoriaModificarError()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Categorias")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//button[2]")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("");
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("button")).Click();
        }

        [TestMethod]
        public void TestCategoriaBorrarError()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Categorias")).Click();
            driver.FindElement(By.XPath("//button[3]")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("button")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("button")).Click();
            Thread.Sleep(500);
            Assert.IsTrue(IsElementPresent(By.XPath("//button[3]")));
        }

        [TestMethod]
        public void TestCategoriaBorrar()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(10000);
            driver.FindElement(By.LinkText("Categorias")).Click();
            driver.FindElement(By.CssSelector("button.col-lg-1")).Click();
            driver.FindElement(By.XPath("//input")).Clear();
            driver.FindElement(By.XPath("//input")).SendKeys("Categoria Borrar");
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//tr[3]/td[3]/button[3]")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("button")).Click();
            Assert.IsFalse(IsElementPresent(By.XPath("//tr[3]/td[3]/button[3]")));
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
