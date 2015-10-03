using System.Collections.Generic;
using System.ComponentModel.Composition;
using Membership.Model.Users;

namespace Membership.Business.Tests.Mock
{
    [Export(typeof (IUserManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class UserMock : IUserManager
    {
        public AspUser CreateUser(string userName, string email, string password)
        {
            if (UserDataMock.FindByUserName(userName) != null) return null;
            var user = new AspUser
            {
                UserName = userName,
                Email = email
            };
            UserDataMock.Add(user);
            return user;
        }

        public IEnumerable<AspUser> FindAll()
        {
            return UserDataMock.FindAll();
        }

        public AspUser FindByUserName(string userName)
        {
            return UserDataMock.FindByUserName(userName);
        }

        public bool DeleteUser(string userName)
        {
            UserDataMock.Remove(userName);
            return true;
        }
    }
}