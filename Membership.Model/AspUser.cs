using System.Collections.Generic;

namespace Membership.Model
{
    public sealed class AspUser
    {
        public AspUser()
        {
            AspNetRoles = new List<AspRole>();
        }

        public ICollection<AspRole> AspNetRoles { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}