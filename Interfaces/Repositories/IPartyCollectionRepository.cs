using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user repository.
    /// </summary>
    public interface IPartyCollectionRepository
    {
        List<PartyDTO> Search(string searchQuery);
        void CreateParty(PartyDTO party);
        PartyDTO GetPartyByID(int id);
        List<PartyDTO> GetPartyHistory(PartyDTO party);
        List<PartyDTO> GetAllParties();
        PartyDTO GetOldPartyByID(int id);
    }
}