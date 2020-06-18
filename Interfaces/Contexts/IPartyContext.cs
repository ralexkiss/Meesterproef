using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IPartyContext
    {
        List<PartyDTO> Search(string searchQuery);
        void CreateParty(PartyDTO party);
        PartyDTO GetPartyByID(int id);
        PartyDTO GetOldPartyByID(int id);
        void Save(PartyDTO party);
        List<PartyDTO> GetPartyHistory(PartyDTO party);
        List<PartyDTO> GetAllParties();
    }
}