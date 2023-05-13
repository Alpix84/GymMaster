using System.Collections.Generic;
using System.Windows;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels
{
    public class ClientViewModel
    {
        private static ClientRepository _clientRepository = new();
        private List<Client> _clientList;
        
        public ClientViewModel()
        {
            _clientList = _clientRepository.GetAllClients();
        }

        public List<Client> GetClientsList()
        {
            return _clientList;
        }

        public List<string> GetClientNames()
        {
            var clientNames = new List<string>();

            foreach (var client in _clientList)
            {
                clientNames.Add(client.Name);
            }

            return clientNames;
        }

        public Client? GetClientByBarcode(string barcode)
        {
            Client? clientToReturn = null;
            foreach (var client in _clientList)
            {
                if (client.Barcode == barcode)
                {
                    clientToReturn = client;
                }
            }
            if (clientToReturn == null)
            {
                MessageBox.Show("No client found with given code!");
            }
            return clientToReturn;
        }
        
    }
}

