using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Monitor.Enter(MefLoader.SynchronizationLock);
            //MefLoader.InitIdentityContainer(); // Uncomment to run integration test
            MefLoader.Init();
            UserDataMock.Reset();
            RoleDataMock.Reset();
            UserServices.AddUser("Admin", "admin@test.com", "Nq2gzAQK9w1N");
        }

        [TestMethod]
        [ExpectedException(typeof(BadOperationException), "Unable to create user admin")]
        public void test_adding_duplicate_user()
        {
            UserServices.AddUser("admin", "jsucupira@test.com", "Nq2gzAQK9w1N");
        }

        [TestMethod]
        public void test_adding_user()
        {
            Assert.IsTrue(UserServices.FindAll().Count == 1);
            AspUser expected = new AspUser { Email = "jsucupira@test.com", UserName = "jsucupira", Id = "2" };
            UserServices.AddUser(expected.UserName, expected.Email, "Nq2gzAQK9w1N");
            Assert.IsTrue(UserServices.FindAll().Count == 2);
            AspUser actual = UserServices.FindUser(expected.UserName);
            expected.Id = actual.Id;
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidValueException), "Invalid value for Email Address 'jsucupira@test'.")]
        public void test_adding_user_email_validation()
        {
            UserServices.AddUser("jsucupira", "jsucupira@test", "Nq2gzAQK9w1N");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "UserName is required.")]
        public void test_adding_user_validation1()
        {
            UserServices.AddUser(null, "jsucupira@test.com", "Nq2gzAQK9w1N");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "Email Address is required.")]
        public void test_adding_user_validation2()
        {
            UserServices.AddUser("jsucupira", "", "Nq2gzAQK9w1N");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "Password is required.")]
        public void test_adding_user_validation3()
        {
            UserServices.AddUser("jsucupira", "jsucupira@test.com", "");
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException), "User 'jsucupira' not found.")]
        public void test_finding_non_existing_user()
        {
            UserServices.FindUser("jsucupira");
        }

        [TestMethod]
        public void test_finding_user()
        {
            AspUser expected = new AspUser { UserName = "Admin", Id = "1", Email = "admin@test.com" };
            AspUser actual = UserServices.FindUser("admin");
            expected.Id = actual.Id;
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "UserName is required.")]
        public void test_finding_user_validation1()
        {
            UserServices.FindUser(null);
        }

        [TestMethod]
        public void test_finding_users()
        {
            List<AspUser> expected = new List<AspUser> { new AspUser { UserName = "Admin", Id = "1", Email = "admin@test.com" } };
            List<AspUser> actual = UserServices.FindAll().ToList();
            expected[0].Id = actual[0].Id;
            Assert.IsTrue(expected.IsDeepEqual(actual));
            UserServices.AddUser("jsucupira", "jsucupira@test.com", "Nq2gzAQK9w1N");
            expected.Add(new AspUser {Id = "2", Email = "jsucupira@test.com", UserName = "jsucupira"});
            actual = UserServices.FindAll();
            expected[1].Id = actual[1].Id;

            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "UserName is required.")]
        public void test_remove_user_validation1()
        {
            UserServices.RemoveUser("");
        }

        [TestMethod]
        public void test_removing_user()
        {
            UserServices.RemoveUser("admin");
            Assert.IsTrue(UserServices.FindAll().Count == 0);
            UserServices.AddUser("jsucupira", "jsucupira@test.com", "Nq2gzAQK9w1N");
            Assert.IsTrue(UserServices.FindAll().Count == 1);
        }
    }
}