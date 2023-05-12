using System;

namespace GymMaster.Models;

public class Entry
{
    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public int MembershipId { get; private set; }
    public DateTime EntryDate { get; private set; }
    public int InsertedById { get; private set; }
    public string Barcode { get; private set; }
    public int GymId { get; private set; }

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