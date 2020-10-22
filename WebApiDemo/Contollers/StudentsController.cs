using DataAccess.ADO;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace WebApiDemo.Contollers
{
    public class StudentsController : Controller
    {
        private readonly Repository _repository;

        public StudentsController(Repository repository)
        {
            _repository = repository;
        }

        public IActionResult Students()
        {
            var model = _repository.GetAllStudents();
            return View(model);
        }


        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            ViewBag.Title = "Edit";
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            _repository.UpdateStudent(student);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            ViewBag.Title = "Create";

            return View("EditStudent", new Student());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _repository.CreateStudent(student);
            return RedirectToAction("Students");
        }
    }
}