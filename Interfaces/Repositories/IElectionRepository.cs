using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user repository.
    /// </summary>
    public interface IElectionRepository
    {
        void Save(ElectionDTO election);

        void CreateCoalition(CoalitionDTO coalition);
    }
}