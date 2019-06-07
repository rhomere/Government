using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Government.Data;

namespace Government.Tests
{
    public static class GovernmentService
    {
        public static List<Municipal> GetMunicipalities()
        {
            using (var context = new CityEntities())
            {
                return context.Municipalities.ToList();
            }
        }

        public static List<Official> GetOfficials()
        {
            using (var context = new CityEntities())
            {
                return context.Officials.ToList();
            }
        }

        public static List<Address> GetAddresses()
        {
            using (var context = new CityEntities())
            {
                return context.Addresses.ToList();
            }
        }

        public static void DisplayText(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n{text}\n");
            Console.ResetColor();
        }
    }
}
