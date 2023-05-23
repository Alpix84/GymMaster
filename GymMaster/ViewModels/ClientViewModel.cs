using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels
{
    public class ClientViewModel
    {
        private static ClientViewModel? instance;
    
        public static ClientViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientViewModel();
                }
                return instance;
            }
        }
        
        private static ClientRepository _clientRepository = new();

        private ClientViewModel()
        {
        }

        public List<Client> GetClientsList()
        {
            return _clientRepository.GetClientsList();
        }

        public List<string> GetClientNames()
        {
            return GetClientsList().Select(c => c.Name).ToList();
        }

        public Client? GetClientByBarcode(string barcode)
        {
            try
            {
                return GetClientsList().First(c => c.Barcode.Equals(barcode));
            }
            catch (Exception e)
            {
                MessageBox.Show("No client found with given code!");
            }
            return null;
        }
    }
}

