using System.Collections.Generic;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels
{
    public class AdminViewModel
    {
        private static AdminRepository _adminRepository = new();
        private List<Admin> _adminList;

        public AdminViewModel()
        {
            _adminList = _adminRepository.GetAllAdmins();
        }
    
        public List<Admin> GetAdminsList()
        {
            return _adminList;
        }

    }
}