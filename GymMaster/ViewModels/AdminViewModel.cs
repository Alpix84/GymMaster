using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using GymMaster.DataAccess;
using GymMaster.Models;
using GymMaster.ViewModels.UI;

namespace GymMaster.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private static AdminViewModel? instance;

        private BaseViewModel currentChildView;
        private string caption;
        private IconChar icon;
        public static AdminViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminViewModel();
                }
                return instance;
            }
        }

        public BaseViewModel CurrentChildView
        {
            get
            {
                return currentChildView;
            }
            set
            {
                if (currentChildView != value)
                {
                    currentChildView = value;
                    OnPropertyChanged(nameof(CurrentChildView));
                }

            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Commands to show Views
        public ICommand ShowNewClientViewCommand { get; }
        public ICommand ShowNewMembershipViewCommand { get; }
        public ICommand ShowEntryWithCardViewCommand { get; }
        public ICommand ShowClientCardsViewCommand { get; }
        public ICommand ShowTrackingViewCommand { get; }
        public ICommand ShowEmailViewCommand { get; }



        private static AdminRepository _adminRepository = new();

        public AdminViewModel()
        {
            _adminRepository.GetAdminsList();

            //Initialize commands
            ShowNewClientViewCommand = new ViewModelCommand(ExecuteShowNewClientViewCommand);
            ShowNewMembershipViewCommand = new ViewModelCommand(ExecuteShowNewMembershipViewCommand);
            ShowEntryWithCardViewCommand = new ViewModelCommand(ExecuteShowEntryWithCardViewCommand);
            ShowClientCardsViewCommand = new ViewModelCommand(ExecuteShowClientCardsViewCommand);
            ShowTrackingViewCommand = new ViewModelCommand(ExecuteShowTrackingViewCommand);
            ShowEmailViewCommand = new ViewModelCommand(ExecuteShowEmailViewCommand);
            //Default
            ExecuteShowNewClientViewCommand(null);
            //ExecuteShowNewMembershipViewCommand(null);
        }

        private void ExecuteShowEmailViewCommand(object obj)
        {
            CurrentChildView = new EmailViewModel();
            Caption = "Send Email";
            Icon = IconChar.Envelope;
        }

        private void ExecuteShowTrackingViewCommand(object obj)
        {
            CurrentChildView = new TrackingViewModel();
            Caption = "Tracking";
            Icon = IconChar.ChartSimple;
        }

        private void ExecuteShowClientCardsViewCommand(object obj)
        {
            CurrentChildView = new ClientCardsViewModel();
            Caption = "Client Cards";
            Icon = IconChar.AddressCard;
        }

        public void ExecuteShowNewClientViewCommand(object obj)
        {
            CurrentChildView = new NewClientViewModel();
            Caption = "New Client";
            Icon = IconChar.Plus;
        }

        public void ExecuteShowNewMembershipViewCommand(object obj)
        {
            CurrentChildView = new NewMembershipViewModel();
            Caption = "New Card";
            Icon = IconChar.Plus;
        }

        public void ExecuteShowEntryWithCardViewCommand(object obj)
        {
            CurrentChildView = new EntryWithCardViewModel();
            Caption = "Entry with Card";
            Icon = IconChar.DoorOpen;
        }


        public void AddNewAdmin(string name,string phoneNumber,string email,string password)
        {
            _adminRepository.AddAdmin(name,phoneNumber,email,password);
        }
    
        public List<Admin> GetAdminsList()
        {
            return _adminRepository.GetAdminsList();
        }
        
        public Admin? GetAdminByEmail(string email)
        {
            try
            {
                return GetAdminsList().First(a => a.Email.Equals(email));
            }
            catch (Exception e)
            {
                MessageBox.Show("No admin with such email!");
            }
            return null;
        }


    }


}