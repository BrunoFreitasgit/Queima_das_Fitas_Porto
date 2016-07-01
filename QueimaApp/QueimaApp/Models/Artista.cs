
using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [Table("Artista")]
    [ImplementPropertyChanged]
    public class Artista
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Biografia { get; set; }
        public string Palco { get; set; }
        public DateTime Data { get; set; }
        public string ImagemUri { get; set; }
        public string FacebookLink { get; set; }
        public string SpotifyLink { get; set; }
        public string TwitterLink { get; set; }
    }

}
