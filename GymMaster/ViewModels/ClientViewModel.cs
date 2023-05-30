using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public void AddNewClient(string name,string phonenumber,string email, string address,string notes,string password)
        {
            
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            string passwordHash;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(passwordBytes);
                passwordHash = Convert.ToBase64String(hash);
            }

            if (ClientExists(email) == false)
            {
                _clientRepository.AddNewClient(name,phonenumber,email,address,Constants.GenerateBarcode(),notes,passwordHash);
            }
            else
            {
                MessageBox.Show("Client with given email already exists!");
            }
        }

        private bool ClientExists(string email)
        {
            if (GetClientByEmail(email)==null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
        
        public Client? GetClientByEmail(string email)
        {
            try
            {
                return GetClientsList().FirstOrDefault(c => c.Email.Equals(email));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
    }
}

