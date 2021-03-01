using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelDemo.Abstract
{
    public interface IBrowserBatch<T>
    {
        void Start(IWebDriver driver, Action<IResult<T>, IWebDriver> callback);

        void Stop();
    }
}
