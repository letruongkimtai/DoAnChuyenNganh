using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh.Ver2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
