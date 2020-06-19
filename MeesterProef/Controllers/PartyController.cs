using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions.Party;
using Interfaces.Contexts;
using Logic;
using Logic.Collections;
using Meesterproef.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Meesterproef.Controllers
{
    public class PartyController : Controller
    {
        private readonly PartyCollection partyCollection;

        public PartyController()
        {
            partyCollection = new PartyCollection();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Parties = partyCollection.GetAllParties();
            return View();
        }

        public IActionResult Info(int id)
        {
            Party party = partyCollection.GetPartyByID(id);
            if (party == null)
            {
                return RedirectToAction("Index", "Party");
            }
            ViewBag.Party = party;
            return View();
        }

        [HttpGet]
        public IActionResult Search(int electionid)
        {
            ViewBag.Parties = new List<Party>();
            ViewBag.ElectionID = electionid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PartyViewModel model)
        {
            Party party = partyCollection.GetPartyByID(id);
            ViewBag.Party = party; ;
            if (ModelState.IsValid)
            {
                try
                {
                    party.Abbreviation = model.Abbreviation;
                    party.Name = model.Name;
                    party.Leader = model.Leader;
                    party.Save();
                    return RedirectToAction("Index", "Party");
                }
                catch (UpdatingPartyFailedException)
                {
                    ModelState.AddModelError("", "Editing Party failed, Try again.");
                    return RedirectToAction("Index", "Party");
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(PartyViewModel party)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Party newParty = new Party
                {
                    Abbreviation = party.Abbreviation,
                    Name = party.Name,
                    Leader = party.Leader
                };

                partyCollection.CreateParty(newParty);
                return RedirectToAction("Index", "Party");
            }
            catch (CreatingPartyFailedException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult Search(int electionid, SearchViewModel search)
        {
            ViewBag.ElectionID = electionid;
            if (!ModelState.IsValid)
            {
                ViewBag.Parties = new List<Party>();
                return View();
            }

            try
            {
                List<Party> parties = partyCollection.Search(search.Query);
                if (!parties.Any())
                {
                    ModelState.AddModelError("", "No parties were found.");
                }
                ViewBag.Parties = parties;
                return View();
            }
            catch (SearchFailedException)
            {
                ViewBag.Parties = new List<Party>();
                ModelState.AddModelError("", "No parties were found.");
                return View();
            }
        }
    }
}