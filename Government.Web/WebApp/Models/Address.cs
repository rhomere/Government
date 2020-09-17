using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Addresses")]
    public class Address
    {
        public Guid Id { get; set; }
        public int? CityId { get; set; }
        public int MunicipalityId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
