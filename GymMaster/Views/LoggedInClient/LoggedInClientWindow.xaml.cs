using System.Windows;

namespace GymMaster.Views.LoggedInClient;

public partial class LoggedInClientWindow : Window
{
    public LoggedInClientWindow()
    {
        InitializeComponent();
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