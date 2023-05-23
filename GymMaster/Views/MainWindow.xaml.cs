using System;
using System.Windows;
using GymMaster.ViewModels;

namespace GymMaster.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private AdminViewModel _adminVM = AdminViewModel.Instance;
        private ClientViewModel _clientVM = ClientViewModel.Instance;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var admin = _adminVM.GetAdminByEmail("emb1er@gmail.com");
            AdminListTextBlock.Text = admin != null ? string.Join(Environment.NewLine, $"ID: {admin.Id}, Name: {admin.Name}, Email: {admin.Email}, Phone Number: {admin.PhoneNumber}") : "";
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var client = _clientVM.GetClientNames();
            AdminListTextBlock.Text = string.Join(Environment.NewLine, client);
        }
    }
}
