using System.Collections.Generic;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels
{
    public class AdminViewModel
    {
        
        private static AdminViewModel instance;
    
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
        private List<Admin> _adminList;

        private AdminViewModel()
        {
            _adminList = _adminRepository.GetAllAdmins();
        }
    
        public List<Admin> GetAdminsList()
        {
            return _adminList;
        }

    }
}