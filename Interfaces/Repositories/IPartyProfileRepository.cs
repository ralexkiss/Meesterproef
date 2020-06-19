using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user repository.
    /// </summary>
    public interface IPartyProfileRepository
    {
        void Save(int id, PartyProfileDTO partyProfileDTO); 
    }
}