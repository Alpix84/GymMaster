using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GymMaster.Models;
using GymMaster.ViewModels;
using GymMaster.Views.LoggedInAdmin;
using GymMaster.Views.LoggedInClient;

namespace GymMaster.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel _loginVM = LoginViewModel.Instance;
        public Login()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(txtPassword.Password);
            string hashString;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(passwordBytes);
                hashString = Convert.ToBase64String(hash);
            }
            if (_loginVM.Login(txtUser.Text, hashString))
            {
                UserType? userType = CurrentUser.UserType;
                switch (userType)
                {
                    case UserType.ADMIN:
                        LoggedInAdminWindow loggedInAdminWindow = new();
                        loggedInAdminWindow.Show();
                        break;
                    case UserType.CLIENT:
                        LoggedInClientWindow loggedInClientWindow = new();
                        loggedInClientWindow.Show();
                        break;
                    case null:
                        MessageBox.Show("LOGIN ERROR");
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("INVALID CREDENTIALS");
            }
        }
    }
}
