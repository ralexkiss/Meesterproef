using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.DTO
{
    public class PartyProfileDTO
    {
        public int ID { get; set; }
        public int Votes { get; set; }
        public int Seats { get; set; }
        public PartyDTO Party { get; set; }
    }
}
