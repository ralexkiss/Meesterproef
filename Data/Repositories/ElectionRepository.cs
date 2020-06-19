using System.Collections.Generic;
using Interfaces.Contexts;
using Interfaces.DTO;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class ElectionRepository : IElectionCollectionRepository, IElectionRepository
    {
        private readonly IElectionContext Context;

        public ElectionRepository(IElectionContext context)
        {
            Context = context;
        }

        public ElectionDTO GetElectionByID(int id)
        {
            return Context.GetElectionByID(id);
        }

        public void CreateElection(ElectionDTO election)
        {
            Context.CreateElection(election);
        }

        public List<ElectionDTO> GetAllElections()
        {
            return Context.GetAllElections();
        }

        public List<PartyProfileDTO> GetAllPartyProfiles(ElectionDTO election)
        {
            return Context.GetAllPartyProfiles(election);
        }

        public void Save(ElectionDTO election)
        {
            Context.Save(election);
        }

        public void CreateCoalition(CoalitionDTO coalition)
        {
            Context.CreateCoalition(coalition);
        }

        public void CreatePartyProfile(int id, PartyProfileDTO partyProfile)
        {
            Context.CreatePartyProfile(id, partyProfile);
        }
    }
}