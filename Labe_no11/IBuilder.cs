namespace Labe_no11
{
    interface IBuilder<out T>
    {
        T Build();
    }
}
