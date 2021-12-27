
using Iatec.Knowledge.Assesment.Web.Responses;
using Iatec.Knowledge.Assessment.Business;
using Iatec.Knowledge.Assessment.Entity;
using Iatec.Knowledge.Assessment.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;


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
      
        
        public JsonResult<ApiResponse<IEnumerable<Event>>> Get([FromUri] EventFilters entity)
        {
            var response = new ApiResponse<IEnumerable<Event>>();
            try
            {
               
                var eventList = _eventBusiness.Get(entity);
                response.Data = eventList;
                response.Status = eventList.Count() > 0 ? true : false;
                response.Message = eventList.Count() > 0 ? String.Empty : "No events have been added, Add one :)";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

       
        // GET api/values/5
        public IHttpActionResult  Get(int id)
        {
            var response = new ApiResponse<Event>();

            try
            {
                var result = _eventBusiness.GetById(id);
                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;

            }


            return Json(response);
        }


        [HttpPost]
        // POST api/values
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> PostEvent(Event entity)
        {
            var response = new ApiResponse<Event>();
            try
            {
                if (entity.IdEvent == 0)
                {
                    if (User.Identity.IsAuthenticated == true)
                    {
                        entity.UserOwner = User.Identity.Name;
                        await _eventBusiness.Insert(entity);
                        response.Status = true;
                    }
                    else
                    {
                        throw new Exception("User must be authenticated");
                    }
                }
                else 
                {
                    await _eventBusiness.Update(entity);
                }
           
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }


            return Ok(response);
        }

        [HttpPut]
        // PUT api/values/5
        [ResponseType(typeof(ApiResponse<Event>))]
        public async Task<IHttpActionResult> PutEvent(int id, Event entity)
        {
            var response = new ApiResponse<Event>();
            try 
            {
                await _eventBusiness.Update(entity);
                response.Status = true;
                
            }
            catch (Exception ex) 
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        // DELETE api/values/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var Event = _eventBusiness.GetById(id);
            if (Event.IdEvent == 0)
            {
                return BadRequest();
            }
            else 
            {
                await _eventBusiness.Delete(id);
            }
            return Ok(Event);
        }
    }
}