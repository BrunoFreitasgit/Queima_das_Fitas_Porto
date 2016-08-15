﻿using QueimaApp.Interfaces;
using QueimaApp.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.DataAccess
{
    public class QueimaRepository
    {
        SQLiteConnection dbConn;
        public QueimaRepository()
        {
            // Construtor testes locais
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
            dbConn.DropTable<Bilheteira>();
            dbConn.DropTable<Media>();
            dbConn.DropTable<Transporte>();
        }

        private void createTables()
        {
            dbConn.CreateTable<AtividadeAcademica>();
            dbConn.CreateTable<Artista>();
            dbConn.CreateTable<Concurso>();
            dbConn.CreateTable<Bilheteira>();
            dbConn.CreateTable<Media>();
            dbConn.CreateTable<Transporte>();
        }
        public List<AtividadeAcademica> GetAllAtividades()
        {
            return dbConn.Query<AtividadeAcademica>("Select * From [AtividadeAcademica]");
        }
        public List<Artista> GetArtistaByPalco(int p)
        {
            string palco;
            if (p == 0) palco = "Palco Principal";
            else palco = "Discoteca";

            var filtred_artistas = new List<Artista>();

            filtred_artistas = (from a in dbConn.Table<Artista>()
                                where a.Palco.Equals(palco)
                                select a).ToList<Artista>();

            return filtred_artistas;
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
                    Palco = 0,
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
                    Palco = 0,
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
                    Palco = 0,
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
                    Palco =0,
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
                    Palco = 1,
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
                    Palco = 0,
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
                    Palco = 0,
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
                    Palco =0,
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
                    Palco = 1,
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
                    Palco = 0,
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
                    Palco = 0,
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
                    Palco = 0,
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
                    Palco = 0,
                    FacebookUrl = "https://www.facebook.com/FAP1989",
                    SpotifyUrl = "spotify:artist:44gRHbEm4Uqa0ykW0rDTNk",
                    TwitterUrl = "https://twitter.com/skunkanansie",
                    ImagemUri = "http://www.suasletras.com/fotos_artista/50bbf37db0a64f5c659e1371731d6226.jpg"
                },
            };
            dbConn.InsertAll(artistas);
        }
    }
}
