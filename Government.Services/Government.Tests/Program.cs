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

            AddTestGovFiles();

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
                new Data.GovernmentFile
                {
                    FileId = "5122",
                    Type = "Resolution",
                    RequestingDepartment = " Department of FireRescue",
                    Date = DateTime.Parse("12/11/2018"),
                    CommissionMeetingDate = DateTime.Parse("01/10/2019"),
                    MunicipalNumber = "01",
                    Name = "Accept Supplemental Funding - FEMA and USAR",
                    Subject = "Accept Supplemental Funding - FEMA and USAR",
                    PurposeOfItem = "A Resolution of the City of Miami authorizing the City Manager to accept supplemental funding in the amount of $17,507.00, from the Department of " +
                    "Homeland Security, Federal Emergency Management Agency (“FEMA”), for the FY 2017 Cooperative Agreement for the Florida Urban Search and Rescue(“USAR”) Task Force " +
                    "thereby increasing Special Revenue Project “FY 2017 – Department of Homeland Security, Federal Emergency Management Agency(“FEMA”) – Urban Search and Rescue (“USAR”) " +
                    "Readiness Cooperative Agreement” from $1, 202, 013.00, previously awarded under Resolution 17 - 0502, to $1, 219, 520.00",
                    BackgroundItem = "The Department of Homeland Security has annually awarded a grant to the South Florida Urban Search and Rescue (“USAR”) Task Force 2, for the continued " +
                    "operation of the City’s USAR Program.Said grant award for Fiscal Year 2017 is in an amount not to exceed $1, 202, 013.00, commencing September 1st, 2017 thru August " +
                    "31st, 2020.At this time, FEMA is appropriating supplemental funds in the amount of $17, 507.00.It is now appropriate to accept said supplemental funding thereby " +
                    "increasing the existing special revenue project, and appropriate funds in an amount not to exceed $17, 507.00, therein for said fiscal year.",
                    BudgetImpactAnalysis = "Item is NOT Related to Revenue Item is NOT funded by Bonds",
                    TotalFiscalImpact = "$ 17,507.00 Start Up Capital Cost:$17,507.00",
                    CreatedBy = "rhomere"
                }
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
                if (string.IsNullOrWhiteSpace(name)) RequestName(service, out name);
                Console.WriteLine("Processing...");
                GetFullMinicipalInfoByNameTest(name);

                 //Exit
                 var contCheck = true;
                while (contCheck)
                {
                    service.DisplayText("Menu");
                    Console.WriteLine("1) GovernmentFiles");
                    Console.WriteLine("2) GovernmentFiles By Official");
                    Console.WriteLine("3) Another Municipality");
                    Console.WriteLine("4) Exit");
                    Console.WriteLine();
                    var answer = Console.ReadLine().Trim();
                    
                    switch (answer)
                    {
                        case "1":
                            contCheck = false;
                            GetGovernmentFiles(name);
                            break;
                        case "2":
                            contCheck = false;
                            GetOfficial(name);
                            break;
                        case "3":
                            contCheck = false;
                            break;
                        case "4":
                            Console.WriteLine("Goodbye");
                            contCheck = false;
                            check = false;
                            break;
                        default:
                            contCheck = true;
                            Console.WriteLine();
                            break;
                    }
                    name = string.Empty;
                    answer = string.Empty;
                }
            }
        }

        private static void GetGovernmentFiles(string name)
        {
            var service = new GovernmentService();
            var muni = service.GetMunicipalByName(name);
            var files = service.GetGovFilesByMunicipalNumber(muni.MunicipalNumber);

            service.DisplayText("GovernmentFiles");

            if (files.Count() == 0)
            {
                Console.WriteLine("Files Not Found");
            }
            else
            {
                var index = 1;

                files.ForEach(f => 
                {
                    Console.WriteLine($"{index}) {f.Name} {f.Description}");
                    index++;
                });
            }

            Console.WriteLine();
        }

        private static void GetOfficial(string name)
        {
            var service = new GovernmentService();
            var result = 0;
            var check = true;
            var initial = true;
            //Get Municipal Info
            var muni = service.GetMunicipalByName(name);
            var officials = service.GetOfficialsByMunicipalNumber(muni.MunicipalNumber);

            while (check)
            {
                if (initial)
                {
                    service.DisplayText("Choose an official");
                    for (int i = 0; i < officials.Count(); i++)
                    {
                        Console.WriteLine($"{i+1}) {officials[i].Position} {officials[i].FullName}");
                    }
                    Console.WriteLine();
                    initial = false;
                }
                else
                {
                    Console.Write("Choose an official: ");
                }
                
                var answer = Console.ReadLine().Trim();

                if (int.TryParse(answer, out result) && result <= officials.Count() - 1)
                {
                    check = false;
                    GovernmentFilesByOfficial(service, officials[result-1].Id);
                }
            }
            
            
        }

        private static void GovernmentFilesByOfficial(GovernmentService service, int id)
        {
            service.DisplayText("Government Files");
            var files = service.GetGovernmentFilesByOfficialId(id);

            if (files.Count() == 0)
            {
                Console.WriteLine("Files Not Found");
                return;
            }
            else
            {
                var index = 1;
                files.ForEach(f => 
                {
                    Console.WriteLine($"{index}) {f.Name} {f.Description}");
                    index++;
                });
            }
        }

        private static void RequestName(GovernmentService service, out string name)
        {
            var check = true;
            name = string.Empty;

            while (check)
            {
                Console.Write("\nCity Name? ");
                name = Console.ReadLine().Trim();
                var muni = service.GetMunicipalByName(name);
                if (muni != null)
                {
                    check = false;
                }
            }
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

        private static bool GetFullMinicipalInfoByNameTest(string name)
        {
            var service = new GovernmentService();

            //Get Municipal Info
            var muni = service.GetMunicipalByName(name);
            if (muni == null)
            {
                service.DisplayText("Municipal Not Found");
                return false;
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.WriteLine("              ");

            service.DisplayText($"Municipal: {muni.MunicipalName}");

            service.DisplayText("Officials");
            //Get Officials
            var officials = service.GetOfficialsByMunicipalNumber(muni.MunicipalNumber).OrderBy(o => o.Position).ToList();
            officials.ForEach(o => { Console.WriteLine($"{o.Position}: {o.FullName}"); });

            //Get GovernmentFiles 
            //service.DisplayText("Government Files");
            //var files = service.GetGovFilesByMunicipalNumber(muni.MunicipalNumber);
            //files.ForEach(f => { Console.WriteLine($"{f.Name}, {f.Description}"); });
            return true;
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
