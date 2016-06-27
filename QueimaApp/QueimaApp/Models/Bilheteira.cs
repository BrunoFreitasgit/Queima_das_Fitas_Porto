using PropertyChanged;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    public class Bilheteira
    {

        public int Id { get; set; }
        public List<PontoVenda> PontosVenda { get; set; }
        public List<Bilhete> Bilhetes { get; set; }
        public Bilheteira()
        { 
        }
    }
}
