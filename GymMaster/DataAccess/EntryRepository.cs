using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class EntryRepository
{
    private readonly string _connectionString;

    public EntryRepository()
    {
        _connectionString = Constants.ConnectionString;
    }

    public List<Entry> GetEntriesList()
    {
        return EntriesList();
    }

    public void AddNewEntry(int clientId,int membershipCardId,int adminId,string newBarcode,int gymId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = $"INSERT INTO entries(client_id, membership_id, entryDate,insertedBy_id, barcode, gym_id) VALUES ({clientId}, {membershipCardId}, '{DateTime.Today:yyyy-MM-dd}', {adminId},'{newBarcode}',{gymId})";
            var command = new SqlCommand(query, connection);
            
            command.ExecuteNonQuery();
        }
    }

    private List<Entry> EntriesList()
    {
        var entries = new List<Entry>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM entries";
            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["entry_id"];
                    var clientId = (int)reader["client_id"];
                    var membershipId = (int)reader["membership_id"];
                    var entryDate =  reader.IsDBNull(reader.GetOrdinal("entryDate")) ? null : (DateTime?)reader["entryDate"];
                    var insertedByID = (int)reader["insertedBy_id"];
                    var barcode = reader["barcode"].ToString();
                    var gymId = (int)reader["gym_id"];
                    
                    var entry = new Entry(id,clientId,membershipId,entryDate,insertedByID,barcode,gymId);
                    entries.Add(entry);
                }
            }
        }
        return entries;
    }
}