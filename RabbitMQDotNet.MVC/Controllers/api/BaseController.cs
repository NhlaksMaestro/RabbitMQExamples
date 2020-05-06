using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RabbitMQDotNet.MVC.Controllers.api
{
    public class BaseController : ApiController
    {
        List<string> _messages;
        public BaseController()
        {
            _messages = new List<string>();
            System.Web.Routing.RouteData context = System.Web.HttpContext.Current.Request.RequestContext.RouteData;
            this.PublishApi(context);
        }
        public void PublishApi(System.Web.Routing.RouteData routeData)
        {
            try
            {

                string action = "";
                string controller = "";
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    if (routeData.Values["action"] != null)
                    {
                        action = routeData.GetRequiredString("action");
                        _messages.Add(string.Format("User called http action method: {0}!", action));
                    }
                    if (routeData.Values["controller"] != null)
                    {
                        controller = routeData.GetRequiredString("controller");
                        _messages.Add(string.Format("User has accessed controller: {0}!", controller));
                    }

                    var body = Encoding.UTF8.GetBytes(string.Join(",", _messages));

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public virtual async Task<HttpResponseMessage> Get()
        //{
        //    try
        //    {
        //        var t = await Task.Run(() => { return new List<string> { "Task" }; });
        //        return Request.CreateResponse(HttpStatusCode.OK, t, "application/json");
        //    }
        //    catch (Exception ex)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
        //// GET: api/Publisher/{id}
        //protected virtual async Task<HttpResponseMessage> Get(string id)
        //{
        //    try
        //    {
        //        var t = await Task.Run(() => { return "Task"; });
        //        return Request.CreateResponse(HttpStatusCode.OK, t, "application/json");
        //    }
        //    catch (Exception ex)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
        //// POST: api/Publisher/{id}
        ////public virtual async Task<HttpResponseMessage> Post([FromBody] object obj)
        ////{
        ////    try
        ////    {
        ////        var t = await Task.Run(() => { return obj; });
        ////        return Request.CreateResponse(HttpStatusCode.OK, t, "application/json");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        ////    }
        ////}
        ////// Put: api/Publisher
        ////public virtual async Task<HttpResponseMessage> Put([FromBody] object obj)
        ////{
        ////    try
        ////    {
        ////        var t = await Task.Run(() => { return obj; });
        ////        return Request.CreateResponse(HttpStatusCode.OK, t, "application/json");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        ////    }
        ////}
        //// Delete: api/Publisher
        //public virtual async Task<HttpResponseMessage> Delete(string id)
        //{
        //    try
        //    {
        //        var t = await Task.Run(() => { return id.ToString(); });
        //        return Request.CreateResponse(HttpStatusCode.OK, t, "application/json");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
    }
}
