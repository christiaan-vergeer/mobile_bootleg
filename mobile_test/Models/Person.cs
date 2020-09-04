using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_test.Models
{
    public class Person
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public Gender gender { get; set; }
        public Prefference prefference { get; set; }
    }
}
