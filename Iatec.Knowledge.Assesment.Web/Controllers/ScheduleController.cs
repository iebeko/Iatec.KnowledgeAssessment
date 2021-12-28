using Iatec.Knowledge.Assesment.Web.CustomAuthentication;
using Iatec.Knowledge.Assesment.Web.Responses;
using Iatec.Knowledge.Assessment.Business;
using Iatec.Knowledge.Assessment.Entity;
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
    public class ScheduleController : ApiController
    {
        private ScheduleBusiness _scheduleBusiness;
        public ScheduleController()
        {
            _scheduleBusiness = new ScheduleBusiness();
        }
        // GET: Schedule
        public JsonResult<ApiResponse<IEnumerable<Schedule>>> Index()
        {
            
            var response = new ApiResponse<IEnumerable<Schedule>>();
            try
            {
                if (User.Identity.IsAuthenticated) 
                {
                    var identity = ((CustomPrincipal)HttpContext.Current.User);
                    var ScheduleList = _scheduleBusiness.Get();
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
            var response = new ApiResponse<Schedule>();

            try
            {
                var result = _scheduleBusiness.GetById(id);
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
        public async Task<IHttpActionResult> PostEvent(Schedule entity)
        {
            var response = new ApiResponse<Schedule>();
            try
            {
                if (entity.IdSchedule == 0)
                {
                    if (User.Identity.IsAuthenticated == true)
                    {
                        var identity = ((CustomPrincipal)HttpContext.Current.User);
                        entity.IdUser = identity.UserId;
                        await _scheduleBusiness.Insert(entity);
                        response.Status = true;
                    }
                    else
                    {
                        throw new Exception("User must be authenticated");
                    }
                }
                else
                {
                    await _scheduleBusiness.Update(entity);
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
        public async Task<IHttpActionResult> PutSchedule(int id, Schedule entity)
        {
            var response = new ApiResponse<Event>();
            try
            {
                await _scheduleBusiness.Update(entity);
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
            var Event = _scheduleBusiness.GetById(id);
            if (Event.IdSchedule == 0)
            {
                return BadRequest();
            }
            else
            {
                await _scheduleBusiness.Delete(id);
            }
            return Ok(Event);
        }
    }
}