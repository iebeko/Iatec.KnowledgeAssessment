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
    public class ScheduleEventsController : ApiController
    {
        private ScheduleEventBusiness _scheduleEventBusiness;
        public ScheduleEventsController()
        {
            _scheduleEventBusiness = new ScheduleEventBusiness();
        }

        public JsonResult<ApiResponse<IEnumerable<ScheduleEvent>>> Get()
        {

            var response = new ApiResponse<IEnumerable<ScheduleEvent>>();
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var identity = User.Identity.Name;

                    var ScheduleList = _scheduleEventBusiness.Get().Where(c => c.UserOwner == identity);
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
            var response = new ApiResponse<ScheduleEvent>();

            try
            {
                var result = _scheduleEventBusiness.GetById(id);
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
        public async Task<IHttpActionResult> PostEvent(ScheduleEvent entity)
        {
            var response = new ApiResponse<Schedule>();
            try
            {
                if (entity.IdScheduleEvent == 0)
                {
                    if (User.Identity.IsAuthenticated == true)
                    {
                        var identity = User.Identity.Name;
                        entity.UserOwner = identity;
                        
                        await _scheduleEventBusiness.Insert(entity);
                        response.Status = true;
                    }
                    else
                    {
                        throw new Exception("User must be authenticated");
                    }
                }
                else
                {
                    await _scheduleEventBusiness.Update(entity);
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
        public async Task<IHttpActionResult> PutSchedule(int id, ScheduleEvent entity)
        {
            var response = new ApiResponse<Event>();
            try
            {
                await _scheduleEventBusiness.Update(entity);
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
            var Event = _scheduleEventBusiness.GetById(id);
            if (Event.IdSchedule == 0)
            {
                return BadRequest();
            }
            else
            {
                await _scheduleEventBusiness.Delete(id);
            }
            return Ok(Event);
        }
    }
}
