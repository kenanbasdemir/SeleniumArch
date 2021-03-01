using System;
using System.Collections.Generic;
using System.Text;

namespace SelDemo.Abstract
{
    public interface IResult<T>
    {
        T Data { get; }
    }
}
