using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API.Models
{
    public class StudentRepository:IStudentRepository
    {
        private static ConcurrentDictionary<string, Student> students = new ConcurrentDictionary<string, Student>();
        //private static int studentID = 0;

        public StudentRepository()
        {
            //Creating 10 dummy records.
            for(int i=1;i<10;i++)
            {
                var student = new Student { ID = i.ToString(), Name = "student" + i.ToString(), Email = "student" + i.ToString() +"@gmail.com", PhoneNumber = "789456123" + i.ToString(), Course = new string[2] { "Java", "C#" } };
                students[i.ToString()] = student;

            }
        }
        public void Add(Student student)
        {
            student.ID = (students.Count() + 1).ToString();
            students[student.ID] = student;
        }

        public Student Find(string id)
        {
            Student item;
            students.TryGetValue(id, out item);
            return item;
        }

        public IEnumerable<Student> GetAll()
        {
            var ordered = students.OrderBy(x => x.Value.ID).ToDictionary(x => x.Key, x => x.Value);
            return ordered.Values;
        }

        public Student Remove(string id)
        {
            Student item;
            students.TryGetValue(id, out item);
            students.TryRemove(id, out item);
            return item;
        }

        public void Update(Student student)
        {
            students[student.ID] = student;
        }
    }
}
