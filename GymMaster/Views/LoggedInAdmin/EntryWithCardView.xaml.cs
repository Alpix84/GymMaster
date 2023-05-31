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
using GymMaster.Models;
using GymMaster.ViewModels;

namespace GymMaster.Views.LoggedInAdmin
{
    /// <summary>
    /// Interaction logic for EntryWithCardView.xaml
    /// </summary>
    public partial class EntryWithCardView : UserControl
    {
        public EntryWithCardView()
        {
            InitializeComponent();
        }
        
        private EntryViewModel _entryVM = EntryViewModel.Instance;

        private void btnNewEntry_Click(object sender, RoutedEventArgs e)
        {
            var barcode = txtBarcode.Text;
            var membershipId = int.Parse(txtMembershipType.Text);
            _entryVM.AddNewEntry(barcode,membershipId);
        }
    }
}
