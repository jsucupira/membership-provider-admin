using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Business.Tests.Mock
{
    [Export(typeof (IRoleManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class RoleMock : IRoleManager
    {
        public bool AddUserToRole(string userName, string roleName)
        {
            AspRole role = FindByName(roleName);
            if (role == null) return false;

            AspUser user = UserDataMock.FindByUserName(userName);
            if (user == null) return false;

            user = UserDataMock.FindByUserName(userName);
            if (user == null) return false;

            role.AspUsers.Add(user);
            user.AspRoles.Add(role);
            return true;
        }

        public AspRole CreateRole(string roleName)
        {
            if (RoleDataMock.FindByName(roleName) != null) return null;
            var role = new AspRole
            {
                Name = roleName
            };
            RoleDataMock.Add(role);
            return role;
        }

        public IEnumerable<AspRole> FindAll()
        {
            return RoleDataMock.FindAll();
        }

        public AspRole FindByName(string roleName)
        {
            return RoleDataMock.FindByName(roleName);
        }

        public bool DeleteRole(string roleName)
        {
            RoleDataMock.Remove(roleName);
            return true;
        }

        public bool RemoveUserFromRole(string userName, string roleName)
        {
            AspRole role = FindByName(roleName);
            if (role == null) return false;

            AspUser user = UserDataMock.FindByUserName(userName);
            if (user == null) return false;

            user = role.AspUsers.First(t => t.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (user == null) return true;

            role.AspUsers.Remove(user);
            user.AspRoles.Remove(role);
            return true;
        }

        public IEnumerable<AspRole> FindRolesForUser(string userName)
        {
            AspUser user = UserDataMock.FindByUserName(userName);
            if (user != null)
                return user.AspRoles;

            return new List<AspRole>();
        }

        public IEnumerable<AspUser> FindUsersInRole(string roleName)
        {
            AspRole role = RoleDataMock.FindByName(roleName);
            if (role != null)
                return role.AspUsers;

            return new List<AspUser>();
        }
    }
}