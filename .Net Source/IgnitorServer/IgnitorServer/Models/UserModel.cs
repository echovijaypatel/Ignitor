﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IgnitorServer.Models
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