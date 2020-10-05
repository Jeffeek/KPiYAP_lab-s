using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no5.Exceptions
{
    class TimeSecondException : TimeException
    {
        public override string Message => base.Message + " Вы ввели недопустимое значение для переменной Секунды.";
    }
}
