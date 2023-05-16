using System.Collections.Generic;
using System.Windows;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class LoginViewModel
{
    
    private static LoginViewModel instance;
    
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
    
    private CurrentUserViewModel CurrentUserVM = new();
    public void Login(UserType userType,string email, string password)
    {
        if (userType == UserType.ADMIN)
        {
            List<Admin> admins = AdminViewModel.Instance.GetAdminsList();
            foreach (var admin in admins)
            {
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    CurrentUserVM.SetCurrentUser(admin,userType);
                    //TODO Navigate to other page
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
                    CurrentUserVM.SetCurrentUser(client, userType);
                    //TODO Navigate to other page
                }
            }
        }
        else
        {
            MessageBox.Show("Incorrect login credentials!");
        }
    }

    public void LogOut()
    {
        CurrentUserVM.LogOutCurrentUser();
        //TODO Navigate to main page
    }
    
}