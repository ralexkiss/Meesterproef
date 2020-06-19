using Exceptions.Election;
using Interfaces.Repositories;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private readonly IElectionCollectionRepository electionRepository = RepositoryFactory.GetElectionCollectionRepository();
        private readonly IPartyCollectionRepository partyRepository = RepositoryFactory.GetPartyCollectionRepository();

        #region Positive Unit / Integration Tests
        #endregion

        [TestMethod]
        public void CreateParty()
        {
            Party party = new Party
            {
                Abbreviation = "PP",
                Name = "Piraten partij",
                Leader = "Ancilla Tilia"
            };

            partyRepository.CreateParty(DTOConvertor.GetPartyDTO(party));
            Assert.IsTrue(partyRepository.GetAllParties().Any());
        }

        [TestMethod]
        public void CreateElection()
        {
            Election election = new Election
            {
                Name = "Tweede Kamerverkiezingen 2017",
                DistributableSeats = 150,
                Date = DateTime.Now,
                PartyProfiles = new List<PartyProfile>()
            };
            electionRepository.CreateElection(DTOConvertor.GetElectionDTO(election));
            Assert.IsTrue(electionRepository.GetAllElections().Any());
        }

        #region Negative Unit / Integration Tests

        /// <summary>
        /// Testcase: IVU_1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CreatingElectionFailedException))]
        public void CreateInvalidInfoElection()
        {
            Election election = new Election
            {
                Name = "Tweede Kamerverkiezingen 2019",
                DistributableSeats = 150,
                PartyProfiles = new List<PartyProfile>()
            };
            electionRepository.CreateElection(DTOConvertor.GetElectionDTO(election));
        }

        /// <summary>
        /// Testcase: IVU_1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CreatingElectionFailedException))]
        public void CreateSameNameElection()
        {
            Election election = new Election
            {
                Name = "Tweede Kamerverkiezingen 2017",
                DistributableSeats = 150,
                Date = DateTime.Now,
                PartyProfiles = new List<PartyProfile>()
            };
            electionRepository.CreateElection(DTOConvertor.GetElectionDTO(election));
        }

        #endregion
    }
}
