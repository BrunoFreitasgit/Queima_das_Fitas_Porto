using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Interfaces
{
    public interface IQueimaRepository
    {
        List<AtividadeAcademica> GetAllAtividades();

        List<Concurso> GetConcursoByType(int c);

        List<Media> GetMediaByType(int t);

        Bilheteira GetBilheteira();

        List<Artista> GetArtistaByPalco(int p);

        Transporte GetTransporteByType(int t);

        void SaveAtividades(List<AtividadeAcademica> atividades);

        void SaveArtistas(List<Artista> artistas);

        void SaveConcursos(List<Concurso> Concursos);

        void SaveMedia(List<Media> media);

        void SaveTransportes(List<Transporte> transportes);

        void SaveBilheteiras(Bilheteira bilheteira);
    }
}
