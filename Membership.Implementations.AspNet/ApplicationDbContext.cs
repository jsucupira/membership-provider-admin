using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    internal class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private ApplicationDbContext()
            : base("MembershipProvider", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}