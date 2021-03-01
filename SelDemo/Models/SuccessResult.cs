using SelDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelDemo.Models
{
    public class SuccessResult<T> : IResult<T>
    {
        public T Data { get; set; }
    }
}
