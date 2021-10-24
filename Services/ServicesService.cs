using BookingApplication.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApplication.Services
{
    public class ServicesService
    {
        private readonly IMongoCollection<Service> _service;

        public ServicesService(IBookingApplicationDatabaseSettings settings)
        
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _service = database.GetCollection<Service>(settings.ServicesCollectionName);
        }

        public List<Service> Get() =>
            _service.Find(service => true).ToList();

        public Service Get(string id) =>
            _service.Find<Service>(service => service.Id == id).FirstOrDefault();

        public Service Create(Service service)
        {
            _service.InsertOne(service);
            return service;
        }

        public void Update(string id, Service serviceIn) =>
            _service.ReplaceOne(service => service.Id == id, serviceIn);

        public void Remove(Service serviceIn) =>
            _service.DeleteOne(service => service.Id == serviceIn.Id);

        public void Remove(string id) =>
            _service.DeleteOne(service => service.Id == id);
    }
}

