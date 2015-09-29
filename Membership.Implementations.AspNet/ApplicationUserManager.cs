using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        private ApplicationUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
        }


        public static ApplicationUserManager Create()
        {
            return new ApplicationUserManager(new UserStore<IdentityUser>(ApplicationDbContext.Create()));
        }
    }
}