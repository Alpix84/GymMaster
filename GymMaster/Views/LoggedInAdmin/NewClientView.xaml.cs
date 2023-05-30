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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GymMaster.ViewModels;

namespace GymMaster.Views.LoggedInAdmin
{
    /// <summary>
    /// Interaction logic for NewClientView.xaml
    /// </summary>
    public partial class NewClientView : UserControl
    {
        public NewClientView()
        {
            InitializeComponent();
        }
        
        private ClientViewModel _clientVM = ClientViewModel.Instance;

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var phoneNumber = txtPhone.Text;
            var email = txtEmail.Text;
            var address = txtAddress.Text;
            var notes = txtNotes.Text;
            var password = txtPassword.Text;
            _clientVM.AddNewClient(name,phoneNumber,email,address,notes,password);
        }
    }
}
