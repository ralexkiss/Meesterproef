using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user repository.
    /// </summary>
    public interface IElectionCollectionRepository
    {
        void CreateElection(ElectionDTO election);
        ElectionDTO GetElectionByID(int id);
        List<PartyProfileDTO> GetAllPartyProfiles(ElectionDTO election);
        List<ElectionDTO> GetAllElections();
        void CreatePartyProfile(int id, PartyProfileDTO partyProfile);
    }
}