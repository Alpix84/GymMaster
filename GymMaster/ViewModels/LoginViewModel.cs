using System.Collections.Generic;
using System.Windows;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class LoginViewModel
{
    
    private static LoginViewModel? instance;
    private CurrentUserViewModel CurrentUserVM;
    public static LoginViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
            }
            return instance;
        }
    }

    private LoginViewModel()
    {
        CurrentUserVM = CurrentUserViewModel.Instance;
    }
    
    public bool Login(string email, string password)
    {
        UserType? userType = CurrentUser.UserType;
        if (userType == UserType.ADMIN)
        {
            List<Admin> admins = AdminViewModel.Instance.GetAdminsList();
            foreach (var admin in admins)
            {
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    CurrentUserVM.SetCurrentUser(admin);
                    return true;
                }
            }
        }
        else if (userType == UserType.CLIENT)
        {
            List<Client> clients = ClientViewModel.Instance!.GetClientsList();
            foreach (var client in clients)
            {
                if (client.Email.Equals(email) && client.Password.Equals(password))
                {
                    CurrentUserVM.SetCurrentUser(client);
                    return true;
                }
            }
        }
        else
        {
            MessageBox.Show("Incorrect login credentials!");
            return false;
        }

        return false;
    }

    public void LogOut()
    {
        CurrentUserVM.LogOutCurrentUser();
        //TODO Navigate to main page
    }
    
}