using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SelDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;

namespace SelDemo.Models
{
    public class ChromeBrowserManager : IBrowserService, IDisposable
    {
        public void Execute<T>(IBrowserBatch<T> batch, Action<IResult<T>, IWebDriver> callback)
        {
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new ChromeOptions());
            batch.Start(driver, callback);
        }

        public async Task ExecuteAsync<T>(IBrowserBatch<T> batch, Action<IResult<T>,IWebDriver> callback, CancellationToken cancellationToken)
        {
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new ChromeOptions());
            await Task.Factory.StartNew(()=>
            {
                batch.Start(driver, callback);
            }, cancellationToken);
        }

        public void Dispose()
        {
        }
    }
}
