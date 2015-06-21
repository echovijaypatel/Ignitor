using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgnitorServer.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DBHandler.Entities;
namespace IgnitorTester
{
    [TestClass]
    public class IgnitorServerTester
    {
        [TestMethod]
        public void IgnitorApiTester()
        {
            //creating api reference
            var IgnitorApi = new IgnitorApiController();

            IgnitorApi.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5151/api/IgnitorApi")
            };

            IgnitorApi.Configuration = new HttpConfiguration();
            IgnitorApi.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            IgnitorApi.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "IgnitorApi" } });


            var response = IgnitorApi.Get(10);

            // Assert checking get method
            string data="value";
            Assert.AreEqual(data, response);


            // Act checking post method
            string temp = "value";

            //calling api method
            var responce= IgnitorApi.Get(5);
            //Console.WriteLine(responce.Sid);
            //Assert
           // Assert.AreEqual("http://localhost:5151/api/IgnitorApi/1", responce.Headers.Location.AbsoluteUri);
        }

        [TestMethod]
        public void UserApiTester()
        {
           var UserApi = new UsersApiController();

            var userModel = new UserModel();
            userModel.Username = "vijay";
            userModel.Password = "vijay";

            var result=UserApi.ValidateUser(userModel);
        }
    }
}
