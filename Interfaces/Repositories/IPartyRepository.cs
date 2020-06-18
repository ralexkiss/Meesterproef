﻿using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user repository.
    /// </summary>
    public interface IPartyRepository
    {
        void Save(PartyDTO party);

        List<PartyDTO> GetPartyHistory(PartyDTO party);
    }
}