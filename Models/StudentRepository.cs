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
        private static int studentID = 1;

        public StudentRepository()
        {
            
        }
        public void Add(Student student)
        {
            student.ID = studentID.ToString();
            studentID++;
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
            return students.Values;
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
