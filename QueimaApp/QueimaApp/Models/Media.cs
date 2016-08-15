using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    public class Media
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int TipoMedia { get; set; }

    } 
    public enum TipoMedia
    {
        [Display(Description = "Álbum de Fotos")]
        Foto,
        [Display(Description = "Vídeo")]
        Video
    }
}
