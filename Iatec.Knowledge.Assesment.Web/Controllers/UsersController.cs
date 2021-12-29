using Iatec.Knowledge.Assesment.Web.Responses;
using Iatec.Knowledge.Assessment.Business;
using Iatec.Knowledge.Assessment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Iatec.Knowledge.Assesment.Web.Controllers
{
    public class UsersController : ApiController
    {
        private UserBusiness _userBusiness;
        public UsersController()
        {
            _userBusiness = new UserBusiness();
        }

        public JsonResult<ApiResponse<IEnumerable<User>>> Get()
        {

            var response = new ApiResponse<IEnumerable<User>>();
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var identity = User.Identity.Name;

                    var userList =_userBusiness.Get();
                    response.Data = userList;
                    response.Status = userList.Count() > 0 ? true : false;
                    response.Message = userList.Count() > 0 ? String.Empty : "No events have been added, Add one :)";
                }


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return Json(response);
        }
    }
}
