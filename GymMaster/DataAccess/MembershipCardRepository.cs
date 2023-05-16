using System.Collections.Generic;
using System.Data.SqlClient;
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
        membershipCardsList = AllMembershipCards();
    }

    public List<MembershipCard> GetAllMembershipCards()
    {
        return membershipCardsList = AllMembershipCards();
    }

    public MembershipCard? GetMembershipCardById(int id)
    {
        foreach (var membershipCard in membershipCardsList)
        {
            if (membershipCard.Id == id)
            {
                return membershipCard;
            }
        }
        MessageBox.Show("No membership card found!");
        return null;
    }

    private List<MembershipCard> AllMembershipCards()
    {
        var membershipCards = new List<MembershipCard>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM membershipCard WHERE isDeleted = 0";
            var command = new SqlCommand(query, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["membership_id"];
                    var name = reader["name"].ToString();
                    var price = (float)reader["price"];
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
