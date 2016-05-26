namespace mUnit.Core.Assertions
{
    using Exceptions;

    public class Assert
    {
        public static void AreEqual(object expected, object actual, string message = null) //message is optional
        {
            if (!expected.Equals(actual))
            {
                throw new AssertFailedException(message); //if the test fails
            }
        }

        public static void IsNull(object obj, string message = null)
        {
            if (obj != null)
            {
                throw new AssertFailedException(message);
            }
        }

        public static void IsTrue(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new AssertFailedException(message);
            }
        }
    }
}
