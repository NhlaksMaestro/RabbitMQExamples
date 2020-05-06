using RabbitMQ.CSharp.Subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RabbitMQDotNet.MVC.Controllers.api
{
    public class SubscriberController : BaseController
    {
        public SubscriberController()
        {
            System.Web.Routing.RouteData context = System.Web.HttpContext.Current.Request.RequestContext.RouteData;
            this.PublishApi(context);
        }
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
