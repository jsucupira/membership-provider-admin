using System.Collections.Generic;

namespace Membership.Model.Users
{
    /// <summary>
    /// Interface IUserManager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if user was created, <c>false</c> otherwise.</returns>
        bool CreateUser(string userName, string email, string password);
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>All users.</returns>
        IList<AspUser> FindAll();
        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AspUser.</returns>
        AspUser FindByUserName(string userName);
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns><c>true</c> if user was deleted, <c>false</c> otherwise.</returns>
        bool DeleteUser(string userName);
    }
}