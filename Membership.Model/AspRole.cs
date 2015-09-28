using System.Collections.Generic;

namespace Membership.Model
{
    public sealed class AspRole
    {
        public AspRole()
        {
            AspNetUsers = new List<AspUser>();
        }

        public ICollection<AspUser> AspNetUsers { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}