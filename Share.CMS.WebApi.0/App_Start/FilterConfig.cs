using System.Web;
using System.Web.Mvc;

namespace Share.CMS.WebApi._0
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
