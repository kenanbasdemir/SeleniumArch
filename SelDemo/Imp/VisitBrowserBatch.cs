using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SelDemo.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SelDemo.Models
{
    public class VisitBrowserBatch : IBrowserBatch<VisitResult>
    {
        private IWebDriver driver;
        private Action<IResult<VisitResult>, IWebDriver> callback;

        public VisitBrowserBatch(string userName, string password)
        {
            //parameter for specification
        }

        public void Start(IWebDriver driver, Action<IResult<VisitResult>, IWebDriver> callback)
        {
            this.driver = driver;
            this.callback = callback;
            SomeMethod();
        }

        public void Stop()
        {
            if (driver == null)
            {
                return;
            }
            else if (!string.IsNullOrEmpty(driver.CurrentWindowHandle))
            {
                driver.Quit();
            }
        }


        private void SomeMethod()
        {
            //Selenium Integrations
            try
            {
                driver.Navigate().GoToUrl(@"https://www.google.com");
                driver.FindElement(By.Name("q")).SendKeys("kenan");
                var searchButton = driver.FindElement(By.Name("btnK"));
                searchButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("hata");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                System.Threading.Thread.Sleep(10000);
                driver?.Quit();
            }

            var result = new SuccessResult<VisitResult>() { Data = new VisitResult { SomeData = "kenan" } };
            callback.Invoke(result, driver);
        }

    }
}
