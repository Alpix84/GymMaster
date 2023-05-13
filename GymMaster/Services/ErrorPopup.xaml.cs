using System.Windows.Controls;

namespace GymMaster.Services
{
    public partial class ErrorPopup : UserControl
    {
        public ErrorPopup()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            // close popup window
            var parent = this.Parent as Panel;
            parent.Children.Remove(this);
        }
    }
}