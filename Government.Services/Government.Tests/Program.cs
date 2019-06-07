using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var munis = GovernmentService.GetMunicipalities();
            var adds = GovernmentService.GetAddresses();
            var offs = GovernmentService.GetOfficials();

            GovernmentService.DisplayText("MUNICIPALITIES");

            foreach (var item in munis)
            {
                Console.WriteLine($"#{item.MunicipalNumber} Name: {item.MunicipalName}");
            }

            GovernmentService.DisplayText("OFFICIALS");

            foreach (var item in offs)
            {
                Console.WriteLine($"Position: {item.Position} Name: {item.FullName}");
            }

            GovernmentService.DisplayText("ADDRESSES");

            foreach (var item in adds)
            {
                Console.WriteLine($"{item.MailingAddressLine1} {item.MailingAddressLine2}, {item.City}, {item.State} {item.Zip}");
            }

            Console.ReadLine();
        }
    }
}
