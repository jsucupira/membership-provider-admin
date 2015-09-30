using System.Web.Security;
using Membership.Model.Users;

namespace Membership.Implementations.Traditional
{
    internal static class Mapping
    {
        public static AspUser Map(this MembershipUser user)
        {
            if (user == null) return null;

            return new AspUser
            {
                Email = user.Email,
                Id = user.ProviderUserKey.ToString(),
                UserName = user.UserName
            };
        }
    }
}