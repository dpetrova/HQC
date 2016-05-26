namespace BangaloreUniversityLearningSystem
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string msg) : base(msg)
        {
        }
    }
}
