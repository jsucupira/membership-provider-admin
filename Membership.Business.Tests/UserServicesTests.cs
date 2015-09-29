using System.Collections.Generic;
using DeepEqual.Syntax;
using Membership.Business.Tests.Mock;
using Membership.Common.Exceptions;
using Membership.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Membership.Business.Tests
{
    [TestClass]
    public class UserServicesTests
    {
        [TestInitialize]
        public void Init()
        {
            MefLoader.Init();
            UserDataMock.Reset();
            RoleDataMock.Reset();
        }

        [TestMethod]
        public void test_adding_user()
        {
            Assert.IsTrue(UserServices.FindAll().Count == 1);
            AspUser expected = new AspUser {Email = "jsucupira@test.com", UserName = "jsucupira", Id = "2"};
            UserServices.AddUser(expected.UserName, expected.Email, "test");
            Assert.IsTrue(UserServices.FindAll().Count == 2);
            AspUser actual = UserServices.FindUser(expected.UserName);
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        public void test_finding_user()
        {
            AspUser expected = new AspUser {UserName = "Admin", Id = "1"};
            AspUser actual = UserServices.FindUser("admin");
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof (NotFoundException), "User 'admin' not found.")]
        public void test_removing_user()
        {
            UserServices.RemoveUser("admin");
            Assert.IsTrue(UserServices.FindAll().Count == 0);
            UserServices.FindUser("admin");
        }

        [TestMethod]
        public void test_retrieving_users()
        {
            List<AspUser> expected = new List<AspUser> {new AspUser {UserName = "Admin", Id = "1"}};
            IEnumerable<AspUser> actual = UserServices.FindAll();
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }
    }
}