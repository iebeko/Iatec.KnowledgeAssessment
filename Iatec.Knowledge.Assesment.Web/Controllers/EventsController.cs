using Iatec.Knowledge.Assessment.Business;
using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class EventsController : ApiController
    {
        private EventBusiness _eventBusiness;
        public EventsController()
        {
            _eventBusiness = new EventBusiness();
        }
        // GET: Events
        public IEnumerable<Event> Get()
        {
            var eventList = _eventBusiness.Get();

            return eventList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}