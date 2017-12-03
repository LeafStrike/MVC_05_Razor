using System;
using System.Collections.Generic;
using MVC_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_project.Controllers
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

        public IActionResult Card()
        {
            return View(Students);
        }
        

        public IActionResult Edit()
        {
            return View(Students);
        }

        [HttpPost]
        public IActionResult Edit(Student student, int num)
        {
            if (!ModelState.IsValid)
            {
                return Edit();
            }

            Students[num].Id = student.Id;
            Students[num].Name = student.Name;
            Students[num].Surname = student.Surname;
            Students[num].GroupId = student.GroupId;
            Students[num].Status = student.Status;

            return RedirectToAction("Card", "Student");
        }

        // CREATE
        [HttpPost]
        public ViewResult CreateStudent(int id, string name, string surname)
        {
            var student = new Student { Id = id, Name = name, Surname = surname };
            Students.Add(student);
            return View(student);
        }

        // READ
        [HttpGet]
        public Student GetStudentById(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    return st;
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpGet]
        public string GetStudentNameById(int id)
        {
            foreach(Student st in Students)
            {
                if (st.Id == id)
                {
                    return st.Name;
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpGet]
        public string GetStudentSurnameById(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    return st.Surname;
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpGet]
        public int GetStudentGroupById(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    return st.GroupId;
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpGet]
        public string GetStudentStatusById(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    return st.Status;
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        // UPDATE
        [HttpPut]
        public ViewResult SetStudentName(int id, string name)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    st.Name = name;
                    return View(st);
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpPut]
        public ViewResult SetStudentSurname(int id, string surname)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    st.Surname = surname;
                    return View(st);
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpPut]
        public ViewResult SetStudentGroup(int id, int groupId)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    st.GroupId = groupId;
                    return View(st);
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        [HttpPut]
        public ViewResult SetStudentStatus(int id, string status)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    st.Status = status;
                    return View(st);
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }

        // DELETE
        [HttpDelete]
        public ViewResult DeleteStudentById(int id)
        {
            foreach (Student st in Students)
            {
                if (st.Id == id)
                {
                    Students.Remove(st);
                    return View(st);
                }
            }
            throw new Exception("No student found for id " + id.ToString() + ".");
        }
    }
}
