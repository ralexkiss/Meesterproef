using Data.Repositories;
using Exceptions.Election;
using Exceptions.PartyProfile;
using Interfaces.Contexts;
using Interfaces.DTO;
using Interfaces.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Contexts
{
    public class ElectionSqlContext : IElectionContext
    {
        private MySqlConnection connection;
        IPartyCollectionRepository partyRepository = new PartyRepository(new PartySqlContext());

        public ElectionDTO GetElectionByID(int id)
        {
            try
            {
                ElectionDTO election = new ElectionDTO();
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM Election WHERE ID=@ElectionID", connection))
                    {
                        command.Parameters.AddWithValue("@ElectionID", id);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                election.ID = (int)reader["ID"];
                                election.Name = (string)reader["Name"];
                                election.DistributableSeats = (int)reader["DistributableSeats"];
                                election.Date = (DateTime)reader["Date"];
                            }
                            return election;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw new GetElectionByIDFailedException("We konden de door u verzochte verkiezing niet vinden.");
            }
        }

        public void Save(ElectionDTO election)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UPDATE Election SET Name=@Name, DistributableSeats=@DistributableSeats, Date=@Date WHERE ID=@ElectionID", connection))
                    {
                        command.Parameters.AddWithValue("@ElectionID", election.ID);
                        command.Parameters.AddWithValue("@Name", election.Name);
                        command.Parameters.AddWithValue("@DistributableSeats", election.DistributableSeats);
                        command.Parameters.AddWithValue("@Date", election.Date);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new UpdatingElectionFailedException("Opslaan verkiezing is mislukt.");
            }
        }

        public void CreatePartyProfile(int id, PartyProfileDTO partyProfile)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO PartyProfile(PartyID, ElectionID, Votes, Seats) VALUES (@PartyID, @ElectionID, @Votes, @Seats)", connection))
                    {
                        command.Parameters.AddWithValue("@ElectionID", id);
                        command.Parameters.AddWithValue("@PartyID", partyProfile.Party.ID);
                        command.Parameters.AddWithValue("@Votes", partyProfile.Votes);
                        command.Parameters.AddWithValue("@Seats", partyProfile.Seats);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new CreatingPartyProfileFailedException("Het maken van een profiel voor de gegeven partij is mislukt.");
            }
        }

        public void CreateElection(ElectionDTO election)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO Election(Name, DistributableSeats, Date) VALUES (@Name, @DistributableSeats, @Date)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", election.Name);
                        command.Parameters.AddWithValue("@DistributableSeats", election.DistributableSeats);
                        command.Parameters.AddWithValue("@Date", election.Date);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new CreatingElectionFailedException("De door u ingevoerde verkiezing kan niet worden aangemaakt.");
            }
        }

        public List<ElectionDTO> GetAllElections()
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM Election", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<ElectionDTO> elections = new List<ElectionDTO>();
                    while (reader.Read())
                    {
                        elections.Add(new ElectionDTO()
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            DistributableSeats = (int)reader["DistributableSeats"],
                            Date = (DateTime)reader["Date"],
                        });
                    }
                    return elections;
                }
            }
            catch (MySqlException)
            {
                throw new Exceptions.Election.SearchFailedException("Het ophalen van alle verkiezingen is mislukt.");
            }
        }

        public List<PartyProfileDTO> GetAllPartyProfiles(ElectionDTO election)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM PartyProfile WHERE ElectionID=@ElectionID", connection);
                    command.Parameters.AddWithValue("@ElectionID", election.ID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<PartyProfileDTO> partyProfileDTOs = new List<PartyProfileDTO>();
                    while (reader.Read())
                    {
                        partyProfileDTOs.Add(new PartyProfileDTO()
                        {
                            ID = (int)reader["ID"],
                            Votes = (int)reader["Votes"],
                            Seats = (int)reader["Seats"],
                            Party = partyRepository.GetPartyByID((int)reader["PartyID"])
                        });
                    }
                    return partyProfileDTOs;
                }
            }
            catch (MySqlException)
            {
                throw new Exceptions.PartyProfile.SearchFailedException("Het ophalen van alle partij profielen is mislukt.");
            }
        }

        public void CreateCoalition(CoalitionDTO coalition)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO Coalition(ElectionID, PrimeMinister) VALUES (@ElectionID, @PrimeMinister)", connection))
                    {
                        command.Parameters.AddWithValue("@ElectionID", coalition.election.ID);
                        command.Parameters.AddWithValue("@PrimeMinister", coalition.PrimeMinister);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new CreatingElectionFailedException("Coalitie maken mislukt.");
            }
        }
    }
}