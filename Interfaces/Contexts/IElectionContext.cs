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
    }
}