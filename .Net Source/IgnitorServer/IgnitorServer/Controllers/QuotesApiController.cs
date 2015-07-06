using DBHandler;
using DBHandler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IgnitorServer.Controllers
{
    public class QuotesApiController : ApiController
    {

        DBClass dbObject = null;

        public QuotesApiController()
        {
            dbObject = new DBClass();
        }

        [HttpPost]
        [Route("GetAllQuotes")]
        public List<SendQuotesModel> GetAllQuotes([FromBody]UserModel userModel)
        {
            List<SendQuotesModel> quotesList = new List<SendQuotesModel>();
            quotesList = dbObject.GetAllQuotes();
            return quotesList;
        }


    }
}
