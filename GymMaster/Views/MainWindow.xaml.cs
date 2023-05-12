using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private AdminRepository _adminRepository = new AdminRepository();
        public MainWindow()
        {
            InitializeComponent();
            List<Admin> admins = _adminRepository.GetAllAdmins();
            AdminListTextBlock.Text = string.Join(Environment.NewLine, admins.Select(admin => $"ID: {admin.Id}, Name: {admin.Name}, Email: {admin.Email}, Phone Number: {admin.PhoneNumber}"));

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Admin> admins = _adminRepository.GetAllAdmins();
            AdminListTextBlock.Text = string.Join(Environment.NewLine, admins.Select(admin => $"ID: {admin.Id}, Name: {admin.Name}, Email: {admin.Email}, Phone Number: {admin.PhoneNumber}"));
        }

        
    }
}
