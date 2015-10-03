using System.Threading;
using Membership.Business.Tests.Mock;
using Membership.Model.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Membership.Business.Tests
{
    [TestClass]
    public abstract class BaseTestClass
    {
        private readonly IntegrationEnum _integrationEnum;
        private readonly bool _testIdentityProvider;

        protected BaseTestClass()
        {
        }

        protected BaseTestClass(IntegrationEnum integrationType)
        {
            _testIdentityProvider = true;
            _integrationEnum = integrationType;
        }

        [TestInitialize]
        public void Init()
        {
            Monitor.Enter(MefLoader.SynchronizationLock); //One test at the time

            if (_testIdentityProvider)
            {
                MefLoader.Init(_integrationEnum);

                UserServices.FindAll().ForEach(user =>
                {
                    user.AspRoles = RoleServices.FindRolesForUser(user.UserName);
                    foreach (AspRole aspRole in user.AspRoles)
                        RoleServices.RemoveUserFromRole(user.UserName, aspRole.Name);

                    UserServices.DeleteUser(user.UserName);
                });


                RoleServices.FindAll().ForEach(t => RoleServices.DeleteRole(t.Name));
            }
            else
            {
                MefLoader.Init();
                UserDataMock.Reset();
                RoleDataMock.Reset();
            }

            UserServices.AddUser("Admin", "admin@test.com", "Nq2gzAQK9w1N");
            RoleServices.CreateRole("Administrator");
        }
    }
}