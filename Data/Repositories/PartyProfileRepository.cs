using System.Collections.Generic;
using Interfaces.Contexts;
using Interfaces.DTO;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class PartyProfileRepository : IPartyProfileRepository
    {
        private readonly IPartyProfileContext Context;

        public PartyProfileRepository(IPartyProfileContext context)
        {
            Context = context;
        }
        public void Save(int id, PartyProfileDTO partyProfile)
        {
            Context.Save(id, partyProfile);
        }
    }
}