using System;
using System.Linq;
using Membership.Common.Exceptions;
using Membership.Common.Validations;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Business
{
    public static class UserServices
    {
        public static void AddUser(string userName, string email, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            if (string.IsNullOrEmpty(email))
                throw new MissingValueException("email");

            if (string.IsNullOrEmpty(password))
                throw new MissingValueException("password");

            if (!email.IsValidEmail())
                throw new InvalidValueException("Email Address", email);

            try
            {
                bool result = UserManagerFactory.Create().CreateUser(userName, email, password);
                if (!result)
                    throw new BadOperationException($"Unable to create user {userName}");
            }
            catch (Exception ex)
            {
                throw new BadOperationException($"Unable to create user {userName} -> ${ex.Message}");
            }
        }

        public static AspUser FindUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            AspUser user = UserManagerFactory.Create().FindByUserName(userName);
            if (user == null)
                throw new NotFoundException("User", userName);

            user.AspRoles = RoleManagerFactory.Create().FindRolesForUser(user.UserName).ToList();
            return user;
        }

        public static void RemoveUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new MissingValueException("UserName");

            try
            {
                bool result = UserManagerFactory.Create().DeleteUser(userName);
                if (!result)
                    throw new BadOperationException($"Unable to delete user {userName}");
            }
            catch (Exception ex)
            {
                throw new BadOperationException($"Unable to remove user {userName} -> ${ex.Message}");
            }
        }
    }
}