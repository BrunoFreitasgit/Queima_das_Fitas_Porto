﻿using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    [Table("PontoVenda")]
    public class PontoVenda
    {
        [PrimaryKey]
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
