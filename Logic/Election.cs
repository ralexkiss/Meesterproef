using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Election
    {
        private IElectionRepository electionRepository = RepositoryFactory.GetElectionRepository();

        public int ID { get; set; }
        public string Name { get; set; }
        public int DistributableSeats { get; set; }
        public DateTime Date { get; set; }
        public List<PartyProfile> PartyProfiles { get; set; }

        public void CreateCoalition(Coalition coalition)
        {

        }
    }
}
