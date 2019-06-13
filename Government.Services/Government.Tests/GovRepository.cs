using Government.Data;
using Government.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = Government.Data.Address;
using GovernmentFile = Government.Data.GovernmentFile;
using Official = Government.Data.Official;

namespace Government.Tests
{
    public class GovRepository
    {
        public GovRepository()
        {

        }

        public List<Municipal> GetMunicipalities()
        {
            using (var context = new CityEntities())
            {
                return context.Municipalities.ToList();
            }
        }

        public List<Official> GetOfficials()
        {
            using (var context = new CityEntities())
            {
                return context.Officials.ToList();
            }
        }

        public List<Address> GetAddresses()
        {
            using (var context = new CityEntities())
            {
                return context.Addresses.ToList();
            }
        }

        public Municipal GetMunicipalityByAddress(AddressRequest address)
        {
            using(var context = new CityEntities())
            {
                var municipalNumber = context.Addresses.FirstOrDefault(a => a.SiteAddress == address.StreetAddress &&
                                                                    a.SiteCity.Contains(address.City) &&
                                                                    a.SiteZip.Contains(address.ZipCode)).MunicipalNumber;

                if (municipalNumber == null) throw new Exception("Municipality Not Found");

                return context.Municipalities.FirstOrDefault(m => m.MunicipalNumber == municipalNumber);
            }
        }

        public List<Official> GetOfficialsByMunicipalNumber(string number)
        {
            using (var context = new CityEntities())
            {
                return context.Officials.Where(o => o.MunicipalNumber == number).ToList();
            }
        }

        public Municipal GetMunicipalByName(string name)
        {
            using(var context = new CityEntities())
            {
                return context.Municipalities.FirstOrDefault(m => m.MunicipalName.Contains(name));
            }
        }

        public List<GovernmentFile> GetGovFilesByMunicipalNumber(string number)
        {
            using(var context = new CityEntities())
            {
                return context.GovernmentFiles.Where(f => f.MunicipalNumber == number).ToList();
            }
        }

        public void AddGovFilesTest(List<GovernmentFile> files)
        {
            files.ForEach(f =>
            {
                using (var context = new CityEntities())
                {
                    context.GovernmentFiles.Add(f);
                    context.SaveChanges();
                }
            });
        }

        public void AddOfficialXGovFilesTest(List<OfficialXGovFile> files)
        {
            files.ForEach(f =>
            {
                using (var context = new CityEntities())
                {
                    context.OfficialXGovFiles.Add(f);
                    context.SaveChanges();
                }
            });
        }
    }
}
