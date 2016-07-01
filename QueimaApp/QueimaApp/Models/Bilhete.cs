
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
        public DateTime Data { get; set; }
        public decimal PrecoNormal { get; set; }
        public decimal PrecoDiaAnterior { get; set; }
        public decimal PrecoNoDia { get; set; }
        public decimal PrecoNoDiaApos { get; set; }
        public Bilhete()
        {
        }
    }
}
