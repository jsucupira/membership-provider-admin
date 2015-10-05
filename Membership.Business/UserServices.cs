using System.Collections.Generic;
using System.Linq;
using Membership.Common.Exceptions;
using Membership.Common.Validations;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Business
{
    public static class UserServices
    {
        public static AspUser AddUser(string userName, string email, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            if (string.IsNullOrEmpty(email))
                throw new MissingValueException("Email Address");

            if (string.IsNullOrEmpty(password))
                throw new MissingValueException("Password");

            if (!email.IsValidEmail())
                throw new InvalidValueException("Email Address", email);

            var result = UserManagerFactory.Create().CreateUser(userName, email, password);
            if (result == null)
                throw new BadOperationException($"Unable to create user '{userName}'.");

            return result;
        }

        public static void DeleteUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            bool result = UserManagerFactory.Create().DeleteUser(userName);
            if (!result)
                throw new BadOperationException($"Unable to delete user '{userName}'.");
        }

        public static List<AspUser> FindAll()
        {
            List<AspUser> users = UserManagerFactory.Create().FindAll().ToList();
            return users;
        }

        public static AspUser GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            AspUser user = UserManagerFactory.Create().FindByUserName(userName);
            if (user == null)
                throw new NotFoundException("User", userName);

            user.AspRoles = RoleManagerFactory.Create().FindRolesForUser(user.UserName).ToList();
            return user;
        }

        public static void UpdateUser(string oldEmail, string newEmail)
        {
            if (string.IsNullOrEmpty(oldEmail))
                throw new MissingValueException("Old Email Address");

            if (string.IsNullOrEmpty(newEmail))
                throw new MissingValueException("New Email Address");

            if (!oldEmail.IsValidEmail())
                throw new InvalidValueException("Old Email Address", oldEmail);

            if (!newEmail.IsValidEmail())
                throw new InvalidValueException("New Email Address", newEmail);

            UserManagerFactory.Create().UpdateUserEmail(oldEmail, newEmail);
        }

        public static bool UpdateUserPassword(string userName, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            if (string.IsNullOrEmpty(oldPassword))
                throw new MissingValueException("Old Password");

            if (string.IsNullOrEmpty(newPassword))
                throw new MissingValueException("New Password");

            return UserManagerFactory.Create().UpdatePassword(userName, oldPassword, newPassword);
        }
    }
}