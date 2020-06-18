using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.DTO
{
    public class ElectionDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DistributableSeats { get; set; }
        public DateTime Date { get; set; }
        public List<PartyProfileDTO> partyProfiles { get; set; }
    }
}
