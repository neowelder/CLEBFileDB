using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEBFileDB
{
    class Person
    {
        public String name;
        public String lastname;
        public String address;
        public String phone;
        public String mail;
    }

    class Persons {
        public static List<Person> person;
        public static void initialize()
        {
            person = new List<Person>();
        }
    }
}
