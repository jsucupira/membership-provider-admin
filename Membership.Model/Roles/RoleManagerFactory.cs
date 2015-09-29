using Membership.Common.Extensibility;

namespace Membership.Model.Roles
{
    public static class RoleManagerFactory
    {
        public static IRoleManager Create()
        {
            return MefBase.Resolve<IRoleManager>();
        }
    }
}