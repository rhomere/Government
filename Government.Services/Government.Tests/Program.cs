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

            MunicipalLookUp("");

            //AddTestGovFiles();

            //AddTestOfficialXGovFiles();

            //GetGovFilesByMunicipalNumberTest("");
        }

        private static void AddTestOfficialXGovFiles()
        {
            var list = new List<Data.OfficialXGovFile>
            {
                new Data.OfficialXGovFile { OfficialId = 1, GovernmentFileId = 1, CreatedBy = "rhomere" },
                new Data.OfficialXGovFile { OfficialId = 2, GovernmentFileId = 1, CreatedBy = "rhomere" },
                new Data.OfficialXGovFile { OfficialId = 3, GovernmentFileId = 1, CreatedBy = "rhomere" },
                new Data.OfficialXGovFile { OfficialId = 4, GovernmentFileId = 1, CreatedBy = "rhomere" },
                new Data.OfficialXGovFile { OfficialId = 5, GovernmentFileId = 1, CreatedBy = "rhomere" },
                new Data.OfficialXGovFile { OfficialId = 5, GovernmentFileId = 1, CreatedBy = "rhomere" }
            };

            var service = new GovernmentService();

            service.AddOfficialXGovFilesTest(list);
        }

        private static void AddTestGovFiles()
        {
            var list = new List<Data.GovernmentFile>
            {
                new Data.GovernmentFile { MunicipalNumber = "01", Name = "File 1", Description = "File 1 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "01", Name = "File 2", Description = "File 2 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "02", Name = "File 3", Description = "File 3 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "02", Name = "File 4", Description = "File 4 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "03", Name = "File 5", Description = "File 5 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "03", Name = "File 6", Description = "File 6 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "04", Name = "File 7", Description = "File 7 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "04", Name = "File 8", Description = "File 8 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "05", Name = "File 9", Description = "File 9 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "05", Name = "File 10", Description = "File 10 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "06", Name = "File 11", Description = "File 11 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "06", Name = "File 12", Description = "File 12 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "07", Name = "File 13", Description = "File 13 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "07", Name = "File 14", Description = "File 14 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "08", Name = "File 15", Description = "File 15 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "08", Name = "File 16", Description = "File 16 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "09", Name = "File 17", Description = "File 17 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "09", Name = "File 18", Description = "File 18 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "10", Name = "File 19", Description = "File 19 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "10", Name = "File 20", Description = "File 20 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "11", Name = "File 21", Description = "File 21 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "11", Name = "File 22", Description = "File 22 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "12", Name = "File 23", Description = "File 23 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "12", Name = "File 24", Description = "File 24 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "13", Name = "File 25", Description = "File 25 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "13", Name = "File 26", Description = "File 26 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "14", Name = "File 27", Description = "File 27 Description", CreatedBy = "rhomere" },
                new Data.GovernmentFile { MunicipalNumber = "14", Name = "File 28", Description = "File 28 Description", CreatedBy = "rhomere" }
            };

            var service = new GovernmentService();

            service.AddGovFilesTest(list);
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

            govFiles.ForEach(f => { Console.WriteLine($"Name: {f.Name}\n{f.Description}\n\n)"); });
        }

        private static void MunicipalLookUp(string name = null)
        {
            var service = new GovernmentService();

            var check = true;
            while (check)
            {
                if (string.IsNullOrWhiteSpace(name)) RequestName(out name);
                GetFullMinicipalInfoByNameTest(name);
                name = string.Empty;
                //Exit
                var contCheck = true;
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

            service.DisplayText("Government Files");
            //Get GovernmentFiles 
            var files = service.GetGovFilesByMunicipalNumber(muni.MunicipalNumber);
            files.ForEach(f => { Console.WriteLine($"{f.Name}, {f.Description}"); });
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
