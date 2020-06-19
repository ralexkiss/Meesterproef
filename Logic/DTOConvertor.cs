using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DTOConvertor
    {
        public static PartyProfileDTO GetPartyProfileDTO(PartyProfile party)
        {
            PartyProfileDTO dto = new PartyProfileDTO
            {
                ID = party.ID,
                Votes = party.Votes,
                Seats = party.Seats,
                Party = GetPartyDTO(party.Party)
            };
            return dto;
        }

        public static PartyProfile GetPartyProfileFromDTO(PartyProfileDTO dto)
        {
            PartyProfile party = new PartyProfile
            {
                ID = dto.ID,
                Votes = dto.Votes,
                Seats = dto.Seats,
                Party = GetPartyFromDTO(dto.Party)
            };
            return party;
        }

        public static List<PartyProfile> GetPartyProfilesFromDTO(List<PartyProfileDTO> list)
        {
            List<PartyProfile> parties = new List<PartyProfile>();
            foreach (PartyProfileDTO partyProfileDTO in list)
            {
                parties.Add(GetPartyProfileFromDTO(partyProfileDTO));
            }
            return parties;
        }

        public static PartyDTO GetPartyDTO(Party party)
        {
            PartyDTO dto = new PartyDTO
            {
                ID = party.ID,
                Abbreviation = party.Abbreviation,
                Name = party.Name,
                Leader = party.Leader

            };
            return dto;
        }

        public static Party GetPartyFromDTO(PartyDTO dto)
        {
            Party party = new Party
            {
                ID = dto.ID,
                Abbreviation = dto.Abbreviation,
                Name = dto.Name,
                Leader = dto.Leader

            };
            return party;
        }

        public static List<Party> GetPartyList(List<PartyDTO> list)
        {
            List<Party> parties = new List<Party>();
            foreach (PartyDTO Partydto in list)
            {
                parties.Add(GetPartyFromDTO(Partydto));
            }
            return parties;
        }


        public static ElectionDTO GetElectionDTO(Election election)
        {
            ElectionDTO dto = new ElectionDTO
            {
                ID = election.ID,
                Name = election.Name,
                DistributableSeats = election.DistributableSeats,
                Date = election.Date

            };
            return dto;
        }

        public static Election GetElectionFromDTO(ElectionDTO dto)
        {
            Election election = new Election
            {
                ID = dto.ID,
                Name = dto.Name,
                DistributableSeats = dto.DistributableSeats,
                Date = dto.Date

            };
            return election;
        }

        public static List<Election> GetElectionList(List<ElectionDTO> list)
        {
            List<Election> elections = new List<Election>();
            foreach (ElectionDTO electionDTO in list)
            {
                elections.Add(GetElectionFromDTO(electionDTO));
            }
            return elections;
        }
    }
}
