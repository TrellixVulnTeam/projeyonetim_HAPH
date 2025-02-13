﻿using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Acme.SimpleTaskApp.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos
{
    public class GorevDto
    {
        public int GorevId { get; set; }

        public string GorevTanimi { get; set; }
        public DurumEnum Durum { get; set; }

        public int? DeveloperId { get; set; }
        public int? ProjeID { get; set; }
        public DateTime BaslamaZamani { get; set; }

    }

}
