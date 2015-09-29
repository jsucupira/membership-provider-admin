using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Membership.Model;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Business.Tests.Mock
{
    [Export(typeof(IRoleManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class RoleMock : IRoleManager
    {
        public RoleMock()
        {
            RoleDataMock.Reset();
        }

        public bool AddUserToRole(string userName, string roleName)
        {
            AspRole role = FindByName(roleName);
            if (role == null) return false;

            AspUser user = role.AspUsers.First(t => t.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (user != null) return false;

            user = UserDataMock.FindByUserName(userName);
            if (user == null) return false;

            role.AspUsers.Add(user);
            user.AspRoles.Add(role);
            return true;
        }

        public bool CreateRole(string roleName)
        {
            if (RoleDataMock.FindByName(roleName) != null) return false;

            RoleDataMock.Add(new AspRole
            {
                Name = roleName
            });
            return true;
        }

        public IList<AspRole> FindAll()
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
    }
}