using DBHandler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBHandler;
namespace IgnitorServer.Controllers
{
    public class UserApiController : ApiController
    {
        DBClass dbObject = null;

        public UserApiController()
        {
            dbObject = new DBClass();
        }

        [HttpPost]
        [Route("ValidateUser")]
        public UserModel ValidateUser([FromBody]UserModel userModel)
        {
            dbObject.ValidateUser(userModel);
            return userModel;
        }

        [HttpPost]
        [Route("TotalUsers")]
        public int TotalUsers()
        {
            return dbObject.TotalUser();
        }
    }
}
