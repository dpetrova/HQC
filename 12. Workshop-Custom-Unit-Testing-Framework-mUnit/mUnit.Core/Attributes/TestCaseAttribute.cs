namespace mUnit.Core.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)] //show where can be use and can be used multiple times
    public class TestCaseAttribute : Attribute
    {
        public TestCaseAttribute(object param)
        {
            this.Param = param;
        }

        public object Param { get; private set; }
    }
}
