using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    public class AtividadeAcademica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Preço { get; set; }
        public string Data { get; set; }
        public string ImagePath { get; set; }
        public string PontoVenda { get; set; }
        public string Local { get; set; }
        public AtividadeAcademica()
        {
            

        } 
    }
}
