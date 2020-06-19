using Exceptions.PartyProfile;
using Interfaces.Contexts;
using Interfaces.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Contexts
{
    public class PartyProfileSqlContext : IPartyProfileContext
    {
        private MySqlConnection connection;
        public void Save(int id, PartyProfileDTO partyProfile)
        {
            try
            {
                using (connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UPDATE PartyProfile SET Votes=@Votes, Seats=@Seats WHERE ElectionID=@ElectionID AND PartyID=@PartyID", connection))
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
                throw new UpdatingPartyProfileFailedException("We konden de door u verzochte partij profiel niet vinden.");
            }
        }
    }
}