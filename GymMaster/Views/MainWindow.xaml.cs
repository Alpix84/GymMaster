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
            _clientMCardVM.AddCardToClient("KFQX0789",6,65,new DateTime(2023,8,4),1);
            _clientMCardVM.AddCardToClient("KFQX0789",8,30,new DateTime(2023,7,1),2);
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }
    }
}
