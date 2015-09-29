using System;
using System.Collections.Generic;
using Membership.Model;
using Membership.Model.Roles;

namespace Membership.Business.Tests.Mock
{
    internal static class RoleDataMock
    {
        private static List<AspRole> _roles = new List<AspRole>();
        private static int _nextId = 2;

        public static void Add(AspRole role)
        {
            role.Id = _nextId.ToString();
            _roles.Add(role);
            _nextId += 1;
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
                _nextId -= 1;
            }
        }

        public static void Reset()
        {
            _roles = new List<AspRole>
            {
                new AspRole
                {
                    Id = "1",
                    Name = "Administrator"
                }
            };
            _nextId = 2;
        }
    }
}