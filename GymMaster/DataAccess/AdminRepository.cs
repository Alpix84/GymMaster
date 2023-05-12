using System;
using System.Collections.Generic;
using GymMaster.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace GymMaster.DataAccess;

public class AdminRepository
{
    private readonly string _connectionString;

    public AdminRepository()
    {
        _connectionString = Constants.ConnectionString;
    }

    public void AddAdmin(string name,string phoneNumber,string email,string password)
    {
        
        if (AdminExists(email))
        {
            Console.WriteLine("An admin with this email already exists.");
            return;
        }
        
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        string hashString;

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(passwordBytes);
            hashString = Convert.ToBase64String(hash);
        }
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "INSERT INTO admins (name, phoneNumber,email,password) VALUES (@Name, @PhoneNumber, @Email,@Password)";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", hashString);

            command.ExecuteNonQuery();
        }
    }

    public List<Admin> GetAllAdmins()
    {
        var admins = new List<Admin>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT admin_id, name, phoneNumber,email,password FROM admins";

            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["admin_id"];
                    var name = reader["name"].ToString();
                    var phoneNumber = reader["phoneNumber"].ToString();
                    var email = reader["email"].ToString();
                    var password = reader["password"].ToString();

                    var admin = new Admin(id, name!, phoneNumber!,email!,password!);
                    admins.Add(admin);
                }
            }
        }
        return admins;
    }

    public void RemoveAdmin(string email)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "DELETE FROM admins WHERE email = @email";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);
            command.ExecuteNonQuery();
        }
    }
    
    public bool AdminExists(string email)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT COUNT(*) FROM admins WHERE email = @Email";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            var result = (int)command.ExecuteScalar();
            return result > 0;
        }
    }

}