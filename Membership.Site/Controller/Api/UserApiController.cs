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
        public AspUser Create([FromBody] UserRequest userRequest)
        {
            return UserServices.AddUser(userRequest.UserName, userRequest.Email, userRequest.Password);
        }

        [Route("")]
        [HttpDelete]
        public void DeleteUser([FromUri] string userName)
        {
            UserServices.DeleteUser(userName);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<AspUser> FindAll()
        {
            return UserServices.FindAll();
        }

        [Route("")]
        [HttpGet]
        public AspUser GetByName([FromUri] string userName)
        {
            return UserServices.GetUser(userName);
        }

        [Route("")]
        [HttpPut]
        public void UpdateUser([FromUri]string userName, [FromBody] UserRequest userRequest)
        {
            UserServices.UpdateUser(userName, userRequest.NewEmail);
        }
    }
}