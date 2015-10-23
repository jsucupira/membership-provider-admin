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
            AspUser user = new AspUser
            {
                UserName = userName,
                Email = email
            };
            UserDataMock.Add(user);
            return user;
        }

        public void UpdateUserEmail(string userName, string newEmail)
        {
            AspUser user = UserDataMock.FindByUserName(userName);
            user.Email = newEmail;
            UserDataMock.Update(user);
        }

        public bool UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            return true;
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