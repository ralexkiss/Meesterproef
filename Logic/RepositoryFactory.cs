using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories;
using Data.Contexts;

namespace Logic
{
    public class RepositoryFactory
    {
        public static IPartyCollectionRepository GetPartyCollectionRepository()
        {
            IPartyCollectionRepository partyRepository = new PartyRepository(new PartySqlContext());
            return partyRepository;
        }

        public static IPartyRepository GetPartyRepository()
        {
            IPartyRepository partyRepository = new PartyRepository(new PartySqlContext());
            return partyRepository;
        }

        public static IElectionCollectionRepository GetElectionCollectionRepository()
        {
            IElectionCollectionRepository electionCollectionRepository = new ElectionRepository(new ElectionSqlContext());
            return electionCollectionRepository;
        }
    }
}
