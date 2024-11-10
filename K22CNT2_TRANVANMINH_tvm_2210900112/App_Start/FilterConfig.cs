using System.Web;
using System.Web.Mvc;

namespace K22CNT2_TRANVANMINH_tvm_2210900112
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
