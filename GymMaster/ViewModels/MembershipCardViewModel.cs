using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class MembershipCardViewModel
{
    private static MembershipCardViewModel? instance;
    private MembershipCardRepository _membershipCardRepository = new();

    public static MembershipCardViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MembershipCardViewModel();
            }
            return instance;
        }
    }

    private MembershipCardViewModel()
    {
        
    }

    public List<MembershipCard> GetAllMembershipCards()
    {
        return _membershipCardRepository.GetAllMembershipCards();
    }

    public MembershipCard? GetMembershipCard(int cardId)
    {
        return _membershipCardRepository.GetMembershipCardById(cardId);
    }

    public void NewMembershipCard(string name,double price,int validDays,int validEntries,int gymId,int startH,int endH,int dailyEntries)
    {
        if (_membershipCardRepository.GetAllMembershipCards().Any(c=> c.Name == name))
        {
            MessageBox.Show("A Membership Card with this name already exists!");
        }
        else
        {
            _membershipCardRepository.AddNewMembershipCard(name,price,validDays,validEntries,gymId,startH,endH,dailyEntries);
        }
    }
}