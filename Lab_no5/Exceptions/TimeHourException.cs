namespace Lab_no5.Exceptions
{
    internal class TimeHourException : TimeException
    {
        public override string Message =>
            base.Message + " Вы ввели недопустимое значение для переменной Часы.";
    }
}