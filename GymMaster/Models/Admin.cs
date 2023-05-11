public class Admin
{
    public int Id { get; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Admin(int id, string name, string phoneNumber, string email, string password)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
    }
}