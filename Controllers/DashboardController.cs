using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystemv2.Controllers
{
    [Authorize] // Ensures only logged-in users can access this controller
    [Authorize(Roles = "Student")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
