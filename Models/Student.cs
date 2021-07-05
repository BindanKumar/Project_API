using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API.Models
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string[] Course { get; set; }
    }
}
