using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Government.Data;
using Government.Models;
using Address = Government.Data.Address;
using GovernmentFile = Government.Data.GovernmentFile;
using Official = Government.Data.Official;

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

        public Municipal GetMunicipalByAddress(AddressRequest address)
        {
            return GovRepo.GetMunicipalityByAddress(address);
        }

        public List<Official> GetOfficialsByMunicipalNumber(string number)
        {
            return GovRepo.GetOfficialsByMunicipalNumber(number);
        }

        public Municipal GetMunicipalByName(string name)
        {
            return GovRepo.GetMunicipalByName(name);
        }

        public List<GovernmentFile> GetGovFilesByMunicipalNumber(string number)
        {
            return GovRepo.GetGovFilesByMunicipalNumber(number);
        }

        public void AddGovFilesTest(List<GovernmentFile> files)
        {
            GovRepo.AddGovFilesTest(files);
        }

        public void AddOfficialXGovFilesTest(List<OfficialXGovFile> files)
        {
            GovRepo.AddOfficialXGovFilesTest(files);
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
