using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace QueimaApp.Models
{
    [Table("AtividadeAcademica")]
    [ImplementPropertyChanged]
    public class AtividadeAcademica
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double LocalLatitude { get; set; }
        public double LocalLongitude { get; set; }
        public string Preco { get; set; }
        public string Data { get; set; }
        public string ImagePath { get; set; }
        public string PontosVenda { get; set; }
        public string Local { get; set; }
        public AtividadeAcademica()
        {
            
        } 
    }
}
