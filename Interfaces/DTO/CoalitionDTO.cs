using System.Collections.Generic;

namespace Interfaces.DTO
{
    public class CoalitionDTO
    {
        public int ID { get; set; }

        public ElectionDTO election { get; set; }
        public string PrimeMinister { get; set; }
        public List<PartyProfileDTO> PartyProfiles { get; set; }
    }
}