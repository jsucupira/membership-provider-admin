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

            AspRole role = FindRole(roleName);

            bool result = RoleManagerFactory.Create().AddUserToRole(userName, role.Name);
            if (!result)
                throw new BadOperationException($"Unable to add user '{userName}' to role '{roleName}'.");
        }

        public static void CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            bool result = RoleManagerFactory.Create().CreateRole(roleName);
            if (!result)
                throw new BadOperationException($"Unable to create role '{roleName}'.");
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

        public static AspRole FindRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new MissingValueException("RoleName");

            AspRole role = RoleManagerFactory.Create().FindByName(roleName);
            if (role == null)
                throw new NotFoundException("Role", roleName);

            return role;
        }

        public static List<AspUser> FindUsersInRole(string roleName)
        {
            AspRole role = FindRole(roleName);
            return RoleManagerFactory.Create().FindUsersInRole(role.Name).ToList();
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
    }
}