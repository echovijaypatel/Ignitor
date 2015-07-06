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
    public class PhotosApiController : ApiController
    {
        DBClass dbObject = null;

        public PhotosApiController()
        {
            dbObject = new DBClass();
        }

        [HttpPost]
        [Route("SetPhotoOnFreind")]
        public void SetPhotoOnFreindMobile([FromBody]ReceivePhotoModel receivePhotoModel)
        {
            //List<SendPhotosModel> quotesList = new List<SendPhotosModel>();
            //quotesList = dbObject.SetPhotoOnFriendMobile(receivePhotoModel);
            //return quotesList;

            dbObject.SetPhotoOnFriendMobile(receivePhotoModel);
        }

    }
}
