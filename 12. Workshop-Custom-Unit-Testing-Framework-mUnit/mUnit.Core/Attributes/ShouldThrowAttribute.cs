namespace mUnit.Core.Attributes
{
    using System;

    public class ShouldThrowAttribute : Attribute
    {
        public ShouldThrowAttribute(Type exceptionType) //as parameter accepts the type of the exception
        {
            this.ExceptionType = exceptionType;
        }

        public Type ExceptionType { get; private set; }
    }
}
