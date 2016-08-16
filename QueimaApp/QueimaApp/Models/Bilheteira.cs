using PropertyChanged;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    [Table("Bilheteira")]
    public class Bilheteira
    {
        [PrimaryKey]
        public int Id { get; set; }
        [OneToMany]
        public List<Bilhete> Bilhetes { get; set; } = new List<Bilhete>();
        public string Condicoes { get; set; } = string.Empty;
        public string IngressoSemanalUrl { get; set; } = string.Empty;
        public string PrecoIngressoSemanal { get; set; } = string.Empty;

        public Bilheteira()
        {
        }
    }
}
