using PropertyChanged;
using SQLite.Net.Attributes;
using System;


namespace QueimaApp.Models
{
    [Table("Artistas")]
    [ImplementPropertyChanged]
    public class Artista
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Biografia { get; set; }
        public Palco Palco { get; set; }
        public DateTime DataAtuacao { get; set; }
        public string ImagemUri { get; set; }
        public string FacebookUrl { get; set; }
        public string SpotifyUrl { get; set; }
        public string TwitterUrl { get; set; }
    }

    public enum Palco
    {
        PalcoPrincipal,
        Discoteca
    }
}
