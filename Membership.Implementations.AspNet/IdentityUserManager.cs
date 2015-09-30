using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Membership.Model.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    [Export(typeof (IUserManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IdentityUserManager : IUserManager
    {
        public bool CreateUser(string userName, string email, string password)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IdentityResult result = manager.Create(new IdentityUser
                {
                    Email = email,
                    UserName = userName
                }, password);
                return result.Succeeded;
            }
        }

        public IEnumerable<AspUser> FindAll()
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IEnumerable<AspUser> users = manager.Users.Select(Mapping.Map);
                return users;
            }
        }

        public AspUser FindByUserName(string userName)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IdentityUser user = manager.FindByName(userName);
                return user?.Map();
            }
        }

        public bool DeleteUser(string userName)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IdentityUser user = manager.FindByName(userName);
                if (user != null)
                    manager.Delete(user);

                return true;
            }
        }
    }
}