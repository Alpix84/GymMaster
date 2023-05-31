using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Input;
using GymMaster.Models;
using GymMaster.ViewModels;

namespace GymMaster.Views.LoggedInClient;

public partial class LoggedInClientWindow : Window
{
    public LoggedInClientWindow()
    {
        InitializeComponent();
        MakeCardPairs();
        if (clientCardsPairs != null)
        {
            foreach (var pair in clientCardsPairs)
            {
                var gym = _gymsVM.GetGymById(pair.Value.GymId);
                ClientMembership membership = new ClientMembership();
                membership.name = pair.Value.Name;
                membership.priceSold = pair.Key.PriceSold;
                membership.validDays = pair.Value.ValidDaysNum;
                membership.validEntries = pair.Value.ValidEntriesNum;
                membership.gym = gym.Name;
                membership.startHour = pair.Value.StartHour;
                membership.endHour = pair.Value.EndHour;
                membership.dailyEntries = pair.Value.DailyEntriesNum;
                membership.barcode = pair.Key.Barcode;
                membership.currentEntries = pair.Key.CurrentEntries;
                membership.validUntil = pair.Key.ValidUntil;
            
                DataGrid.Items.Add(membership);
            }
        }
    }
    
    private static ClientMCardViewModel _clientMCardVM = ClientMCardViewModel.Instance;
    private static MembershipCardViewModel _membershipCardVM = MembershipCardViewModel.Instance;
    private static GymsViewModel _gymsVM = GymsViewModel.Instance;
    private List<ClientMCards> _cardsList = _clientMCardVM.GetAllCards().Where(c => c.ClientId == CurrentUser.Id).ToList();
    private List<MembershipCard> _membershipCards = _membershipCardVM.GetAllMembershipCards();
    private List<KeyValuePair<ClientMCards, MembershipCard>> clientCardsPairs = new();

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
        public double priceSold { get;  set; }
        public int validDays { get; set; }
        public int validEntries { get; set; }
        public string gym { get; set; }
        public int startHour { get; set; }
        public int endHour { get; set; }
        public int dailyEntries { get; set; }
        public string barcode { get;  set; }
        public int currentEntries { get;  set; }
        public DateTime? validUntil { get;  set; }


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
