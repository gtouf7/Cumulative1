using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    public class TeacherController : Controller
    {   
        
        
        public ActionResult Index()
        {
            return View();
        }

        //GET teacher/list
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> teachers = controller.ListTeachers();
            return View(teachers);
        }

        //GET teacher/show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

           return View(NewTeacher);
        }
    }
}