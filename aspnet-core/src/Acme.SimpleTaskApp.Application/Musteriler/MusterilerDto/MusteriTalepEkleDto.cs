﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Musteriler.MusterilerDto
{
    public class MusteriTalepEkleDto
    {
        public int? ProjeId { get; set; }
        public string MusteriTalep { get; set; }
        public DateTime BaslamaTarihi { get; set; }    

    }
}
