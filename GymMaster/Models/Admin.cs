namespace GymMaster.Models;

public class Admin : User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }


    public Admin(int id, string name, string phoneNumber, string email, string password)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
    }
}