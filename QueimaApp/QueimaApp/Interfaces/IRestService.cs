using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Interfaces
{
    public interface IRestService
    {
        Task<List<Transporte>> TransportesRefreshAsync();

        Task<List<Artista>> ArtistasRefreshAsync();

        Task<List<AtividadeAcademica>> AtividadesRefreshAsync();

        Task<Bilheteira> BilheteiraRefreshAsync();

        Task<List<Concurso>> ConcursosRefreshAsync();

        Task<List<Media>> MediaRefreshAsync();
    }
}
