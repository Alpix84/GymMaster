using GymMaster.Models;

namespace GymMaster.ViewModels;

public class CurrentUserViewModel
{
    
    private static CurrentUserViewModel? instance;
    
    public static CurrentUserViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CurrentUserViewModel();
            }
            return instance;
        }
    }
    
    public void SetCurrentUser(IUser user)
    {
        switch (CurrentUser.UserType)
        {
            case UserType.ADMIN:
                CurrentUser.Id = ((Admin)user).Id;
                CurrentUser.Name = ((Admin)user).Name;
                CurrentUser.Email = ((Admin)user).Email;
                break;
            case UserType.CLIENT:
                CurrentUser.Id = ((Client)user).Id;
                CurrentUser.Name = ((Client)user).Name;
                CurrentUser.Email = ((Client)user).Email;
                break;
        }
    }

    public void LogOutCurrentUser()
    {
        CurrentUser.Id = null;
        CurrentUser.Name = null;
        CurrentUser.Email = null;
        CurrentUser.UserType = null;
    }
}