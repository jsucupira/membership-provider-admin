using System;

namespace Membership.Common.Exceptions
{
    [Serializable]
    public class MissingValueException : ExceptionBase
    {
        public MissingValueException(string name)
            : base(string.Format("{0} is required.", name), "MissingValue", string.Format("Parameter={0}", name))
        {
        }
    }
}
