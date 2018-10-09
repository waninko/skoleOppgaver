using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeOppgave
{
    class Bottle
    {
        public int Capacity { get; }
        public int Content {get; private set; }

        public Bottle(int capacity) //dette er en flaske.
        {
            Capacity = capacity;
        }

        public bool Fill(int volume) //fikk man fylt? er det plass?
        {
            if (volume + Content > Capacity) return false;
            else Content += volume;
            return true;
        }

        public void FillUpFromTap() 
        {
            Content = Capacity; 
        }

        public bool FillUp(Bottle anotherBottle) //fyll HELT opp
        {
           var volumeNeeded = Capacity - Content;
            if (anotherBottle.Content < volumeNeeded) return false;
            Content = Capacity;
            Remove(volumeNeeded);
            return true;
        }

        private void Remove(int volumeNeeded)
        {
            Content -= volumeNeeded;
        }


        public int Empty() //tøm denne 
        {
            var content = Content;
            Content = 0;
            return content;
        }

        public bool IsEmpty() //denne er tom
        {
            return Content == 0;
        } 



    }
}
