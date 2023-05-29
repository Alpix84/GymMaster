using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GymMaster.Views.Login
{
    /// <summary>
    /// Interaction logic for ChooseType.xaml
    /// </summary>
    public partial class ChooseType : Window
    {
        public ChooseType()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            View.Login login = new View.Login();
            login.Show();
            CurrentUser.UserType = UserType.CLIENT;
            this.Close();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            View.Login login = new View.Login();
            login.Show();
            CurrentUser.UserType = UserType.ADMIN;
            this.Close();
        }
    }
}
