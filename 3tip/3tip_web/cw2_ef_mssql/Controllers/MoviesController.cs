using Microsoft.AspNetCore.Mvc;

namespace cw2_ef_mssql.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
