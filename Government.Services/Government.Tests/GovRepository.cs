using Government.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
