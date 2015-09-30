using System.Collections.Generic;
using DeepEqual.Syntax;
using Membership.Common.Exceptions;
using Membership.Model.Roles;
using Membership.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Membership.Business.Tests
{
    [TestClass]
    public class RoleServicesTests : BaseTestClass
    {
        public RoleServicesTests() : base(integrationTest: false) { }

        [TestMethod]
        public void test_adding_user_to_role()
        {
            UserServices.AddUser("jsucupira", "jsucupira@test.com", "Nq2gzAQK9w1N");
            Assert.IsTrue(UserServices.FindAll().Count == 2);
            RoleServices.AddUserToRole("jsucupira", "Administrator");
            List<AspUser> expected = new List<AspUser>
            {
                new AspUser
                {
                    Email = "jsucupira@test.com",
                    Id = "2",
                    UserName = "jsucupira"
                }
            };
            List<AspUser> actual = RoleServices.FindUsersInRole("Administrator");
            actual[0].AspRoles = new List<AspRole>();
            expected[0].Id = actual[0].Id;
            Assert.IsTrue(expected.IsDeepEqual(actual));
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "UserName is required.")]
        public void test_adding_user_to_role_validation1()
        {
            RoleServices.AddUserToRole("", "Administrator");
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "RoleName is required.")]
        public void test_adding_user_to_role_validation2()
        {
            RoleServices.AddUserToRole("admin", "");
        }

        [TestMethod]
        [ExpectedException(typeof (NotFoundException), "User 'jsucupira' not found.")]
        public void test_adding_user_to_role_validation3()
        {
            RoleServices.AddUserToRole("jsucupira", "Administrator");
        }

        [TestMethod]
        [ExpectedException(typeof (NotFoundException), "Role 'User' not found.")]
        public void test_adding_user_to_role_validation4()
        {
            RoleServices.AddUserToRole("jsucupira", "User");
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "RoleName is required.")]
        public void test_create_role()
        {
            RoleServices.CreateRole("");
        }

        [TestMethod]
        [ExpectedException(typeof (BadOperationException), "Unable to create role 'Administrator'.")]
        public void test_create_role_that_already_exists()
        {
            RoleServices.CreateRole("Administrator");
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "RoleName is required.")]
        public void test_delete_role()
        {
            RoleServices.DeleteRole(null);
        }

        [TestMethod]
        [ExpectedException(typeof (NotFoundException), "Role 'User' not found.")]
        public void test_find_non_existing_role()
        {
            RoleServices.FindRole("User");
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "RoleName is required.")]
        public void test_find_role()
        {
            RoleServices.FindRole(null);
        }

        [TestMethod]
        public void test_finding_all()
        {
            Assert.IsTrue(RoleServices.FindAll().Count == 1);
            RoleServices.CreateRole("User");
            Assert.IsTrue(RoleServices.FindAll().Count == 2);
            RoleServices.DeleteRole("user");
            Assert.IsTrue(RoleServices.FindAll().Count == 1);
            RoleServices.DeleteRole("administrator");
            Assert.IsTrue(RoleServices.FindAll().Count == 0);
        }

        [TestMethod]
        public void test_removing_user_from_role()
        {
            Assert.IsTrue(RoleServices.FindUsersInRole("Administrator").Count == 0);
            RoleServices.AddUserToRole("Admin", "Administrator");
            Assert.IsTrue(RoleServices.FindUsersInRole("Administrator").Count == 1);
            RoleServices.RemoveUserFromRole("Admin", "Administrator");
            Assert.IsTrue(RoleServices.FindUsersInRole("Administrator").Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "RoleName is required.")]
        public void test_removing_user_from_role_validation1()
        {
            RoleServices.RemoveUserFromRole("jsucupira", null);
        }

        [TestMethod]
        [ExpectedException(typeof (MissingValueException), "UserName is required.")]
        public void test_removing_user_from_role_validation2()
        {
            RoleServices.RemoveUserFromRole("", "Administrator");
        }
    }
}