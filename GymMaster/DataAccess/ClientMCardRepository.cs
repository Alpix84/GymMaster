using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using GymMaster.Models;
using GymMaster.ViewModels;

namespace GymMaster.DataAccess;

public class ClientMCardRepository
{
    private readonly string _connectionString;
    private List<ClientMCards> clientMCardList;

    public ClientMCardRepository()
    {
        _connectionString = Constants.ConnectionString;
        clientMCardList = ClientMCardsList();
    }

    public List<ClientMCards> GetClientMCardsList()
    {
        return clientMCardList = ClientMCardsList();
    }

    private List<ClientMCards> ClientMCardsList()
    {
        var clientMCards = new List<ClientMCards>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM clientMCards";
            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["clientMCard_id"];
                    var clientId = (int)reader["client_id"];
                    var membershipId = (int)reader["membership_id"];
                    var boughtOnDate = reader.IsDBNull(reader.GetOrdinal("boughtOnDate")) ? null : (DateTime?)reader["boughtOnDate"];
                    var barcode = reader["barcode"].ToString();
                    var currentEntries = (int)reader["currentEntries"];
                    var priceSold = (float)reader["priceSold"];
                    var validUntil = reader.IsDBNull(reader.GetOrdinal("validUntil")) ? null : (DateTime?)reader["validUntil"];
                    var firstEntry = reader.IsDBNull(reader.GetOrdinal("firstEntry")) ? null : (DateTime?)reader["firstEntry"];
                    var gymId = (int)reader["gym_id"];

                    var clientMC = new ClientMCards(id,clientId,membershipId,boughtOnDate,barcode,currentEntries,priceSold,validUntil,firstEntry,gymId); 
                    clientMCards.Add(clientMC);
                }
            }
        }
        return clientMCards;
    }
    

    public void AddCardToClient(Client client,int membershipCardID,float priceSold,DateTime validUntil)
    {
        
    }
    
}