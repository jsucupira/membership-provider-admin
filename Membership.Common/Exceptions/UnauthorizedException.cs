using System;

namespace Membership.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base(string.Format("You are Unauthorized to access this resource."))
        {
        }
    }
}
