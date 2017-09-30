using System.Web;
using System.Web.Mvc;

namespace COMP306_ONLINE_ORDER_LAB2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
