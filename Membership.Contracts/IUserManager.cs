using System.Collections.Generic;
using Membership.Model;

namespace Membership.Contracts
{
    /// <summary>
    /// Interface IUserManager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if user was created, <c>false</c> otherwise.</returns>
        bool CreateUser(AspUser user);
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>All users.</returns>
        IList<AspUser> FindAll();
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>AspUser.</returns>
        AspUser FindById(string userId);
        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>AspUser.</returns>
        AspUser FindByUserName(string userName);
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns><c>true</c> if user was deleted, <c>false</c> otherwise.</returns>
        bool DeleteUser(string userId);
    }
}