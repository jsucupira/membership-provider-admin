using System.Linq;
using Membership.Model.Roles;
using Membership.Model.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Implementations.AspNet
{
    internal static class Mapping
    {
        public static AspUser Map(this IdentityUser user)
        {
            if (user == null) return null;

            return new AspUser
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public static IdentityUser Map(this AspUser user)
        {
            if (user == null) return null;

            return new IdentityUser
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public static IdentityRole Map(this AspRole role)
        {
            if (role == null) return null;
            
            return new IdentityRole
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static AspRole Map(this IdentityRole role)
        {
            if (role == null) return null;
            
            return new AspRole
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}