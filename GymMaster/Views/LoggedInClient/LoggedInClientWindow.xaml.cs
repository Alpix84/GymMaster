using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GymMaster.Models;
using GymMaster.ViewModels;

namespace GymMaster.Views.LoggedInClient;

public partial class LoggedInClientWindow : Window
{
    public LoggedInClientWindow()
    {
        InitializeComponent();
        MakeCardPairs();

        ClientMembership membership1 = new ClientMembership();

        membership1.name = "Premium";
        membership1.price = "12";
        membership1.validDays = "30";
        membership1.validEntries = "12";
        membership1.gym = "Power Huni";
        membership1.startHour = "8";
        membership1.endHour = "22";
        membership1.dailyEntries = "1";
    }
    
    private static ClientMCardViewModel _clientMCardVM = ClientMCardViewModel.Instance;
    private static MembershipCardViewModel _membershipCardVM = MembershipCardViewModel.Instance;

    private List<ClientMCards> _cardsList = _clientMCardVM.GetAllCards().Where(c => c.ClientId == CurrentUser.Id).ToList();
    private List<MembershipCard> _membershipCards = _membershipCardVM.GetAllMembershipCards();
    private List<KeyValuePair<ClientMCards, MembershipCard>> clientCardsPairs;

    private void MakeCardPairs()
    {
        foreach (var card in _cardsList)
        {
            clientCardsPairs.Add(new KeyValuePair<ClientMCards, MembershipCard>(card,_membershipCards.First(c => c.Id == card.MembershipId)));
        }
    }


    public class ClientMembership
    {
        public string name { get; set; }
        public string price { get; set; }
        public string validDays { get; set; }
        public string validEntries { get; set; }
        public string gym { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public string dailyEntries { get; set; }


    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}