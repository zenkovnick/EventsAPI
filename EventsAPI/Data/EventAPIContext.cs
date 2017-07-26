using EventAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Data
{
    public class EventAPIContext : DbContext
    {
        public EventAPIContext(DbContextOptions<EventAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Event> Events { get; set; }

    }
}
