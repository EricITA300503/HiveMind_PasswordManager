using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PasswordManager.Controllers
{
    
    [Authorize]
    public class PasswordToolsController : Controller
    {
        public PasswordToolsController()
        {
        }

        public IActionResult Generator()
        {
            return View();
        }
    }
}