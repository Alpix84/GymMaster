namespace GymMaster.Models;

public class MembershipCard
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public float Price { get; private set; }
    public int ValidDaysNum { get; private set; }
    public int ValidEntriesNum { get; private set; }
    public bool IsDeleted { get; private set; }
    public int GymId { get; private set; }
    public int StartHour { get; private set; }
    public int EndHour { get; private set; }
    public int DailyEntriesNum { get; private set; }

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