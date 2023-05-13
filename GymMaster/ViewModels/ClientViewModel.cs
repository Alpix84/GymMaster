using System.Collections.Generic;
using System.Windows.Documents;
using GymMaster.DataAccess;
using GymMaster.Models;
using GymMaster.Services;

namespace GymMaster.ViewModels
{
    public class ClientViewModel
    {
        private static ClientRepository _clientRepository = new();
        private List<Client> clientList = new();
        
        public ClientViewModel()
        {
            clientList = _clientRepository.GetAllClients();
        }

        public List<Client> GetClientsList()
        {
            return clientList;
        }

        public List<string> GetClientNames()
        {
            var clientNames = new List<string>();

            foreach (var client in clientList)
            {
                clientNames.Add(client.Name);
            }

            return clientNames;
        }

        public Client? GetClientByBarcode(string barcode)
        {
            Client clientToReturn = null;
            foreach (var client in clientList)
            {
                if (client.Barcode == barcode)
                {
                    clientToReturn = client;
                }
            }

            if (clientToReturn == null)
            {
                ErrorService.ShowError("No client found with this barcode!");
            }

            return clientToReturn;
        }
        
    }
}

