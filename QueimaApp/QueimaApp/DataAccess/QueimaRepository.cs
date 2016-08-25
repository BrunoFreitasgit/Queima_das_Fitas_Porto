using Newtonsoft.Json;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.DataAccess
{
    public class QueimaRepository : IQueimaRepository
    {
        SQLiteConnection dbConn;
        public QueimaRepository()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();

            // create the table(s)
            cleanDb();
            createTables();
            InitializeDataTest();
        }

        private void cleanDb()
        {
            dbConn.DropTable<AtividadeAcademica>();
            dbConn.DropTable<Artista>();
            dbConn.DropTable<Concurso>();
            dbConn.DropTable<Bilhete>();
            dbConn.DropTable<Bilheteira>();
            dbConn.DropTable<Media>();
            dbConn.DropTable<Transporte>();
        }

        private void createTables()
        {
            dbConn.CreateTable<AtividadeAcademica>();
            dbConn.CreateTable<Artista>();
            dbConn.CreateTable<Concurso>();
            dbConn.CreateTable<Bilhete>();
            dbConn.CreateTable<Bilheteira>();
            dbConn.CreateTable<Media>();
            dbConn.CreateTable<Transporte>();
        }

        public List<AtividadeAcademica> GetAllAtividades()
        {
            return dbConn.Query<AtividadeAcademica>("Select * From [AtividadesAcademicas]");
        }
        public List<Concurso> GetConcursoByType(int c)
        {
            var filtred_concurso = new List<Concurso>();

            filtred_concurso = (from a in dbConn.Table<Concurso>()
                                where a.TipoConcurso.Equals(c)
                                select a).ToList();

            return filtred_concurso;
        }
        public List<Media> GetMediaByType(int t)
        {
            var filtred_media = new List<Media>();

            filtred_media = (from a in dbConn.Table<Media>()
                             where a.TipoMedia.Equals(t)
                             select a).ToList();

            return filtred_media;
        }
        public Bilheteira GetBilheteira()
        {
            var table = dbConn.Table<Bilheteira>();

            var bilheteira = table.SingleOrDefault(b => b.Id != 0);

            return bilheteira;
        }
        public List<Artista> GetArtistaByPalco(int p)
        {
            var filtred_artistas = new List<Artista>();

            filtred_artistas = (from a in dbConn.Table<Artista>()
                                where a.Palco.Equals(p)
                                select a).ToList<Artista>();

            return filtred_artistas;
        }
        public Transporte GetTransporteByType(int t)
        {
            var filtred_transporte = new Transporte();
            TipoTransporte tt = (TipoTransporte)t;
            var table = dbConn.Table<Transporte>();

            filtred_transporte = table.Where(trans => trans.Nome == tt).Single();

            return filtred_transporte;
        }



        public void SaveAtividades(List<AtividadeAcademica> atividades)
        {
            dbConn.Delete("AtividadesAcademicas");
            dbConn.InsertAll(atividades);
        }
        public void SaveArtistas(List<Artista> artistas)
        {
            dbConn.Delete("Artistas");
            dbConn.InsertAll(artistas);
        }
        public void SaveConcursos(List<Concurso> Concursos)
        {
            dbConn.Delete("Concursos");
            dbConn.InsertAll(Concursos);
        }
        public void SaveMedia(List<Media> media)
        {
            dbConn.Delete("Media");
            dbConn.InsertAll(media);
        }
        public void SaveTransportes(List<Transporte> transportes)
        {
            dbConn.Delete("Transportes");
            dbConn.InsertAll(transportes);
        }
        public void SaveBilheteiras(Bilheteira bilheteira)
        {
            dbConn.Delete("Bilheteira");
            dbConn.Delete("Bilhetes");
            var bilhetes = bilheteira.Bilhetes;
            dbConn.InsertAll(bilhetes);
            dbConn.Insert(bilheteira);
        }

        void InitializeDataTest()
        {
            // ATIVIDADES ACADEMICAS
            var atividades = new List<AtividadeAcademica>
           {
               new AtividadeAcademica {
                   Id = 1 ,
                   Nome = "Baile de Gala" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "BaileGala_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 2 ,
                   Nome = "Chá Dançante" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "ChaDancante_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = ""
               },
               new AtividadeAcademica {
                   Id = 3 ,
                   Nome = "Cortejo Académico" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "" ,
                   ImagePath = "Cortejo_tb.jpg" ,
                    LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = ""
               },
               new AtividadeAcademica {
                   Id = 4 ,
                   Nome = "Dia da Beneficiência" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "DiaBeneficiencia_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 5 ,
                   Nome = "Monumental Serenata" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "MonumentalSerenata_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 6 ,
                   Nome = "Missa da Benção das Pastas" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "MissaBencao_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 7 ,
                   Nome = "ECAP" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "ECAP_tb.jpg" ,
                  LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 8,
                   Nome = "Concerto Promenade" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "Promenade_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 9 ,
                   Nome = "XXX FITA" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "" ,
                   ImagePath = "FITA_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data = "4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 10 ,
                   Nome = "Sarau Cultural" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "Sarau_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 11 ,
                   Nome = "RallyPaper" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preco = "3,00€" ,
                   ImagePath = "RallyPaper_tb.jpg" ,
                   LocalLatitude =  41.146974,
                   LocalLongitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontosVenda = "Coliseu do Porto, FAP e Campus S. João"
               }
            };
            dbConn.InsertAll(atividades);

            // ARTISTAS
            var artistas = new List<Artista>
            {
                new Artista
                {
                    Id = 1,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,01),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                 new Artista
                {
                    Id = 2,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,01),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                  new Artista
                {
                    Id = 3,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                   new Artista
                {
                    Id = 4,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                    new Artista
                {
                    Id = 5,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                     new Artista
                {
                    Id = 6,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,03),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                      new Artista
                {
                    Id = 7,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,04),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                       new Artista
                {
                    Id = 8,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,04),
                    Nome = "Artista 1",
                    Palco =Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                        new Artista
                {
                    Id = 9,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,05),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                         new Artista
                {
                    Id = 10,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,05),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                          new Artista
                {
                    Id = 11,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,06),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                           new Artista
                {
                    Id = 12,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,06),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                            new Artista
                {
                    Id = 13,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    DataAtuacao = new DateTime(2017,05,07),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
            };
            dbConn.InsertAll(artistas);


            // Concursos Teste local
            var assembly = typeof(QueimaRepository).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QueimaApp.Json_test.concursos.json");

            List<Concurso> myData;
            using (var reader = new StreamReader(stream))
            {

                JsonSerializer serializer = new JsonSerializer();
                myData = (List<Concurso>)serializer.Deserialize(reader, typeof(List<Concurso>));
            }
            dbConn.InsertAll(myData);
        }
    }
}
