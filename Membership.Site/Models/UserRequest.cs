using System;

namespace Membership.Site.Models
{
    [Serializable]
    public class UserRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewEmail { get; set; }
    }
}