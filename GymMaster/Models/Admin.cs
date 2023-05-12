namespace GymMaster.Models;

public class Admin
{
    private int Id { get; }
    private string Name { get; set; }
    private string PhoneNumber { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }

    public Admin(int id, string name, string phoneNumber, string email, string password)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
    }
}