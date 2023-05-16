using System;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class ClientMCardViewModel
{
    private ClientViewModel? clientVM;

    public ClientMCardViewModel()
    {
        clientVM = ClientViewModel.Instance;
    }

    public void AddCardToClient(string clientBarcode,int membershipCardID,float priceSold,DateTime validUntil)
    {
        Client client = clientVM.GetClientByBarcode(clientBarcode);
        if ( client is { IsDeleted: false })
        {
            //TODO Continue
        }
    }
}