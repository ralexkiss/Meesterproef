using Exceptions.Election;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Collections
{
    public class ElectionCollection
    {
        private IElectionCollectionRepository electionRepository = RepositoryFactory.GetElectionCollectionRepository();
        public void CreateElection(Election election)
        {
            electionRepository.CreateElection(DTOConvertor.GetElectionDTO(election));
        }

        public Election GetElectionByID(int id)
        {
            Election election = DTOConvertor.GetElectionFromDTO(electionRepository.GetElectionByID(id));
            election.PartyProfiles = DTOConvertor.GetPartyProfilesFromDTO(electionRepository.GetAllPartyProfiles(DTOConvertor.GetElectionDTO(election)));
            return election;
        }

        public List<Election> GetAllElections()
        {
            return DTOConvertor.GetElectionList(electionRepository.GetAllElections());
        }

        public void CreatePartyProfile(int id, PartyProfile partyProfile)
        {
            electionRepository.CreatePartyProfile(id, DTOConvertor.GetPartyProfileDTO(partyProfile));
        }
    }
}
