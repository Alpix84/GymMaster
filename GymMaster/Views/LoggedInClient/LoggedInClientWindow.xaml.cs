using System;
using System.Windows;

namespace GymMaster.Views.LoggedInClient;

public partial class LoggedInClientWindow : Window
{
    public LoggedInClientWindow()
    {
        InitializeComponent();

        ClientMembership membership = new ClientMembership();



        DataGrid.Items.Add(membership);
    }

    public class ClientMembership
    {
        public string name { get; set; }
        public double priceSold { get; private set; }
        public string validDays { get; set; }
        public string validEntries { get; set; }
        public string gym { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public string dailyEntries { get; set; }
        public string barcode { get; private set; }
        public int currentEntries { get; private set; }
        public DateTime? validUntil { get; private set; }


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