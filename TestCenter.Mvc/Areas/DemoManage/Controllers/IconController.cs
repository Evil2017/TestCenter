using Microsoft.AspNetCore.Mvc;

namespace TestCenter.Admin.Web.Areas.DemoManage.Controllers
{
    [Area("DemoManage")]
    public class IconController : Controller
    {
        public IActionResult FontAwesome()
        {
            return View();
        }
    }
}