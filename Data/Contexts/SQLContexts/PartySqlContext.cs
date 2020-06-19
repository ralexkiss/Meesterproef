using Exceptions.Party;
using Interfaces.Contexts;
using Interfaces.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Contexts
{
    public class PartySqlContext : IPartyContext
    {
        private MySqlConnection connection;

        public PartyDTO GetPartyByID(int id)
        {
            try
            {
                PartyDTO party = new PartyDTO();
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM Party WHERE ID=@PartyID", connection))
                    {
                        command.Parameters.AddWithValue("@PartyID", id);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                party.ID = (int)reader["ID"];
                                party.Abbreviation = (string)reader["Abbreviation"];
                                party.Name = (string)reader["Name"];
                                party.Leader = (string)reader["Leader"];
                            }
                            return party;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw new GetPartyByIDFailedException("We konden de door u verzochte partij niet vinden.");
            }
        }

        public List<PartyDTO> Search(string searchQuery)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM Party WHERE Abbreviation LIKE '{searchQuery}%'", connection);
                    command.Parameters.AddWithValue("@SearchQuery", searchQuery);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<PartyDTO> parties = new List<PartyDTO>();
                    while (reader.Read())
                    {
                        parties.Add(new PartyDTO()
                        {
                            ID = (int)reader["ID"],
                            Abbreviation = (string)reader["Abbreviation"],
                            Name = (string)reader["Name"],
                            Leader = (string)reader["Leader"]

                        });
                    }
                    return parties;
                }
            }
            catch (MySqlException)
            {
                throw new SearchFailedException("We konden de door u verzochte partij niet vinden.");
            }
        }

        public void CreateParty(PartyDTO party)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO Party(Abbreviation, Name, Leader) VALUES (@Abbreviation, @Name, @Leader)", connection))
                    {
                        command.Parameters.AddWithValue("@Abbreviation", party.Abbreviation);
                        command.Parameters.AddWithValue("@Name", party.Name);
                        command.Parameters.AddWithValue("@Leader", party.Leader);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new CreatingPartyFailedException("We konden de door u ingevulde partij niet aanmaken.");
            }
        }

        public void Save(PartyDTO party)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UPDATE Party SET Name=@Name, Leader=@Leader, Abbreviation=@Abbreviation WHERE ID=@PartyID", connection))
                    {
                        command.Parameters.AddWithValue("@PartyID", party.ID);
                        command.Parameters.AddWithValue("@Name", party.Name);
                        command.Parameters.AddWithValue("@Leader", party.Leader);
                        command.Parameters.AddWithValue("@Abbreviation", party.Abbreviation);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new UpdatingPartyFailedException("Het opslaan van de partij is mislukt.");
            }
        }

        public List<PartyDTO> GetPartyHistory(PartyDTO party)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM OldParty WHERE PartyID=PartyID", connection);
                    command.Parameters.AddWithValue("@PartyID", party.ID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<PartyDTO> parties = new List<PartyDTO>();
                    while (reader.Read())
                    {
                        parties.Add(new PartyDTO()
                        {
                            ID = (int)reader["ID"],
                            Abbreviation = (string)reader["Abbreviation"],
                            Name = (string)reader["Name"],
                            Leader = (string)reader["Leader"]
                        });
                    }
                    return parties;
                }
            }
            catch (MySqlException)
            {
                throw new SearchFailedException("");
            }
        }

        public PartyDTO GetOldPartyByID(int id)
        {
            try
            {
                PartyDTO party = new PartyDTO();
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM OldParty WHERE ID=@ID", connection))
                    {
                        command.Parameters.AddWithValue("@PartyID", id);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                party.ID = (int)reader["PartyID"];
                                party.Abbreviation = (string)reader["Abbreviation"];
                                party.Name = (string)reader["Name"];
                                party.Leader = (string)reader["Leader"];
                            }
                            return party;
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                throw new GetPartyByIDFailedException();
            }
        }


        public List<PartyDTO> GetAllParties()
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM Party", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<PartyDTO> parties = new List<PartyDTO>();
                    while (reader.Read())
                    {
                        parties.Add(new PartyDTO()
                        {
                            ID = (int)reader["ID"],
                            Abbreviation = (string)reader["Abbreviation"],
                            Name = (string)reader["Name"],
                            Leader = (string)reader["Leader"]
                        });
                    }
                    return parties;
                }
            }
            catch (MySqlException)
            {
                throw new SearchFailedException("Het ophalen van alle partijen is mislukt.");
            }
        }
    }
}