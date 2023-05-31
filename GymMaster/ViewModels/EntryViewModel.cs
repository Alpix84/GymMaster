using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class EntryViewModel
{
    private static EntryViewModel? instance;

    public static EntryViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }
    }

    private static EntryRepository _entryRepository = new();
    private ClientViewModel _clientVM = ClientViewModel.Instance;
    private ClientMCardViewModel _clientMCardVM = ClientMCardViewModel.Instance;
    private MembershipCardViewModel _membershipCardVM = MembershipCardViewModel.Instance;
    private AdminViewModel _adminVM = AdminViewModel.Instance;

    private EntryViewModel()
    {
        _entryRepository.GetEntriesList();
    }

    public void AddNewEntry(string clientBarcode,int membershipId)
    {
        Client? client = _clientVM.GetClientByBarcode(clientBarcode);
        List<ClientMCards> mCardsList = _clientMCardVM.GetAllCards();
        ClientMCards clientMCard = mCardsList.Where(c => c.ClientId == client?.Id).FirstOrDefault(c => c.MembershipId == membershipId)!;
        MembershipCard? membershipCard = _membershipCardVM.GetMembershipCard(membershipId);
        if (CurrentUser.Id != null)
        {
            if (client is { IsDeleted: false })
            {
                if (membershipCard != null)
                {
                    if (clientMCard.CurrentEntries > membershipCard?.ValidEntriesNum)
                    {
                        MessageBox.Show("Max entries reached!");
                    }
                    else
                    {
                        if (DateTime.Today < clientMCard.ValidUntil)
                        {
                            if ((DateTime.Today.Hour >= membershipCard.StartHour || membershipCard.StartHour == 0) &&
                                (DateTime.Today.Hour <= membershipCard.EndHour || membershipCard.EndHour == 0))
                            {
                                if (_entryRepository.GetEntriesList().Count(c =>
                                        c.ClientId == client.Id && c.MembershipId == membershipId &&
                                        c.EntryDate == DateTime.Today) < membershipCard.DailyEntriesNum)
                                {
                                    _entryRepository.AddNewEntry(client.Id, membershipId,
                                        (int)CurrentUser.Id, Constants.GenerateBarcode(), membershipCard.GymId);
                                    _clientMCardVM.IncrementEntriesNum(clientMCard.Id);
                                    MessageBox.Show($"Successful entry with card {clientMCard.Barcode}");
                                }
                                else
                                {
                                    MessageBox.Show($"Maximum daily entries reached!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cannot enter current hour with this card!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The card is expired!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No such card!");
                }
            }
            else
            {
                MessageBox.Show("No such client!");
            }
        }
        else
        {
            MessageBox.Show("Admin not found or unable to manage entry!");
        }
    }
    
}