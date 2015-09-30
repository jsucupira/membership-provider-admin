using System.Threading;
using Membership.Business.Tests.Mock;
using Membership.Implementations.AspNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Membership.Business.Tests
{
    [TestClass]
    public abstract class BaseTestClass
    {
        private readonly bool _testIdentityProvider = false;

        protected BaseTestClass(bool integrationTest)
        {
            _testIdentityProvider = integrationTest;
        }

        [TestCleanup]
        public void Clean()
        {
            if (_testIdentityProvider)
                ApplicationDbContext.DeleteDatabase();
            else
            {
                UserDataMock.Reset();
                RoleDataMock.Reset();
            }
        }

        [TestInitialize]
        public void Init()
        {
            Monitor.Enter(MefLoader.SynchronizationLock);

            if (_testIdentityProvider)
                MefLoader.InitIdentityContainer(); // Uncomment to run integration test
            else
                MefLoader.Init();

            UserServices.AddUser("Admin", "admin@test.com", "Nq2gzAQK9w1N");
            RoleServices.CreateRole("Administrator");
        }
    }
}