using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IElectionContext
    {
        void CreateElection(ElectionDTO election);
        ElectionDTO GetElectionByID(int id);
        List<PartyProfileDTO> GetAllPartyProfiles(ElectionDTO election);
        List<ElectionDTO> GetAllElections();
        void Save(ElectionDTO election);
        void CreateCoalition(CoalitionDTO coalition);
        void CreatePartyProfile(int id, PartyProfileDTO partyProfile);
    }
}