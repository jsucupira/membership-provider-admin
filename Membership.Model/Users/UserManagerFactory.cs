using Membership.Common.Extensibility;

namespace Membership.Model.Users
{
    public static class UserManagerFactory
    {
        public static IUserManager Create()
        {
            return MefBase.Resolve<IUserManager>();
        }
    }
}