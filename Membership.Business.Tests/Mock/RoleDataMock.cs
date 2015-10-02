using System;
using System.Collections.Generic;
using Membership.Model;
using Membership.Model.Roles;

namespace Membership.Business.Tests.Mock
{
    internal static class RoleDataMock
    {
        private static List<AspRole> _roles = new List<AspRole>();

        public static void Add(AspRole role)
        {
            _roles.Add(role);
        }

        public static List<AspRole> FindAll()
        {
            return _roles;
        }

        public static AspRole FindByName(string name)
        {
            return _roles.Find(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static void Remove(string name)
        {
            AspRole role = _roles.Find(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (role != null)
            {
                _roles.Remove(role);
            }
        }

        public static void Reset()
        {
            _roles = new List<AspRole>();
        }
    }
}