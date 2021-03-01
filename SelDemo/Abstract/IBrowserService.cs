using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelDemo.Abstract
{
    public interface IBrowserService
    {
        void Execute<T>(IBrowserBatch<T> batch, Action<IResult<T>, IWebDriver> callback);
        Task ExecuteAsync<T>(IBrowserBatch<T> batch, Action<IResult<T>, IWebDriver> callback, CancellationToken cancellationToken);
    }
}
