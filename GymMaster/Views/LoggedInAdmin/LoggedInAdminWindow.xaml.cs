using System;
using System.Linq;
using System.Windows;
using GymMaster.DataAccess;

namespace GymMaster.Views.LoggedInAdmin;

public partial class LoggedInAdminWindow : Window
{
    public LoggedInAdminWindow()
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