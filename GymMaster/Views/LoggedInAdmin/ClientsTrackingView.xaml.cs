using GymMaster.Models;
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
using GymMaster.DataAccess;
using GymMaster.Models;
using GymMaster.ViewModels;

namespace GymMaster.Views.LoggedInAdmin
{
    /// <summary>
    /// Interaction logic for ClientsTrackingView.xaml
    /// </summary>
    public partial class ClientsTrackingView : UserControl
    {


        public class NewClient{
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string registrationDate { get; set; }
        public string address { get; set; }
        public string barcode { get; set; }
        public string notes { get; set; }
    }

        public ClientsTrackingView()
        {
            InitializeComponent();
            ClientViewModel clientViewModel = ClientViewModel.Instance;
            List<Client> clients = clientViewModel.GetClientsList();
            foreach(Client client in clients)
            {   
                NewClient newClient = new NewClient();

                newClient.name = client.Name;
                newClient.phoneNumber = client.PhoneNumber;
                newClient.registrationDate = client.RegistrationDate.ToString();
                newClient.address = client.Address;
                newClient.barcode = client.Barcode;
                newClient.notes = client.Notes;
                
                DataGrid.Items.Add(newClient);
            }

        }

        
    }
}
