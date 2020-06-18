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

        public ElectionController()
        {
            electionCollection = new ElectionCollection();
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
            ViewBag.Election = election;
            return View();
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
    }
}