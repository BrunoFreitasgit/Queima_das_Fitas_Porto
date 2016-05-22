﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    public class PontoVenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Info { get; set; }
        public PontoVenda()
        {
        }
    }
}
