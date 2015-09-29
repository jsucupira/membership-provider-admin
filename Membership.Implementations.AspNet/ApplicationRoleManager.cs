using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    internal class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        private ApplicationRoleManager(IRoleStore<IdentityRole, string> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create()
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(ApplicationDbContext.Create()));
        }
    }
}
