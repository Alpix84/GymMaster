namespace GymMaster.Models;

public class MembershipCard
{
    private int Id { get; }
    private string Name { get; set; }
    private float Price { get; set; }
    private int ValidDaysNum { get; set; }
    private int ValidEntriesNum { get; set; }
    private bool IsDeleted { get; set; }
    private int GymId { get; set; }
    private int StartHour { get; set; }
    private int EndHour { get; set; }
    private int DailyEntriesNum { get; set; }

    public MembershipCard(int id, string name, float price, int validDaysNum, int validEntriesNum, bool isDeleted, int gymId, int startHour, int endHour, int dailyEntriesNum)
    {
        Id = id;
        Name = name;
        Price = price;
        ValidDaysNum = validDaysNum;
        ValidEntriesNum = validEntriesNum;
        IsDeleted = isDeleted;
        GymId = gymId;
        StartHour = startHour;
        EndHour = endHour;
        DailyEntriesNum = dailyEntriesNum;
    }
}