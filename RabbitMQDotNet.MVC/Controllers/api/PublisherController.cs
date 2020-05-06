using MongoDB.Bson;
using MongoDB.Driver;
using RabbitMQ.CSharp.Publisher;
using RabbitMQDotNet.MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RabbitMQDotNet.MVC.Controllers.api
{
    public class PublisherController : BaseController
    {
        string _connectionString = "", _databaseName = "";
        IMongoDatabase _database = default(IMongoDatabase);

        MongoClient _server = default(MongoClient);
        IMongoCollection<User> _collection = default(IMongoCollection<User>);
        PublisherController()
        {
            System.Web.Routing.RouteData context = System.Web.HttpContext.Current.Request.RequestContext.RouteData;
            this.PublishApi(context);
            _connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            //take database name from connection string
            _databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            _server = new MongoClient(_connectionString);

            //and then get database by database name:
            _database = _server.GetDatabase(_databaseName);
            _collection = _database.GetCollection<User>("Users");
        }
        // GET: api/Publisher
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var collection = await _collection.Find(new BsonDocument()).ToListAsync();
                return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // GET: api/Publisher/{id}
        public async Task<HttpResponseMessage> Get(string id)
        {
            try
            {
                var user = await _collection.Find(Builders<User>.Filter.Where(s => s.Id == id)).FirstOrDefaultAsync();
                return Request.CreateResponse(HttpStatusCode.OK, user, "application/json");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // POST: api/Publisher/{id}
        public async Task<HttpResponseMessage> Post([FromBody] User user)
        {
            try
            {
                _collection.InsertOne(user);
                var createdUser = await _collection.Find(Builders<User>.Filter.Where(s => s.FirstName == user.FirstName &&
                s.LastName == user.LastName &&
                s.DateOfBirth == user.DateOfBirth)).FirstOrDefaultAsync();
                return Request.CreateResponse(HttpStatusCode.OK, createdUser, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // Put: api/Publisher
        public async Task<HttpResponseMessage> Put([FromBody] User user)
        {
            try
            {
                var update = await _collection.FindOneAndUpdateAsync(Builders<User>
                    .Filter.Eq("Id", user.Id), Builders<User>
                    .Update.Set("Name", user.FirstName)
                    .Set("Surname", user.LastName)
                    .Set("DateOfBirth", user.DateOfBirth));
                return Request.CreateResponse(HttpStatusCode.OK, update, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // Delete: api/Publisher
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                var deleteRecored = await _collection.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
                return Request.CreateResponse(HttpStatusCode.OK, deleteRecored, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
