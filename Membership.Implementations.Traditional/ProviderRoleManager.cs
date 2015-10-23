using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Security;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Implementations.Traditional
{
    [Export(typeof(IRoleManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ProviderRoleManager : IRoleManager
    {
        public bool AddUserToRole(string userName, string roleName)
        {
            Roles.AddUserToRole(userName, roleName);
            return Roles.IsUserInRole(userName, roleName);
        }

        public AspRole CreateRole(string roleName)
        {
            Roles.CreateRole(roleName);
            return FindByName(roleName);
        }

        public IEnumerable<AspRole> FindAll()
        {
            List<string> roleCollection = Roles.GetAllRoles().ToList();
            return roleCollection.Select(role => new AspRole { Name = role });
        }

        public AspRole FindByName(string roleName)
        {
            return Roles.RoleExists(roleName) ? new AspRole { Name = roleName } : null;
        }

        public bool DeleteRole(string roleName)
        {
            return Roles.DeleteRole(roleName, true);
        }

        public bool RemoveUserFromRole(string userName, string roleName)
        {
            Roles.RemoveUserFromRole(userName, roleName);
            return !Roles.IsUserInRole(userName, roleName);
        }

        public IEnumerable<AspRole> FindRolesForUser(string userName)
        {
            List<string> roles = Roles.GetRolesForUser(userName).ToList();
            return roles.Select(role => new AspRole { Name = role });
        }

        public IEnumerable<AspUser> FindUsersInRole(string roleName)
        {
            List<string> users = Roles.GetUsersInRole(roleName).ToList();
            return users.Select(userName => System.Web.Security.Membership.GetUser(userName).Map());
        }

        public void UpdateName(string oldName, string newName)
        {
            string[] users = Roles.GetUsersInRole(oldName);
            Roles.CreateRole(newName);
            if (users.Any())
            {
                Roles.AddUsersToRole(users, newName);
                Roles.RemoveUsersFromRole(users, oldName);
            }
            Roles.DeleteRole(oldName);
        }
    }
}