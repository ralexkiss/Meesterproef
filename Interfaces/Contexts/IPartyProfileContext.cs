using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IPartyProfileContext
    {
        void Save(int id, PartyProfileDTO partyProfileDTO);
    }
}