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
        private ClientMCardViewModel _clientMCardVM = ClientMCardViewModel.Instance;
        private EntryViewModel _entryVM = EntryViewModel.Instance;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminListTextBlock.Text = $"Client = {_clientVM.GetClientByEmail("horthy@gmail.com").Email}";
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }
    }
}
