using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Officials")]
    public class Official
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int MunicipalityId { get; set; }
    }
}
