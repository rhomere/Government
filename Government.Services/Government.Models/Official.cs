using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Models
{
    public class Official : Base
    {
        public string MunicipalNumber { get; set; }
        public string Position { get; set; }
        public string FullName { get; set; }
        public int District { get; set; }
    }
}
