using System;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class ClientMCardViewModel
{
    private static ClientMCardViewModel? instance = null;
    private ClientViewModel? clientVM;

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

    public void AddCardToClient(string clientBarcode,int membershipCardID,float priceSold,DateTime validUntil)
    {
        Client client = clientVM.GetClientByBarcode(clientBarcode);
        if ( client is { IsDeleted: false })
        {
            //TODO Continue
            
        }
    }
}