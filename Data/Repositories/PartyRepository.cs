using System.Collections.Generic;
using Interfaces.Contexts;
using Interfaces.DTO;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class PartyRepository : IPartyRepository, IPartyCollectionRepository
    {
        private readonly IPartyContext Context;

        public PartyRepository(IPartyContext context)
        {
            Context = context;
        }

        public List<PartyDTO> Search(string searchQuery)
        {
            return Context.Search(searchQuery);
        }

        public void CreateParty(PartyDTO party)
        {
            Context.CreateParty(party);
        }


        public List<PartyDTO> GetPartyHistory(PartyDTO party)
        {
            return Context.GetPartyHistory(party);
        }

        public List<PartyDTO> GetAllParties()
        {
            return Context.GetAllParties();
        }

        public PartyDTO GetPartyByID(int id)
        {
            return Context.GetPartyByID(id);        
        }

        public void Save(PartyDTO party)
        {
            Context.Save(party);
        }

        public PartyDTO GetOldPartyByID(int id)
        {
            return Context.GetOldPartyByID(id);
        }
    }
}