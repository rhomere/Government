using Government.Models;
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
            //GeneralTest();

            //GetMunicipalByAddressTest(new AddressRequest { StreetAddress = "1040 NW 5 AVE", StreetAddress2 = "", City = "Miami", ZipCode = "33136" });
            //GetMunicipalByAddressTest();

            //GetOfficialsByMunicipalTest("01");

            //GetFullMinicipalInfoByAddressTest(new AddressRequest { StreetAddress = "1040 NW 5 AVE", StreetAddress2 = "", City = "Miami", ZipCode = "33136" });

            //MunicipalLookUp("");



            GetGovFilesByMunicipalNumberTest("");
        }

        private static void GetGovFilesByMunicipalNumberTest(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                Console.WriteLine("Municipal Not Found");
                return;
            }

            var service = new GovernmentService();
            var govFiles = service.GetGovFilesByMunicipalNumber(number);

            govFiles.ForEach(f => { Console.WriteLine($"Name: {f.Name}\n{f.Description}\n\n)"; });
        }

        private static void MunicipalLookUp(string name = null)
        {
            var service = new GovernmentService();

            var check = true;
            var contCheck = true;
            while (check)
            {
                if (string.IsNullOrWhiteSpace(name)) RequestName(out name);
                GetFullMinicipalInfoByNameTest(name);
                name = string.Empty;
                //Exit
                while (contCheck)
                {
                    Console.Write("\nNext Municipality? Y/N: ");
                    var answer = Console.ReadLine().Trim();
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            contCheck = false;
                            break;
                        case "YES":
                            contCheck = false;
                            break;
                        case "N":
                            Console.WriteLine("Goodbye");
                            contCheck = false;
                            check = false;
                            break;
                        case "NO":
                            Console.WriteLine("Goodbye");
                            contCheck = false;
                            check = false;
                            break;
                        default:
                            contCheck = true;
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }

        private static void RequestName(out string name)
        {
            Console.Write("\nCity Name? ");
            name = Console.ReadLine().Trim();
        }

        private static void GetFullMinicipalInfoByAddressTest(AddressRequest address = null)
        {
            var service = new GovernmentService();

            if (address == null) RequestAddress(out address);

            //Get Municipal Info
            var muni = service.GetMunicipalByAddress(address);
            if (muni == null) service.DisplayText("Municipal Not Found");
            service.DisplayText($"Municipal: {muni.MunicipalName}");

            service.DisplayText("Officials");
            //Get Officials
            var officials = service.GetOfficialsByMunicipalNumber(muni.MunicipalNumber).OrderBy(o => o.FullName).ToList();
            officials.ForEach(o => { Console.WriteLine($"{o.Position}: {o.FullName}"); });


            Console.ReadLine();
        }

        private static void GetFullMinicipalInfoByNameTest(string name)
        {
            var service = new GovernmentService();

            //Get Municipal Info
            var muni = service.GetMunicipalByName(name);
            if (muni == null)
            {
                service.DisplayText("Municipal Not Found");
                return;
            }
            service.DisplayText($"Municipal: {muni.MunicipalName}");

            service.DisplayText("Officials");
            //Get Officials
            var officials = service.GetOfficialsByMunicipalNumber(muni.MunicipalNumber).OrderBy(o => o.Position).ToList();
            officials.ForEach(o => { Console.WriteLine($"{o.Position}: {o.FullName}"); });
        }

        private static void GetOfficialsByMunicipalTest(string number)
        {
            var service = new GovernmentService();

            var officials = service.GetOfficialsByMunicipalNumber(number).OrderBy(o => o.FullName).ToList();

            officials.ForEach(o => { Console.WriteLine($"{o.Position}: {o.FullName}"); });

            Console.ReadLine();
        }

        private static void GetMunicipalByAddressTest(AddressRequest address = null)
        {
            var service = new GovernmentService();

            if (address == null) RequestAddress(out address);

            var muni = service.GetMunicipalByAddress(address);

            if (muni == null) service.DisplayText("Municipal Not Found");

            service.DisplayText($"Municipal: {muni.MunicipalName}");

            Console.ReadLine();
        }

        private static void RequestAddress(out AddressRequest address)
        {
            Console.Write("Enter StreetAddress 1: ");
            var s1 = Console.ReadLine().Trim();
            Console.Write("Enter StreetAddress 2: ");
            var s2 = Console.ReadLine().Trim();
            Console.Write("City: ");
            var city = Console.ReadLine().Trim();
            Console.Write("Zipcode: ");
            var zip = Console.ReadLine().Trim();

            address = new AddressRequest { StreetAddress = s1, StreetAddress2 = s2, City = city, ZipCode = zip };
        }

        private static void GeneralTest()
        {
            var service = new GovernmentService();

            var munis = service.GetMunicipalities();
            var adds = service.GetAddresses();
            var offs = service.GetOfficials();

            service.DisplayText("MUNICIPALITIES");

            foreach (var item in munis)
            {
                Console.WriteLine($"#{item.MunicipalNumber} Name: {item.MunicipalName}");
            }

            service.DisplayText("OFFICIALS");

            foreach (var item in offs)
            {
                Console.WriteLine($"Position: {item.Position} Name: {item.FullName}");
            }

            service.DisplayText("ADDRESSES");

            foreach (var item in adds)
            {
                Console.WriteLine($"{item.MailingAddressLine1} {item.MailingAddressLine2}, {item.City}, {item.State} {item.Zip}");
            }

            Console.ReadLine();
        }
    }
}
