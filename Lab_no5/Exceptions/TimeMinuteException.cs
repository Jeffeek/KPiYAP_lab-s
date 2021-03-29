namespace Lab_no5.Exceptions
{
    internal class TimeMinuteException : TimeException
    {
        public override string Message => base.Message + " Вы ввели недопустимое значение для переменной Минуты.";
    }
}