using System.Collections.Generic;
using Membership.Model.Roles;

namespace Membership.Model.Users
{
    /// <summary>
    /// Class AspUser. This class cannot be inherited.
    /// </summary>
    public sealed class AspUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspUser"/> class.
        /// </summary>
        public AspUser()
        {
            AspRoles = new List<AspRole>();
        }

        /// <summary>
        /// Gets or sets the ASP roles.
        /// </summary>
        /// <value>The ASP roles.</value>
        public ICollection<AspRole> AspRoles { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
    }
}