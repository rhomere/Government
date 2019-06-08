using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Government.Data;

namespace Government.Tests
{
    public class GovernmentService
    {
        public GovRepository GovRepo => new GovRepository();

        public GovernmentService()
        {

        }

        public List<Municipal> GetMunicipalities()
        {
            return GovRepo.GetMunicipalities();
        }

        public List<Official> GetOfficials()
        {
            return GovRepo.GetOfficials();
        }

        public List<Address> GetAddresses()
        {
            return GovRepo.GetAddresses();
        }

        public void DisplayText(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n{text}\n");
            Console.ResetColor();
        }
    }
}
