using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [Table("Barracas")]
    [ImplementPropertyChanged]
    public class Barraca
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public string ImagePath { get; set; }
        public double Longitude { get; set; }
        public string FacebookEventURL { get; set; }
        public Barraca()
        {
                
        }
    }
}
