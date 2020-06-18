using System.Collections.Generic;
using Interfaces.Contexts;
using Interfaces.DTO;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class ElectionRepository : IElectionCollectionRepository
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
    }
}