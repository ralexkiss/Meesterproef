using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Collections
{
    public class PartyCollection
    {
        private IPartyCollectionRepository partyRepository = RepositoryFactory.GetPartyCollectionRepository();

        public void CreateParty(Party party)
        {
            partyRepository.CreateParty(DTOConvertor.GetPartyDTO(party));
        }

        public Party GetPartyByID(int id)
        {
            Party party = DTOConvertor.GetPartyFromDTO(partyRepository.GetPartyByID(id));
            party.History = DTOConvertor.GetPartyList(partyRepository.GetPartyHistory(DTOConvertor.GetPartyDTO(party)));
            return party;
        }

        public List<Party> GetAllParties()
        {
            List<Party> parties = DTOConvertor.GetPartyList(partyRepository.GetAllParties());
            foreach (Party party in parties)
            {
                party.History = DTOConvertor.GetPartyList(partyRepository.GetPartyHistory(DTOConvertor.GetPartyDTO(party)));
            }
            return parties;
        }
    }
}
