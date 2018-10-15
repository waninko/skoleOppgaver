using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class classes //antall påmeldte per klasse
    {
        public string Name { get; private set; }
        public string ClubName { get; private set; }
        public List<Registration> Registrations { get; private set; }

        public classes(string name, /*ClubName,*/ List<Registration> registrations)
        {
            Name = name;
            Registrations = new List<Registration>();
        }


    }
}
