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
using GymMaster.ViewModels.UI;
using MessageBox = System.Windows.Forms.MessageBox;

namespace GymMaster.Views.LoggedInAdmin
{
    /// <summary>
    /// Interaction logic for NewMembershipView.xaml
    /// </summary>
    public partial class NewMembershipView : UserControl
    {
        public NewMembershipView()
        {
            InitializeComponent();
        }

        private NewMembershipViewModel _newMembershipVM = new();

        private void btnMakeMembership_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var price = double.Parse(txtPrice.Text);
            var validDays = int.Parse(txtValidDaysNum.Text);
            var validEntries = int.Parse(txtValidEntriesNum.Text);
            var gymId = int.Parse(txtGymId.Text);
            var startHour = int.Parse(txtStartHour.Text);
            var endHour = int.Parse(txtEndHour.Text);
            var dailyEntries = int.Parse(txtDailyEntriesNum.Text);

            if (name.Length < 4)
            {
                MessageBox.Show("Too short name for Membership card!");
            }
            else
            {
                _newMembershipVM.CreateMembershipCard(name,price,validDays,validEntries,gymId,startHour,endHour,dailyEntries);
            }
        }
    }
}
