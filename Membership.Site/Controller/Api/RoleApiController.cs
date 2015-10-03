using System.Collections.Generic;
using System.Web.Http;
using Membership.Business;
using Membership.Model.Roles;
using Membership.Model.Users;

namespace Membership.Site.Controller.Api
{
    [RoutePrefix("api/roles")]
    public class RoleApiController : ApiController
    {
        [Route("{roleName}/users/{userName}")]
        [HttpPut]
        public void AddUserToRole(string roleName, string userName)
        {
            RoleServices.AddUserToRole(userName, roleName);
        }

        [Route("{roleName}")]
        [HttpPost]
        public AspRole Create(string roleName)
        {
            return RoleServices.CreateRole(roleName);
        }

        [Route("{roleName}")]
        [HttpDelete]
        public void DeleteUser(string roleName)
        {
            RoleServices.DeleteRole(roleName);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AspRole> FindAll()
        {
            return RoleServices.FindAll();
        }

        [Route("users/{userName}/roles")]
        [HttpDelete]
        public IEnumerable<AspRole> FindRolesForUser(string userName)
        {
            return RoleServices.FindRolesForUser(userName);
        }

        [Route("{roleName}/users")]
        [HttpDelete]
        public IEnumerable<AspUser> FindUsersForRole(string roleName)
        {
            return RoleServices.FindUsersInRole(roleName);
        }

        [Route("{roleName}")]
        [HttpGet]
        public AspRole GetByName(string roleName)
        {
            return RoleServices.GetRole(roleName);
        }

        [Route("{roleName}/users/{userName}")]
        [HttpDelete]
        public void RemoveUserToRole(string roleName, string userName)
        {
            RoleServices.RemoveUserFromRole(userName, roleName);
        }
    }
}