namespace Labe_no11
{
    internal interface IBuilder<out T>
    {
        T Build();
    }
}