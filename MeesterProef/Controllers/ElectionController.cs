using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions.Election;
using Interfaces.Contexts;
using Logic;
using Logic.Collections;
using Meesterproef.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Meesterproef.Controllers
{
    public class ElectionController : Controller
    {
        private readonly ElectionCollection electionCollection;
        private readonly PartyCollection partyCollection;

        public ElectionController()
        {
            electionCollection = new ElectionCollection();
            partyCollection = new PartyCollection();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Elections = electionCollection.GetAllElections();
            return View();
        }

        public IActionResult Info(int id)
        {
            Election election = electionCollection.GetElectionByID(id);
            if (election == null)
            {
                return RedirectToAction("Index", "Election");
            }
            CalculateSeats(election);
            ViewBag.Election = election;
            return View();
        }


        [HttpGet]
        public IActionResult AddResult(int electionid, int partyid)
        {
            ViewBag.Election = electionCollection.GetElectionByID(electionid);
            ViewBag.Party = partyCollection.GetPartyByID(partyid);
            return View();
        }

        [HttpPost]
        public IActionResult AddResult(int electionid, int partyid, PartyProfileViewModel partyProfile)
        {
            Election election = electionCollection.GetElectionByID(electionid);
            Party party = partyCollection.GetPartyByID(partyid);
            ViewBag.Election = election;
            ViewBag.Party = party;

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                PartyProfile newPartyProfile = new PartyProfile
                {
                    Votes = partyProfile.Votes,
                    Party = party
                };
                election.PartyProfiles.Add(newPartyProfile);
                newPartyProfile.Seats = CalculateSeatsForPartyProfile(election, newPartyProfile);
                electionCollection.CreatePartyProfile(election.ID, newPartyProfile);
                return RedirectToAction("Info", "Election", new { id = election.ID });
            }
            catch (CreatingElectionFailedException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(ElectionViewModel election)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Election newElection = new Election
                {
                    Name = election.Name,
                    DistributableSeats = election.DistributableSeats,
                    Date = election.Date,
                    PartyProfiles = new List<PartyProfile>()

                };

                electionCollection.CreateElection(newElection);
                return RedirectToAction("Index", "Election");
            }
            catch (CreatingElectionFailedException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View();
            }
        }

        private void CalculateSeats(Election election)
        {
            if (election.PartyProfiles.Any())
            {
                int AllSeats = 0;
                foreach (PartyProfile partyProfile in election.PartyProfiles)
                {
                    int CalculatedSeats = CalculateSeatsForPartyProfile(election, partyProfile);

                    AllSeats = AllSeats + CalculatedSeats;

                    if (AllSeats > election.DistributableSeats)
                    {
                        CalculatedSeats = CalculatedSeats - (AllSeats - election.DistributableSeats);
                    }
                    partyProfile.Seats = CalculatedSeats;
                    partyProfile.Save(election.ID, partyProfile);
                }
            }
        }

        private int CalculateSeatsForPartyProfile(Election election, PartyProfile partyProfile)
        {
            decimal totalVotes = election.PartyProfiles.Sum(party => party.Votes);
            decimal votes = partyProfile.Votes / totalVotes;
            return (int)decimal.Round(votes * election.DistributableSeats);
        }
    }
}   