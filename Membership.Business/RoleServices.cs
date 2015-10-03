using System.Collections.Generic;
using System.Linq;
using Membership.Common.Exceptions;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Business
{
    public static class RoleServices
    {
        public static void AddUserToRole(string userName, string roleName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            AspUser user = UserManagerFactory.Create().FindByUserName(userName);
            if (user == null)
                throw new NotFoundException("User", userName);

            AspRole role = GetRole(roleName);

            bool result = RoleManagerFactory.Create().AddUserToRole(userName, role.Name);
            if (!result)
                throw new BadOperationException($"Unable to add user '{userName}' to role '{roleName}'.");
        }

        public static AspRole CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            AspRole result = RoleManagerFactory.Create().CreateRole(roleName);
            if (result == null)
                throw new BadOperationException($"Unable to create role '{roleName}'.");

            return result;
        }

        public static void DeleteRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            bool result = RoleManagerFactory.Create().DeleteRole(roleName);
            if (!result)
                throw new BadOperationException($"Unable to remove role '{roleName}'.");
        }

        public static List<AspRole> FindAll()
        {
            return RoleManagerFactory.Create().FindAll().ToList();
        }

        public static AspRole GetRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            AspRole role = RoleManagerFactory.Create().FindByName(roleName);
            if (role == null)
                throw new NotFoundException("Role", roleName);

            role.AspUsers = FindUsersInRole(roleName);
            return role;
        }

        public static List<AspUser> FindUsersInRole(string roleName)
        {
            IRoleManager roleManager = RoleManagerFactory.Create();
            AspRole role = roleManager.FindByName(roleName);
            if (role == null)
                return new List<AspUser>();

            return roleManager.FindUsersInRole(role.Name).ToList();
        }

        public static void RemoveUserFromRole(string userName, string roleName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            bool result = RoleManagerFactory.Create().RemoveUserFromRole(userName, roleName);
            if (!result)
                throw new BadOperationException($"Unable to remove user '{userName}' to role '{roleName}'.");
        }

        public static List<AspRole> FindRolesForUser(string userName)
        {
            return RoleManagerFactory.Create().FindRolesForUser(userName).ToList();
        }
    }
}