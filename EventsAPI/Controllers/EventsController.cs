using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Data;
using EventAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
	    private readonly EventAPIContext _context;

	    public EventsController(EventAPIContext context)
	    {
		    _context = context;
	    } 
	    
	    // GET: api/values
		[HttpGet(Name = "GetEvents")]
		public ActionResult Get()
		{
            //return new string[] { "value1", "value2" };
			List<Event> result = _context.Events.ToList();
			return new JsonResult(result);
		}

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEvent")]
        public ActionResult Get(int id)
        {
	        Event item = _context.Events.FirstOrDefault(t => t.ID == id);
	        if (item == null)
	        {
		        return NotFound();
	        }
	        return new JsonResult(item);
        }

        // POST api/values
        [HttpPost(Name = "PostEvent")]
        public ActionResult Post([FromBody]Event item)
        {
	        if (item == null)
	        {
		        return BadRequest();
	        }

	        _context.Events.Add(item);
	        _context.SaveChanges();
	        return CreatedAtRoute("GetEvent", new { id = item.ID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}", Name = "PutEvent")]
        public ActionResult Put(int id, [FromBody]Event paramItem)
        {
	        if (paramItem == null || paramItem.ID != id)
	        {
		        return BadRequest();
	        }

	        var item = _context.Events.FirstOrDefault(t => t.ID == id);
	        if (item == null)
	        {
		        return NotFound();
	        }

	        item.Title = paramItem.Title;
	        item.Description = paramItem.Description;
	        item.Address = paramItem.Address;
	        item.City = paramItem.City;
	        item.PostalCode = paramItem.PostalCode;
	        item.VenueName = paramItem.VenueName;
	        item.StartDate = paramItem.StartDate;
	        item.EndDate = paramItem.EndDate;

	        _context.Events.Update(item);
	        _context.SaveChanges();
	        return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = "DeleteEvent")]
        public ActionResult Delete(int id)
        {
	        Event item = _context.Events.First(t => t.ID == id);
	        if (item == null)
	        {
		        return NotFound();
	        }

	        _context.Events.Remove(item);
	        _context.SaveChanges();
	        return new NoContentResult();
        }
    }
}
