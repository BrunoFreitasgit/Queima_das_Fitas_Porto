using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    public class Concurso
    {
        public int Id { get; set; }
        public TipoConcurso TipoConcurso { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public string Url { get; set; }
    }

    public enum TipoConcurso
    {
        Cartaz,
        DJ,
        Bandas,
        Passatempo
    }
}
