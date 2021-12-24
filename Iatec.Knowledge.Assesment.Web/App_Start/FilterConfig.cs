using System.Web;
using System.Web.Mvc;

namespace Iatec.Knowledge.Assesment.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
