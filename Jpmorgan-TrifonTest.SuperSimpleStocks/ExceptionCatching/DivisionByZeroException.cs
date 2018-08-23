using System;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.ExceptionCatching
{
    public class DivisionByZeroException : ArgumentException
    {
        public DivisionByZeroException() : base("Division by zerro is forbidden!")
        {
        }
    }
}
