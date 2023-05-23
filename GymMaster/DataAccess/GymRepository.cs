using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class GymRepository
{
    private readonly string _connectionString;
    private List<Gym> gymsList;

    public GymRepository()
    {
        _connectionString = Constants.ConnectionString;
        gymsList = GymsList();
    }

    public List<Gym> GetGymsList()
    {
        return gymsList = GymsList();
    }

    private List<Gym> GymsList()
    {
        var gyms = new List<Gym>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM gyms";
            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["gym_id"];
                    var name = reader["name"].ToString();
                    var isDeleted = (bool)reader["isDeleted"];

                    var gym = new Gym(id, name, isDeleted);
                    gyms.Add(gym);
                }
            }
        }
        return gyms;
    }
}