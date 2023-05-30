using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GymMaster.Models;

namespace GymMaster.DataAccess;

public class MembershipCardRepository
{
    private readonly string _connectionString;
    private List<MembershipCard> membershipCardsList;

    public MembershipCardRepository()
    {
        _connectionString = Constants.ConnectionString;
    }

    public List<MembershipCard> GetAllMembershipCards()
    {
        return  AllMembershipCards();
    }

    public MembershipCard GetMembershipCardById(int id)
    {
        try
        {
            return AllMembershipCards().First(c => c.Id == id);
        }
        catch (InvalidOperationException)
        {
            throw new Exception("No membership card found with the given ID!");
        }
    }


    private List<MembershipCard> AllMembershipCards()
    {
        var membershipCards = new List<MembershipCard>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM membershipCard";
            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["membership_id"];
                    var name = reader["name"].ToString();
                    var price = (double)reader["price"];
                    var validDaysNum = (int)reader["validDaysNum"];
                    var validEntriesNum = (int)reader["validEntriesNum"];
                    var isDeleted = (bool)reader["isDeleted"];
                    var gymId = (int)reader["gym_id"];
                    var startHour = (int)reader["startHour"];
                    var endHour = (int)reader["endHour"];
                    var dailyEntriesNum = (int)reader["dailyEntriesNum"];
                    
                    var membershipCard = new MembershipCard(id, name, price, validDaysNum, validEntriesNum,isDeleted, gymId, startHour, endHour, dailyEntriesNum);
                    membershipCards.Add(membershipCard);
                }
            }
        }
        return membershipCards;
    }
}
