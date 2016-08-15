
using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [Table("Bilhete")]
    [ImplementPropertyChanged]
    public class Bilhete
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Data { get; set; }
        public string PrecoNormal { get; set; }
        public string PrecoDiaAnterior { get; set; }
        public string PrecoNoDia { get; set; }
        public string PrecoNoDiaForaHoras { get; set; }
        public string BilheteiraOnlineUrl { get; set; }
        public Bilhete()
        {
        }
    }
}
