using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class LoginViewModel
{
    public void Login(UserType userType,string email, string password)
    {
        if (userType == UserType.ADMIN)
        {
            List<Admin> admins = new AdminViewModel().GetAdminsList();
            foreach (var admin in admins)
            {
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    CurrentUser.Id = admin.Id;
                    CurrentUser.Email = admin.Email;
                    CurrentUser.Name = admin.Name;
                    CurrentUser.UserType = UserType.ADMIN;
                    //TODO Navigate to other page
                }
            }
        }
        else if (userType == UserType.CLIENT)
        {
            List<Client> clients = new ClientViewModel().GetClientsList();
            foreach (var client in clients)
            {
                if (client.Email.Equals(email) && client.Password.Equals(password))
                {
                    CurrentUser.Id = client.Id;
                    CurrentUser.Email = client.Email;
                    CurrentUser.Name = client.Name;
                    CurrentUser.UserType = UserType.CLIENT;
                    //TODO Navigate to other page
                }
            }
        }
        else
        {
            MessageBox.Show("Incorrect login credentials!");
        }
    }
}