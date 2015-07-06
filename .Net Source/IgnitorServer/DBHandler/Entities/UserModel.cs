using System;
using System.ComponentModel;

namespace DBHandler.Entities
{
    public class UserModel
    {
        [DefaultValue("")]
        public string Username { get; set; }
        [DefaultValue("")]
        public string Password { get; set; }
        [DefaultValue("")]
        public string Email { get; set; }
        [DefaultValue("")]
        public string Mobile { get; set; }
        [DefaultValue("")]
        public string Token { get; set; }
    }
}
