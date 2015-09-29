using System;

namespace Membership.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string resourceName, string resourceId) 
            : base(string.Format("{0} '{1}' not found.", resourceName, resourceId), "ResourceNotFound", 
                string.Format("Resource={0}", resourceName), string.Format("Id={0}", resourceId))
        {
        }
    }
}
