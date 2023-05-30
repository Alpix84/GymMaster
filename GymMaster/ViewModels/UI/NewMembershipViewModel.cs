using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMaster.ViewModels.UI
{
    public class NewMembershipViewModel : BaseViewModel
    {
        
        private MembershipCardViewModel _membershipCardVM = MembershipCardViewModel.Instance;
        private GymsViewModel _gymsVM = GymsViewModel.Instance;

            public void CreateMembershipCard(string name,double price,int validDays,int validEntries,int gymId,int startH,int endH,int dailyEntries)
        {
            if (price > 0)
            {
                if (_gymsVM.GetGymById(gymId) == null)
                {
                }
                else
                {
                    if (_gymsVM.GetGymById(gymId).IsDeleted) 
                    {
                        MessageBox.Show("This gym is deleted!");
                    } 
                    else
                    {
                        _membershipCardVM.NewMembershipCard(name,price,validDays,validEntries,gymId,startH,endH,dailyEntries);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Price cannot be {price}!");
            }

        }
        
    }
}
