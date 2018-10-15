using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class person 
    {
        public string Name { get; private set; }
        public List<Registration> Registrations { get; private set; }

        public person(string name, List<Registration> registrations)
        {
            Name = name;
            Registrations = new List<Registration>();
        }

        public void Add(Registration registration)
        {
            Registrations.Add(registration);
        }
    }
}
