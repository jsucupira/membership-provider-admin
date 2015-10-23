using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Membership.Model.Roles;
using Membership.Model.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    [Export(typeof (IRoleManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IdentityRoleManager : IRoleManager
    {
        public bool AddUserToRole(string userName, string roleName)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IdentityUser user = manager.FindByName(userName);
                if (user == null) return false;

                return manager.AddToRole(user.Id, roleName).Succeeded;
            }
        }

        public AspRole CreateRole(string roleName)
        {
            using (ApplicationRoleManager manager = ApplicationRoleManager.Create())
            {
                if (manager.Create(new IdentityRole(roleName)).Succeeded)
                    return FindByName(roleName);
                else
                    return null;
            }
        }

        public IEnumerable<AspRole> FindAll()
        {
            using (ApplicationRoleManager manager = ApplicationRoleManager.Create())
                return manager.Roles.Select(Mapping.Map);
        }

        public AspRole FindByName(string roleName)
        {
            using (ApplicationRoleManager manager = ApplicationRoleManager.Create())
                return manager.FindByName(roleName).Map();
        }

        public bool DeleteRole(string roleName)
        {
            using (ApplicationRoleManager manager = ApplicationRoleManager.Create())
            {
                IdentityRole role = manager.FindByName(roleName);
                if (role == null) return false;

                return manager.Delete(role).Succeeded;
            }
        }

        public bool RemoveUserFromRole(string userName, string roleName)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                IdentityUser user = manager.FindByName(userName);
                if (user == null) return false;

                return manager.RemoveFromRole(user.Id, roleName).Succeeded;
            }
        }

        public IEnumerable<AspRole> FindRolesForUser(string userName)
        {
            using (ApplicationUserManager manager = ApplicationUserManager.Create())
            {
                List<AspRole> roleList = new List<AspRole>();
                IdentityUser user = manager.FindByName(userName);
                List<IdentityUserRole> roles = user.Roles.ToList();
                if (roles.Any())
                {
                    using (ApplicationRoleManager roleManager = ApplicationRoleManager.Create())
                    {
                        foreach (IdentityUserRole identityUserRole in roles)
                            roleList.Add(roleManager.FindById(identityUserRole.RoleId).Map());
                    }
                }

                return roleList;
            }
        }

        public IEnumerable<AspUser> FindUsersInRole(string roleName)
        {
            using (ApplicationRoleManager roleManager = ApplicationRoleManager.Create())
            {
                List<AspUser> userList = new List<AspUser>();
                IdentityRole role = roleManager.FindByName(roleName);
                if (role == null) return null;

                List<IdentityUserRole> users = role.Users.ToList();
                if (users.Any())
                {
                    using (ApplicationUserManager userManager = ApplicationUserManager.Create())
                    {
                        foreach (IdentityUserRole identityUserRole in users)
                            userList.Add(userManager.FindById(identityUserRole.UserId).Map());
                    }
                }
                return userList;
            }
        }

        public void UpdateName(string oldName, string newName)
        {
            using (ApplicationRoleManager manager = ApplicationRoleManager.Create())
            {
                IdentityRole role = manager.FindByName(oldName);
                if (role != null)
                {
                    role.Name = newName;
                    manager.Update(role);
                }
            }
        }
    }
}