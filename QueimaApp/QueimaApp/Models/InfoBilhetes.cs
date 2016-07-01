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
    public class InfoBilhetes
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

    }
}
