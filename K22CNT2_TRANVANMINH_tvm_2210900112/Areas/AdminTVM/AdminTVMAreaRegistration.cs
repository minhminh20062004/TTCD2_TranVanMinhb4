using System.Web.Mvc;

namespace K22CNT2_TRANVANMINH_tvm_2210900112.Areas.AdminTVM
{
    public class AdminTVMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminTVM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminTVM_default",
                "AdminTVM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}