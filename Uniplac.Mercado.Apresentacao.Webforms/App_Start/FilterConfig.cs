using System.Web;
using System.Web.Mvc;

namespace Uniplac.Mercado.Apresentacao.Webforms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
