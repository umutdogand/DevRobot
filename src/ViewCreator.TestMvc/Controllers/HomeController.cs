namespace ViewCreator.TestMvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewCreator.TestMvc.Model;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Login olmamış ise login sayfasına yönlendirir.
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Json(new { });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (LoginViewModel.Validate(loginViewModel.Username, loginViewModel.Password))
            {
                // Index sayfasına yönlendirir.
                return Json(new { });
            }

            // Olumsuz sonuç döner
            return Json(new { });
        }
    }
}