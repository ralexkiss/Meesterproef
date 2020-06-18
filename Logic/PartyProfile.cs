using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PartyProfile
    {
        public int ID { get; set; }
        public int Votes { get; set; }
        public int Seats { get; set; }
        public Party Party { get; set; }
    }
}
