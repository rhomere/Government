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

        public Municipal GetMunicipalityByOfficialId(int id)
        {
            using (var context = new CityEntities())
            {
                var official = context.Officials.FirstOrDefault(o => o.Id == id);

                if (official == null) throw new Exception ("Official Not Found");

                return context.Municipalities.First(m => m.MunicipalNumber == official.MunicipalNumber);
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

        public List<OfficialXGovFile> GetOffXGovFileByOfficialId(int id)
        {
            using (var context = new CityEntities())
            {
                return context.OfficialXGovFiles.Where(f => f.OfficialId == id).ToList();
            }
        }

        public List<GovernmentFile> GetGovernmentFilesByOfficialId(int id)
        {
            var list = new List<GovernmentFile>();
            using (var context = new CityEntities())
            {
                var offXGovFiles = context.OfficialXGovFiles.Where(f => f.OfficialId == id && f.ISDELETED == false).Select(f => f.GovernmentFileId).ToList();
                list.AddRange(context.GovernmentFiles.Where(g => offXGovFiles.Contains(g.Id)).ToList());
                return list;
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
