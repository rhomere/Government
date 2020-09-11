using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GovWebApp.Mvc.Core.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        public int? CityId { get; set; }
        [Required]
        public int MunicipalityId { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
    }
}
