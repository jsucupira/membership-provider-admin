using System.Collections.Generic;
using System.ComponentModel.Composition;
using Membership.Model;
using Membership.Model.Users;

namespace Membership.Business.Tests.Mock
{
    [Export(typeof (IUserManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class UserMock : IUserManager
    {
        public UserMock()
        {
            UserDataMock.Reset();
        }
        public bool CreateUser(string userName, string email, string password)
        {
            if (UserDataMock.FindByUserName(userName) != null) return false;

            UserDataMock.Add(new AspUser
            {
                UserName = userName,
                Email = email
            });
            return true;
        }

        public IList<AspUser> FindAll()
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