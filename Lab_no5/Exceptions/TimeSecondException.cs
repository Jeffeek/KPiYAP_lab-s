namespace Lab_no5.Exceptions
{
    internal class TimeSecondException : TimeException
    {
        public override string Message =>
            base.Message + " Вы ввели недопустимое значение для переменной Секунды.";
    }
}