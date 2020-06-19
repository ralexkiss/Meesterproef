using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PartyProfile
    {
        private IPartyProfileRepository partyProfileRepository = RepositoryFactory.GetPartyProfileRepository();

        public int ID { get; set; }
        public int Votes { get; set; }
        public int Seats { get; set; }
        public Party Party { get; set; }

        public void Save(int id, PartyProfile partyProfile)
        {
            partyProfileRepository.Save(id, DTOConvertor.GetPartyProfileDTO(this));
        }
    }
}
