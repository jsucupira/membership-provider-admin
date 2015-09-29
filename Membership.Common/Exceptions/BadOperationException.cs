using System;

namespace Membership.Common.Exceptions
{
    [Serializable]
    public class BadOperationException : ExceptionBase
    {
        public BadOperationException(string message) : base(message, "InvalidOperation", null)
        {
        }
    }
}
