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

        public IHttpActionResult Get(string term)
        {

           
           
                    var userList =_userBusiness.Get().Where(c =>c.Username.Contains(term)).Select(a => new { label = a.FirstName.ToUpper() +" "+a.LastName.ToUpper(), value = a.IdUser});
                  
            return Json(userList);
        }
    }
}
