using System;

namespace GymMaster.Models;

public class ClientMCards
{
    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public int MembershipId { get; private set; }
    public DateTime? BoughtOnDate { get; private set; }
    public string Barcode { get; private set; }
    public int CurrentEntries { get; private set; }
    public double PriceSold { get; private set; }
    public DateTime? ValidUntil { get; private set; }
    public DateTime? FirstEntry { get; private set; }
    public int GymId { get; private set; }


    public ClientMCards(int id, int clientId, int membershipId, DateTime? boughtOnDate, string barcode, int currentEntries, double priceSold, DateTime? validUntil, DateTime? firstEntry, int gymId)
    {
        Id = id;
        ClientId = clientId;
        MembershipId = membershipId;
        BoughtOnDate = boughtOnDate;
        Barcode = barcode;
        CurrentEntries = currentEntries;
        PriceSold = priceSold;
        ValidUntil = validUntil;
        FirstEntry = firstEntry;
        GymId = gymId;
    }
}