using System;

namespace Core.Extensions
{
    public class AuthorizedException : Exception
    {
        public AuthorizedException(string message) : base(message)
        {
        }
    }
}