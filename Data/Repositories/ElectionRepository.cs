using System.Collections.Generic;
using Exceptions.Election;
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
            if (election.Date == null || election.Name == null || election.DistributableSeats <= 0)
            {
                throw new CreatingElectionFailedException("Niet alle benodigde gegevens zijn ingevuld.");
            }
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