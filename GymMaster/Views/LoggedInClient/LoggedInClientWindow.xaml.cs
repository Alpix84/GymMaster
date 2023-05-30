using System.Windows;

namespace GymMaster.Views.LoggedInClient;

public partial class LoggedInClientWindow : Window
{
    public LoggedInClientWindow()
    {
        InitializeComponent();

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