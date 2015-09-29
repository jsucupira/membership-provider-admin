using System;

namespace Membership.Common.Exceptions
{
    [Serializable]
    public class InvalidValueException : ExceptionBase
    {
        public InvalidValueException(string name, string value)
            : base(string.Format("Invalid value for {0} ({1}).", name, value), "InvalidValue", string.Format("Parameter={0}", name), string.Format("Value={0}", value))
        {
        }
    }
}
