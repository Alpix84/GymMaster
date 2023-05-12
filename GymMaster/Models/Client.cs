using System;

namespace GymMaster.Models;

public class Client
{
    private int Id { get; }
    private string Name { get; set; }
    private string PhoneNumber { get; set; }
    private string Email { get; set; }
    private bool IsDeleted { get; set; }
    private byte[] Image { get; set; }
    private DateTime RegistrationDate { get; set; }
    private string Address { get; set; }
    private string Barcode { get; set; }
    private string Notes { get; set; }
    private string Password { get; set; }

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