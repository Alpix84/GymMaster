using System;

namespace GymMaster.Models;

public class Client : IUser
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public bool IsDeleted { get; private set; }
    public byte[] Image { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public string Address { get; private set; }
    public string Barcode { get; private set; }
    public string Notes { get; private set; }
    public string Password { get; private set; }


    public Client(int id, string name, string phoneNumber, string email, bool isDeleted, byte[] image, DateTime registrationDate, string address, string barcode, string notes, string password)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        IsDeleted = isDeleted;
        Image = image;
        RegistrationDate = registrationDate;
        Address = address;
        Barcode = barcode;
        Notes = notes;
        Password = password;
    }
}