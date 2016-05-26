namespace Abstraction.Models
{
    using Abstraction.Interfaces;

    internal abstract class Figure : IFigure
    {
        public abstract double CalcPerimeter();
       
        public abstract double CalcSurface();
    }
}
