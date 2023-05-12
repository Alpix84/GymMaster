using System;

namespace GymMaster.Models;

public class ClientMCards
{
    private int Id { get; }
    private int ClientId { get; set; }
    private int MembershipId { get; set; }
    private DateTime BoughtOnDate { get; set; }
    private string Barcode { get; set; }
    private int CurrentEntries { get; set; }
    private float PriceSold { get; set; }
    private DateTime ValidUntil { get; set; }
    private DateTime FirstEntry { get; set; }
    private int GymId { get; set; }

    public ClientMCards(int id, int clientId, int membershipId, DateTime boughtOnDate, string barcode, int currentEntries, float priceSold, DateTime validUntil, DateTime firstEntry, int gymId)
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