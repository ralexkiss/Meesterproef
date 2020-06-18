﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Election
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DistributableSeats { get; set; }
        public DateTime Date { get; set; }
        public List<PartyProfile> PartyProfiles { get; set; }
    }
}