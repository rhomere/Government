﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Models
{
    public class GovernmentFile : Base
    {
        public string MunicipalNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
