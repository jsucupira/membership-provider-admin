using System;

namespace Membership.Site.Models
{
    [Serializable]
    public class RoleRequest
    {
        public string Name { get; set; }
        public string NewName { get; set; }
    }
}