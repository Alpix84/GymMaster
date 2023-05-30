using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class ClientRepository
{
    private readonly string _connectionString;

    public ClientRepository()
    {
        _connectionString = Constants.ConnectionString;
    }

    public List<Client> GetClientsList()
    {
        return ClientsList();
    }

    public void AddNewClient(string name,string phonenumber,string email,string address,string barcode,string notes,string password)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            
            var query = $"INSERT INTO clients(name, phoneNumber, email, isDeleted, photo, registrationDate, address, barcode,note,password) VALUES ({name}, {phonenumber}, {email},NULL,NULL,'{DateTime.Today.ToString("yyyy-MM-dd")}', '{address}', {barcode},, {notes},{password})";
            var command = new SqlCommand(query, connection);
            
            command.ExecuteNonQuery();
        }
    }

    private List<Client> ClientsList()
    {
        var clients = new List<Client>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT client_id, name, phoneNumber, email, isDeleted, photo, registrationDate, address, barcode, note, password FROM clients";

            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["client_id"];
                    var name = reader["name"].ToString();
                    var phoneNumber = reader["phoneNumber"].ToString();
                    var email = reader["email"].ToString();
                    var isDeleted = (bool)reader["isDeleted"];
                    var photo = reader.IsDBNull(reader.GetOrdinal("photo")) ? null : (byte[])reader["photo"];
                    var registrationDate = reader.IsDBNull(reader.GetOrdinal("registrationDate")) ? null : (DateTime?)reader["registrationDate"];
                    var address = reader["address"].ToString();
                    var barcode = reader["barcode"].ToString();
                    var note = reader["note"].ToString();
                    var password = reader["password"].ToString();

                    clients.Add(new Client(id, name, phoneNumber, email, isDeleted, photo, (DateTime)registrationDate, address, barcode, note, password));
                }
            }
        }
        return clients;
    }
}