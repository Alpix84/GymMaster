using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class EntryRepository
{
    private readonly string _connectionString;
    private List<Entry> entriesList;

    public EntryRepository()
    {
        _connectionString = Constants.ConnectionString;
        entriesList = EntriesList();
    }

    public List<Entry> GetEntriesList()
    {
        return entriesList=EntriesList();
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