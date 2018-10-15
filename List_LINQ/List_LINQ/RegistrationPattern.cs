using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class RegistrationPattern
    {
       public List<Registration> Registrations { get; private set; }
       public List<Club> Clubs { get; private set; }

        public RegistrationPattern() //constructor som ligger inn verdiene som er "festet til" registration/clubs i de respektive listene sine.
        {
            Registrations = new List<Registration>();
            Clubs = new List<Club>();
        }


        public void lineHandler(string line) //henter inn en og en linje i teksten og sender de til registration (hvor den splittes) og legges i lista.
        {
            var registration = new Registration(line);
            Registrations.Add(registration);

            var club = Clubs.FirstOrDefault(c => c.Name == registration.Club);
            if (club ==  null)
            {
                club = new Club(registration.Club);
                Clubs.Add(club);
            }
             club.Add(registration);
            
            var name
        }
    }
}
