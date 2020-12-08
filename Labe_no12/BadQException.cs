using System;
using System.Collections.Generic;
using System.Text;

namespace Labe_no12
{
    public class BadQException : Exception
    {
        public override string Message => "Q must be NOT 0";

        //public override string StackTrace => Message;

        public override string ToString() => Message;
    }
}
