using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions.Election;
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
    }
}