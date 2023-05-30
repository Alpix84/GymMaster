using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class ClientMCardViewModel
{
    private static ClientMCardViewModel? instance;
    private ClientViewModel? clientVM;
    private ClientMCardRepository _clientMCardRepository = new();
    private MembershipCardRepository _membershipCardRepository = new();

    public static ClientMCardViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ClientMCardViewModel();
            }
            return instance;
        }
    }
    
    private ClientMCardViewModel()
    {
        clientVM = ClientViewModel.Instance;
    }
    
    public void IncrementEntriesNum(int id)
    {
            _clientMCardRepository.IncrementEntriesNum(id);
    }


    public void AddCardToClient(string clientBarcode,int membershipCardID,float priceSold,DateTime validUntil,int gymId)
    {
        Client client = clientVM.GetClientByBarcode(clientBarcode);
        if ( client is { IsDeleted: false })
        {
            if (priceSold > 0)
            {
                if (validUntil > DateTime.Today.Date)
                {
                    _clientMCardRepository.AddCardToClient(client.Id,membershipCardID,priceSold,validUntil,Constants.GenerateBarcode(),gymId);
                }
                else
                {
                    MessageBox.Show("Error inserting client!");
                    Console.WriteLine("DATE ERROR");
                }
            }
            else
            {
                MessageBox.Show("Error inserting client!");
                Console.WriteLine("LOW PRICE");
            }
        }
        else
        {
            MessageBox.Show("Client is deleted!");
            Console.WriteLine("DELETED CLIENT");
        }
    }

    public List<ClientMCards> GetAllCards()
    {
        return _clientMCardRepository.GetClientMCardsList();
    }
}