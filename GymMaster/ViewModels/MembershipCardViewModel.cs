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

    public MembershipCard GetMembershipCard(int cardId)
    {
        return _membershipCardRepository.GetMembershipCardById(cardId);
    }
    
}