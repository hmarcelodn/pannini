using System.Web;
using System.Web.Mvc;

namespace Epiq.ETS.TCMS.Panini.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
