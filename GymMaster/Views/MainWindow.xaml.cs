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
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _adminVM.AddNewAdmin("Reszeg Alpar","123-456-7890","alpar@gmail.com","jelszo123");
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _clientMCardVM.AddCardToClient("ABC123",2,60,new DateTime(2023,7,1), 1);
        }
    }
}
