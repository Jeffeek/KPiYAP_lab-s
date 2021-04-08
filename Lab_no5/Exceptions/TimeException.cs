#region Using namespaces

using System;

#endregion

namespace Lab_no5.Exceptions
{
    internal class TimeException : Exception
    {
        public override string Message =>
            "Ошибка изменения значений времени.";
    }
}