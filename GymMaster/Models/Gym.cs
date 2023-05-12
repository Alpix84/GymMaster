namespace GymMaster.Models;

public class Gym
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public Gym(int id, string name, bool isDeleted)
    {
        Id = id;
        Name = name;
        IsDeleted = isDeleted;
    }
}