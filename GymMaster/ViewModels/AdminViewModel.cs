using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels
{
    public class AdminViewModel
    {
        private static AdminViewModel? instance;
    
        public static AdminViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminViewModel();
                }
                return instance;
            }
        }
        
        private static AdminRepository _adminRepository = new();

        private AdminViewModel()
        {
            _adminRepository.GetAdminsList();
        }

        public void AddNewAdmin(string name,string phoneNumber,string email,string password)
        {
            _adminRepository.AddAdmin(name,phoneNumber,email,password);
        }
    
        public List<Admin> GetAdminsList()
        {
            return _adminRepository.GetAdminsList();
        }
        
        public Admin? GetAdminByEmail(string email)
        {
            try
            {
                return GetAdminsList().First(a => a.Email.Equals(email));
            }
            catch (Exception e)
            {
                MessageBox.Show("No admin with such email!");
            }
            return null;
        }

    }
}