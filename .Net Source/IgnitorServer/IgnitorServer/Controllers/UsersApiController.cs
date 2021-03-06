﻿using DBHandler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBHandler;
namespace IgnitorServer.Controllers
{
    public class UsersApiController : ApiController
    {
        DBClass dbObject = null;

        public UsersApiController()
        {
            dbObject = new DBClass();
        }

        UserModel[] userModel = new UserModel[] 
        { 
            new UserModel { Username="vijay",Password="vijay",Email="vijay",Mobile="9727566147",Token="vijay"},
            new UserModel { Username="harsh",Password="harsh",Email="harsh",Mobile="9727566147",Token="harsh"},
            new UserModel { Username="sunny",Password="sunny",Email="sunny",Mobile="9033164363",Token="sunny"},
        };

        
        [Route("ValidateUser")]
        public UserModel ValidateUser([FromBody]UserModel userModel)
        {
            dbObject.ValidateUser(userModel);
            return userModel;
        }
    }
}
