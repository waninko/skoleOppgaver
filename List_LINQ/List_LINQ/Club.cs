using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class Club
    {
        public string Name { get; private set; }
        public  List<Registration> Registrations { get; private set; }

    public Club(string name)
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
