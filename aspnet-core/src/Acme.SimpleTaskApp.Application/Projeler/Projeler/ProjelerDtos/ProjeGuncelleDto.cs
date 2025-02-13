﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos
{
    public class ProjeGuncelleDto
    {
        public int? ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public string Description { get; set; }
        public int? MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime MusteriBitisTarihi { get; set; }
        public DateTime MusteriBaslamaTarihi { get; set; }
        public DurumEnum Durum { get; set; }

    }
}
