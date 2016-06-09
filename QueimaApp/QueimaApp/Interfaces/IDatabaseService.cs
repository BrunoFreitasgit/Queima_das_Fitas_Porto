using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Interfaces
{
    public interface IDatabaseService
    {
        List<AtividadeAcademica> GetAtividades();
        List<PontoVenda> GetPontosVenda();
        List<Barraca> GetBarracas();
        List<Bilhete> GetBilhetes();
        List<Artista> GetArtistas();
        List<Artista> GetArtistasByPalco(Palco p);
    }
}
