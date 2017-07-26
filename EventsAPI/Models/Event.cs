using System;
namespace EventAPI.Models
{
    public class Event
    {
        public Event()
        {
        }
        public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Organizer { get; set; }
		public string VenueName { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
    }
}
