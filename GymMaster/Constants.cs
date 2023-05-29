using System;
using System.Text;

namespace GymMaster;

public class Constants
{
    public static readonly string ConnectionString = "Data Source=.;Initial Catalog=GymMaster;Integrated Security=True";
    
    public static string GenerateBarcode()
    {
        var random = new Random();
    
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";

        var barcode = new StringBuilder();

        for (int i = 0; i < 4; i++)
        {
            barcode.Append(letters[random.Next(letters.Length)]);
        }

        for (int i = 0; i < 4; i++)
        {
            barcode.Append(digits[random.Next(digits.Length)]);
        }

        return barcode.ToString();
    }
}