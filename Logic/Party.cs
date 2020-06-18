using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Party
    {
        private IPartyRepository partyRepository = RepositoryFactory.GetPartyRepository();

        public int ID { get; set; }

        public string Abbreviation { get; set; }

        public string Name { get; set; }
        public string Leader { get; set; }
        public List<Party> History { get; set; }

        public void Save()
        {
            partyRepository.Save(DTOConvertor.GetPartyDTO(this));
        }
    }
}
