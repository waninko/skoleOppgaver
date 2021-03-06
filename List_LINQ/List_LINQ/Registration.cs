﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_LINQ
{
    class Registration
    {
        public int StartNr { get; private set; }
        public string Name { get; private set; }
        public string Club { get; private set; }
        public string Nationality { get; private set; }
        public string Group { get; private set; }
        public string Class { get; private set; }

        public Registration( string csvLine)
        {
           var splitLine = csvLine.Split(',');

            StartNr = Convert.ToInt32("0" + splitLine[0].Trim('"')); //fjernet " så ikke det klikker
            Name = splitLine[1];
            Club = splitLine[2];
            Nationality = splitLine[3];
            Group = splitLine[4];
            Class = splitLine[5];
        }

        public Registration(int startNr, string name, string club, string nationality, string @group, string @class)
        {
            StartNr = startNr;
            Name = name;
            Club = club;
            Nationality = nationality;
            Group = @group;
            Class = @class;
        }

        public string MakeString()
        {
            return StartNr + " " + Name + " " + Nationality + " " + Group + " " + Class;
        }
    }
}
