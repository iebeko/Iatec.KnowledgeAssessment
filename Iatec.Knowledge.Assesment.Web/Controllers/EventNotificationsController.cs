using Iatec.Knowledge.Assesment.Web.CustomAuthentication;
using Iatec.Knowledge.Assesment.Web.Responses;
using Iatec.Knowledge.Assessment.Business;
using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class EventNotificationsController : ApiController
    {
        private EventNotificationBusiness _eventNotificationsBusiness;
        public EventNotificationsController()
        {
            _eventNotificationsBusiness = new EventNotificationBusiness();
        }

        public JsonResult<ApiResponse<IEnumerable<EventNotification>>> Get()
        {

            var response = new ApiResponse<IEnumerable<EventNotification>>();
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var identity = ((CustomPrincipal)HttpContext.Current.User);
                    

                    var ScheduleList = _eventNotificationsBusiness.Get().Where(c => c.IdUser == identity.UserId && c.IsAcepted == false );
                    response.Data = ScheduleList;
                    response.Status = ScheduleList.Count() > 0 ? true : false;
                    response.Message = ScheduleList.Count() > 0 ? String.Empty : "No events have been added, Add one :)";
                }


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var response = new ApiResponse<EventNotification>();

            try
            {
                var result = _eventNotificationsBusiness.GetById(id);
                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }


            return Json(response);
        }

        [HttpPost]
        // POST api/values
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> PostEvent(EventNotification entity)
        {
            var response = new ApiResponse<Schedule>();
            try
            {
                if (entity.IdEventNotification == 0)
                {
                    if (User.Identity.IsAuthenticated == true)
                    {
                       
                        await _eventNotificationsBusiness.Insert(entity);
                        response.Status = true;
                    }
                    else
                    {
                        throw new Exception("User must be authenticated");
                    }
                }
                else
                {
                    await _eventNotificationsBusiness.Update(entity);
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
        public async Task<IHttpActionResult> PutSchedule(int id, EventNotification entity)
        {
            var response = new ApiResponse<Event>();
            try
            {
                await _eventNotificationsBusiness.Update(entity);
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
            var Event = _eventNotificationsBusiness.GetById(id);
            if (Event.IdEventNotification == 0)
            {
                return BadRequest();
            }
            else
            {
                await _eventNotificationsBusiness.Delete(id);
            }
            return Ok(Event);
        }
    }
}
