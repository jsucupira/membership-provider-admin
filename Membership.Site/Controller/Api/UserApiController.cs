using System.Collections.Generic;
using System.Web.Http;
using Membership.Business;
using Membership.Model.Users;
using Membership.Site.Models;

namespace Membership.Site.Controller.Api
{
    [RoutePrefix("api/users")]
    public class UserApiController : ApiController
    {
        [Route("")]
        [HttpPost]
        public AspUser Create(UserRequest userRequest)
        {
            return UserServices.AddUser(userRequest.UserName, userRequest.Email, userRequest.Password);
        }

        [Route("{userName}")]
        [HttpDelete]
        public void DeleteUser(string userName)
        {
            UserServices.DeleteUser(userName);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AspUser> FindAll()
        {
            return UserServices.FindAll();
        }

        [Route("{userName}")]
        [HttpGet]
        public AspUser GetByName(string userName)
        {
            return UserServices.GetUser(userName);
        }
    }
}