namespace Labe_no11
{
    public abstract class ComplexNumberBuilder : IBuilder<Complex>
    {
        public abstract Complex Build();
        protected abstract double TakeRealPart();
        protected abstract double TakeVirtualPart();
    }
}
