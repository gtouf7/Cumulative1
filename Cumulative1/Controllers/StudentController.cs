using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    public class StudentsController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        //GET students/list
        public ActionResult List()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> students = controller.ListStudent();
            return View(students);
        }

        //GET students/show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }
    }
}