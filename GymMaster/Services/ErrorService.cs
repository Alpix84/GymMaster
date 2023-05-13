using System.Windows;

namespace GymMaster.Services
{
    public class ErrorService
    {
        public static void ShowError(string message)
        {
            ErrorPopup popup = new ErrorPopup();
            popup.ErrorMessageTextBlock.Text = message;
            
            Window window = new Window();
            window.Content = popup;
            window.ShowDialog();
        }
    }
}