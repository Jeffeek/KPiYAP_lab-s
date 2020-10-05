using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no5.Exceptions
{
    class TimeException : Exception
    {
        public override string Message => "Ошибка изменения значений времени.";
    }
}
