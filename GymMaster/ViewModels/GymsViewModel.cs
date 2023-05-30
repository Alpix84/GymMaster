using GymMaster.DataAccess;
using GymMaster.Models;

namespace GymMaster.ViewModels;

public class GymsViewModel
{
    private static GymsViewModel? instance;
    private GymRepository _gymRepository = new();

    public static GymsViewModel Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new GymsViewModel();
            }
            return instance;
        }
    }

    private GymsViewModel()
    {
        
    }

    public Gym? GetGymById(int id)
    {
        return _gymRepository.GetGymById(id);
    }
    
}