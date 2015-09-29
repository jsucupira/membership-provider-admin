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
        [ExpectedException(typeof(BadOperationException), "Unable to create user admin")]
        public void test_adding_duplicate_user()
        {
            UserServices.AddUser("admin", "jsucupira@test.com", "test");
        }

        [TestMethod]
        public void test_adding_user()
        {
            Assert.IsTrue(UserServices.FindAll().Count == 1);
            AspUser expected = new AspUser { Email = "jsucupira@test.com", UserName = "jsucupira", Id = "2" };
            UserServices.AddUser(expected.UserName, expected.Email, "test");
            Assert.IsTrue(UserServices.FindAll().Count == 2);
            AspUser actual = UserServices.FindUser(expected.UserName);
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidValueException), "Invalid value for Email Address 'jsucupira@test'.")]
        public void test_adding_user_email_validation()
        {
            UserServices.AddUser("jsucupira", "jsucupira@test", "test");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "UserName is required.")]
        public void test_adding_user_validation1()
        {
            UserServices.AddUser(null, "jsucupira@test.com", "test");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingValueException), "Email Address is required.")]
        public void test_adding_user_validation2()
        {
            UserServices.AddUser("jsucupira", "", "test");
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
            AspUser expected = new AspUser { UserName = "Admin", Id = "1" };
            AspUser actual = UserServices.FindUser("admin");
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
            List<AspUser> expected = new List<AspUser> { new AspUser { UserName = "Admin", Id = "1" } };
            IEnumerable<AspUser> actual = UserServices.FindAll();
            Assert.IsTrue(expected.IsDeepEqual(actual));

            UserServices.AddUser("jsucupira", "jsucupira@test.com", "test");
            expected.Add(new AspUser {Id = "2", Email = "jsucupira@test.com", UserName = "jsucupira"});
            actual = UserServices.FindAll();
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
            UserServices.AddUser("jsucupira", "jsucupira@test.com", "test");
            Assert.IsTrue(UserServices.FindAll().Count == 1);
        }
    }
}