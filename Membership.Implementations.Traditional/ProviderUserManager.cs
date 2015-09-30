using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Security;
using Membership.Model.Users;

namespace Membership.Implementations.Traditional
{
    [Export(typeof (IUserManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ProviderUserManager : IUserManager
    {
        public bool CreateUser(string userName, string email, string password)
        {
            try
            {
                MembershipUser user = System.Web.Security.Membership.CreateUser(userName, password, email);
            }
            catch (MembershipCreateUserException)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<AspUser> FindAll()
        {
            List<AspUser> users = new List<AspUser>();
            MembershipUserCollection userCollection = System.Web.Security.Membership.GetAllUsers();
            if (userCollection != null)
            {
                foreach (MembershipUser membershipUser in userCollection)
                    users.Add(membershipUser.Map());
            }

            return users;
        }

        public AspUser FindByUserName(string userName)
        {
            return System.Web.Security.Membership.GetUser(userName).Map();
        }

        public bool DeleteUser(string userName)
        {
            //Not sure but this is not deleting the user from the aspnet_users table
            return System.Web.Security.Membership.DeleteUser(userName, true);
        }
    }
}