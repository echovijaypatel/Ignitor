using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IgnitorServer.Controllers
{
    public class TestController : ApiController
    {   
        [HttpPost]
        [Route("TestMethod")]
        public int getTest()
        {
            return 5;
        }
    }
}
