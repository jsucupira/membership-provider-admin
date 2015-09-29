using System;
using System.Collections.Generic;
using Membership.Model;
using Membership.Model.Users;

namespace Membership.Business.Tests.Mock
{
    internal static class UserDataMock
    {
        private static List<AspUser> _users = new List<AspUser>();
        private static int _nextId = 2;

        public static void Add(AspUser user)
        {
            user.Id = _nextId.ToString();
            _users.Add(user);
            _nextId += 1;
        }

        public static List<AspUser> FindAll()
        {
            return _users;
        }

        public static AspUser FindByUserName(string userName)
        {
            return _users.Find(t => t.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public static void Remove(string userName)
        {
            AspUser aspUser = _users.Find(t => t.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if (aspUser != null)
            {
                _users.Remove(aspUser);
                _nextId -= 1;
            }
        }

        public static void Reset()
        {
            _users = new List<AspUser> {new AspUser {UserName = "Admin", Id = "1"}};
            _nextId = 2;
        }
    }
}