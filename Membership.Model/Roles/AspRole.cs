using System.Collections.Generic;
using Membership.Model.Users;

namespace Membership.Model.Roles
{
    /// <summary>
    /// Class AspRole. This class cannot be inherited.
    /// </summary>
    public sealed class AspRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspRole"/> class.
        /// </summary>
        public AspRole()
        {
            AspUsers = new List<AspUser>();
        }

        /// <summary>
        /// Gets or sets the ASP users.
        /// </summary>
        /// <value>The ASP users.</value>
        public ICollection<AspUser> AspUsers { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}