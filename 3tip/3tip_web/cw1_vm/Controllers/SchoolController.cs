using cw1_vm.Models;
using cw1_vm.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace cw1_vm.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolRepo _schoolRepo;
        public SchoolController(IConfiguration configuration)
        {
            _schoolRepo = new SchoolRepo(configuration);
        }
        // GET: SchoolController
        public ActionResult List()
        {
            List<StudentDepartmentVM> studentsWithDepartments = _schoolRepo.GetStudentsWithDepartments();
            return View(studentsWithDepartments);
        }

    }
}
