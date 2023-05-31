using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class GymRepository
{
    private readonly string _connectionString;

    public GymRepository()
    {
        _connectionString = Constants.ConnectionString;
    }

    public List<Gym> GetGymsList()
    {
        return GymsList();
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

                    bool isDeleted = Convert.IsDBNull(reader["isDeleted"]) ? false : (bool)reader["isDeleted"];
                    var gym = new Gym(id, name, isDeleted);
                    gyms.Add(gym);
                }
            }
        }
        return gyms;
    }
    public Gym? GetGymById(int id)
    {
        try
        {
            return GymsList().First(c => c.Id == id);
        }
        catch (InvalidOperationException)
        {
            MessageBox.Show("No gym found with given ID!");
        }

        return null;
    }
    
}
