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
        public IActionResult ListDepartments()
        {
            //dane z modelu
            var departmentsWithCount = _schoolRepo.GetDepartmentStudent();
            //wysłanie do widoku
            return View(departmentsWithCount);
        }
        //do pustego formularza
        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBag.deps = GetDepartments();
            return View();
        }
        //wykonanie zapytania do bazy po nacisnięciu submit
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            ViewBag.deps = GetDepartments();
            if (ModelState.IsValid)
            {
                _schoolRepo.AddStudent(student);
                return RedirectToAction(nameof(List));
            }
            return View();
        }
        private List<Department> GetDepartments()
        {
            var deps = _schoolRepo.GetDepartments();
            return deps;
        }
    }
}
