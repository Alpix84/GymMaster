namespace GymMaster.Models;

public class Gym
{
    private int Id { get; }
    private string Name { get; set; }
    private bool IsDeleted { get; set; }

    public Gym(int id, string name, bool isDeleted)
    {
        Id = id;
        Name = name;
        IsDeleted = isDeleted;
    }
}