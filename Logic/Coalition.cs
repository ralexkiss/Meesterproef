using System;
using System.Collections.Generic;

namespace Logic
{
    public class Coalition
    {
        public int ID { get; set; }

        public Election election { get; set; }
        public string PrimeMinister { get; set; }
        public List<PartyProfile> PartyProfiles { get; set; }

        public void Export()
        {
            throw new NotImplementedException();
        }
    }
}