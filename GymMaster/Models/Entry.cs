using System;

namespace GymMaster.Models;

public class Entry
{
    private int Id { get; }
    private int ClientId { get; set; }
    private int MembershipId { get; set; }
    private DateTime EntryDate { get; set; }
    private int InsertedById { get; set; }
    private string Barcode { get; set; }
    private int GymId { get; set; }

    public Entry(int id, int clientId, int membershipId, DateTime entryDate, int insertedById, string barcode, int gymId)
    {
        Id = id;
        ClientId = clientId;
        MembershipId = membershipId;
        EntryDate = entryDate;
        InsertedById = insertedById;
        Barcode = barcode;
        GymId = gymId;
    }
}