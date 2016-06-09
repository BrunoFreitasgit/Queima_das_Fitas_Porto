using Newtonsoft.Json;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QueimaApp.Services
{
    public class DatabaseService : IDatabaseService
    {

        private List<AtividadeAcademica> _atividades;
        private List<PontoVenda> _pontosVenda;
        private List<Barraca> _barracas;
        private List<Bilhete> _bilhetes;
        private List<Artista> _artistas;
        public DatabaseService()
        {
            _atividades = InitAtividades();
            _pontosVenda = InitPontosVenda();
            _barracas = InitBarracas();
            _bilhetes = InitBilhetes();
            _artistas = InitArtistas();
        }

        private List<AtividadeAcademica> InitAtividades()
        {
            return new List<AtividadeAcademica>
           {
               new AtividadeAcademica {
                   Id = 1 ,
                   Nome = "Baile de Gala" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "BaileGala_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 2 ,
                   Nome = "Chá Dançante" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "ChaDancante_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = ""
               },
               new AtividadeAcademica {
                   Id = 3 ,
                   Nome = "Cortejo Académico" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "" ,
                   ImagePath = "Cortejo_tb.jpg" ,
                    Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = ""
               },
               new AtividadeAcademica {
                   Id = 4 ,
                   Nome = "Dia da Beneficiência" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "DiaBeneficiencia_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 5 ,
                   Nome = "Monumental Serenata" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "MonumentalSerenata_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 6 ,
                   Nome = "Missa da Benção das Pastas" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "MissaBencao_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 7 ,
                   Nome = "ECAP" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "ECAP_tb.jpg" ,
                  Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 8,
                   Nome = "Concerto Promenade" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "Promenade_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 9 ,
                   Nome = "XXX FITA" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "" ,
                   ImagePath = "FITA_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data = "4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 10 ,
                   Nome = "Sarau Cultural" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "Sarau_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 11 ,
                   Nome = "RallyPaper" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "RallyPaper_tb.jpg" ,
                   Latitude =  41.146974,
                   Longitude = -8.604990,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               }
            };
        }

        public List<AtividadeAcademica> GetAtividades()
        {
            return _atividades;
        }
        private List<PontoVenda> InitPontosVenda()
        {
            return new List<PontoVenda>
            {
                new PontoVenda
                {
                    Id = 1 ,
                    Nome = "Campus S.João",
                    Info = "dsadsadsada",
                    Latitude = 32,
                    Longitude = 55,
                    Local = "Rua Teste 1"
                },
                new PontoVenda
                {
                    Id = 2 ,
                    Nome = "Federação Académica do Porto",
                    Info = "dsadsadsada",
                    Latitude = 32,
                    Longitude = 55,
                    Local = "Rua Teste 2"
                },
                new PontoVenda
                {
                    Id = 3 ,
                    Nome = "El Corte Inglés",
                    Info = "dsadsadsada",
                    Latitude = 32,
                    Longitude = 55,
                    Local = "Rua Teste 3"
                },
                new PontoVenda
                {
                    Id = 4 ,
                    Nome = "Queimódromo",
                    Info = "dsadsadsada",
                    Latitude = 32,
                    Longitude = 55,
                    Local = "Rua Teste 4"
                }
            };
        }
        public List<PontoVenda> GetPontosVenda()
        {
            return _pontosVenda;
        }
        private List<Barraca> InitBarracas()
        {
            var assembly = typeof(DatabaseService).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QueimaApp.Json_test.barracas.json");

            List<Barraca> myData;
            using (var reader = new System.IO.StreamReader(stream))
            {
                //var myDa2ta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Barraca>>(reader);
                JsonSerializer serializer = new JsonSerializer();
                myData = (List<Barraca>)serializer.Deserialize(reader, typeof(List<Barraca>));
            }
            return myData;
        }
        public List<Barraca> GetBarracas()
        {
            return _barracas;
        }
        private List<Bilhete> InitBilhetes()
        {
            //TODO
            return new List<Bilhete>();
        }
        public List<Bilhete> GetBilhetes()
        {
            return _bilhetes;
        }

        private List<Artista> InitArtistas()
        {
            return new List<Artista>
            {
                new Artista
                {
                    Id = 1,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,01),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                 new Artista
                {
                    Id = 2,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,01),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                  new Artista
                {
                    Id = 3,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                   new Artista
                {
                    Id = 4,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                    new Artista
                {
                    Id = 5,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,02),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                     new Artista
                {
                    Id = 6,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,03),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                      new Artista
                {
                    Id = 7,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,04),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                       new Artista
                {
                    Id = 8,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,04),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                        new Artista
                {
                    Id = 9,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,05),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                         new Artista
                {
                    Id = 10,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,05),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                          new Artista
                {
                    Id = 11,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,06),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                           new Artista
                {
                    Id = 12,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher.... Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,06),
                    Nome = "Artista 1",
                    Palco = Palco.PalcoPrincipal,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
                            new Artista
                {
                    Id = 13,
                    Biografia = "Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher Isto é uma biografia enorme, é capaz de ter trezentas linhas de texto só para encher ",
                    Data = new DateTime(2017,05,07),
                    Nome = "Artista 1",
                    Palco = Palco.Discoteca,
                    FacebookLink = "https://www.facebook.com/FAP1989",
                    SpotifyLink = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterLink = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
            };
        }
        public List<Artista> GetArtistas()
        {
            return _artistas;
        }
        public List<Artista> GetArtistasByPalco(Palco p)
        {
            var filtred_artistas = new List<Artista>();

            filtred_artistas = (from a in _artistas
                                where a.Palco.Equals(p)
                                select a).ToList<Artista>();
            return filtred_artistas;
        }

    }
}
