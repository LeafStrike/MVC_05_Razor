using System;
using System.Collections.Generic;
using MVC_Students.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Students.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student {Id = 1, Name = "Nick", Surname = "Valuev", GroupId = 1010, Status = "выпускник-бакалавр"},
            new Student {Id = 2, Name = "Dora", Surname = "TheTraveller", GroupId = 1024, Status = "бакалавр"},
            new Student {Id = 3, Name = "John", Surname = "Doe", GroupId = 1024, Status = "отчислен"},
            new Student {Id = 4, Name = "Frodo", Surname = "Baggins", GroupId = 1030, Status = "бакалавр"},
            new Student {Id = 5, Name = "Bilbo", Surname = "Baggins", GroupId = 1020, Status = "магистр"}
        };

        public IActionResult List()
        {
            return View(Students);
        }
        public IActionResult Card(int num)
        {
            return View(Students.Find(x => x.Id.Equals(num)));
        }
        

        public IActionResult Edit(int num)
        {
            return View(Students.Find(x => x.Id.Equals(num)));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            int num = student.Id;
            if (!ModelState.IsValid)
            {
                return Edit(num);
            }

            Students.Find(x => x.Id.Equals(num)).Name = student.Name;
            Students.Find(x => x.Id.Equals(num)).Surname = student.Surname;
            Students.Find(x => x.Id.Equals(num)).GroupId = student.GroupId;
            Students.Find(x => x.Id.Equals(num)).Status = student.Status;

            return RedirectToAction("List", "Student", new { num = student.Id });
        }
    }
}
