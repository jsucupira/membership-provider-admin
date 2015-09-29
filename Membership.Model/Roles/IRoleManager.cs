using System.Collections.Generic;
using Membership.Model.Users;

namespace Membership.Model.Roles
{
    /// <summary>
    /// Interface IRoleManager
    /// </summary>
    public interface IRoleManager
    {
        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if successfully added user to role, <c>false</c> otherwise.</returns>
        bool AddUserToRole(string userName, string roleName);
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if the role was created, <c>false</c> otherwise.</returns>
        bool CreateRole(string roleName);
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>All available roles.</returns>
        IEnumerable<AspRole> FindAll();
        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>AspRole.</returns>
        AspRole FindByName(string roleName);
        /// <summary>
        /// Removes the role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if Role was deleted, <c>false</c> otherwise.</returns>
        bool DeleteRole(string roleName);
        /// <summary>
        /// Removes the user from role.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if user was removed from role, <c>false</c> otherwise.</returns>
        bool RemoveUserFromRole(string userName, string roleName);

        /// <summary>
        /// Finds the roles for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>List of roles that the user is in.</returns>
        IEnumerable<AspRole> FindRolesForUser(string userName);

        /// <summary>
        /// Finds the users in role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>All users in the role.</returns>
        IEnumerable<AspUser> FindUsersInRole(string roleName);
    }
}