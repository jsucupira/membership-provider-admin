using System.Collections.Generic;
using System.Web.Http;
using Membership.Business;
using Membership.Model.Roles;
using Membership.Model.Users;
using Membership.Site.Models;

namespace Membership.Site.Controller.Api
{
    [RoutePrefix("api/roles")]
    public class RoleApiController : ApiController
    {
        [Route("{roleName}/users/{userName}")]
        [HttpPut]
        public void AddUserToRole([FromUri] string roleName, [FromUri] string userName)
        {
            RoleServices.AddUserToRole(userName, roleName);
        }

        [Route("")]
        [HttpPost]
        public AspRole Create([FromBody] RoleRequest roleRequest)
        {
            return RoleServices.CreateRole(roleRequest.Name);
        }

        [Route("{roleName}")]
        [HttpPut]
        public void Update([FromUri] string roleName, [FromBody] RoleRequest roleRequest)
        {
            RoleServices.RenameRole(roleName, roleRequest.NewName);
        }

        [Route("{roleName}")]
        [HttpDelete]
        public void DeleteUser([FromUri] string roleName)
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
        [HttpGet]
        public IEnumerable<AspRole> FindRolesForUser([FromUri] string userName)
        {
            return RoleServices.FindRolesForUser(userName);
        }

        [Route("{roleName}/users")]
        [HttpGet]
        public IEnumerable<AspUser> FindUsersForRole([FromUri] string roleName)
        {
            return RoleServices.FindUsersInRole(roleName);
        }

        [Route("{roleName}")]
        [HttpGet]
        public AspRole GetByName([FromUri] string roleName)
        {
            return RoleServices.GetRole(roleName);
        }

        [Route("{roleName}/users/{userName}")]
        [HttpDelete]
        public void RemoveUserToRole([FromUri] string roleName, [FromUri] string userName)
        {
            RoleServices.RemoveUserFromRole(userName, roleName);
        }
    }
}