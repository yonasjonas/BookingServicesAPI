using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApplication.Models
{
    public class BookingApplicationDatabaseSettings : IBookingApplicationDatabaseSettings
    {
        public string ServicesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBookingApplicationDatabaseSettings
    {
        string ServicesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
