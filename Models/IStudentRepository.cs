using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API.Models
{
    public interface IStudentRepository
    {
        void Add(Student student);
        IEnumerable<Student> GetAll();
        Student Find(string id);
        Student Remove(string id);
        void Update(Student item);
    }
}
