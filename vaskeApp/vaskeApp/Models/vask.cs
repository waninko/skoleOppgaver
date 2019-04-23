using System;

namespace vaskeApp.Models
{
    public class Vask
    {
        public long vaskID { get; set; }
        public string leilighetsNR { get; set; }
        public DateTime vaskStart  { get; set; }  
        public int varighet { get; set; } //TimeSpan , TimeStamp Attribute?
    }
}
