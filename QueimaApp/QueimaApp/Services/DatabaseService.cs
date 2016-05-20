using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Services
{
    public class DatabaseService : IDatabaseService
    {
        private List<Contact> _contacts;
        private List<Quote> _quotes;
        private List<AtividadeAcademica> _atividades;

        public DatabaseService()
        {
            _contacts = InitContacts();
            _quotes = InitQuotes();
            _atividades = InitAtividades();
        }


        public void UpdateContact(Contact contact)
        {
            if (contact.Id == 0)
            {
                contact.Id = _contacts.Count + 1;
                _contacts.Add(contact);
            }
            else
            {
                var oldContact = _contacts.Find(c => c.Id == contact.Id);
                oldContact.Name = contact.Name;
                oldContact.Phone = contact.Phone;
            }
        }

        public void UpdateQuote(Quote quote)
        {
            if (quote.Id == 0)
            {
                quote.Id = _quotes.Count + 1;
                _quotes.Add(quote);
            }
            else
            {
                var oldQuote = _quotes.Find(c => c.Id == quote.Id);
                oldQuote.CustomerName = quote.CustomerName;
                oldQuote.Total = quote.Total;
            }
        }

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public List<Quote> GetQuotes()
        {
            return _quotes;
        }

        private List<Contact> InitContacts()
        {
            return new List<Contact> {
                new Contact { Id = 1, Name = "Xam Consulting", Phone = "0404 865 350" },
                new Contact { Id = 2, Name = "Michael Ridland", Phone = "0404 865 350" },
                new Contact { Id = 3, Name = "Thunder Apps", Phone = "0404 865 350" },
            };
        }

        private List<Quote> InitQuotes()
        {
            return new List<Quote> {
                new Quote { Id = 1, CustomerName = "Xam Consulting", Total = "$350.00" },
                new Quote { Id = 2, CustomerName = "Michael Ridland", Total = "$3503.00" },
                new Quote { Id = 3, CustomerName = "Thunder Apps", Total = "$3504.00" },
            };
        }
        private List<AtividadeAcademica> InitAtividades()
        {
            return new List<AtividadeAcademica>
           {
               new AtividadeAcademica {
                   Id = 1 , Nome = "Baile de Gala" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  32,
                   Longitude = 432,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 2 ,
                   Nome = "Chã Dançante" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.ChaDancante.jpg" ,
                   Latitude = 32 ,
                   Longitude = 321,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 3 ,
                   Nome = "Cortejo Académico" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  21,
                   Longitude =32 ,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 4 ,
                   Nome = "Dia da Beneficiência" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  311,
                   Longitude = 31,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 5 ,
                   Nome = "Monumental Serenata" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  332,
                   Longitude = 332,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 6 ,
                   Nome = "Missa da Benção das Pastas" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  32,
                   Longitude = 12,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 7 ,
                   Nome = "ECAP" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude =  44,
                   Longitude = 13,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 8,
                   Nome = "Concerto Promenade" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude = 31 ,
                   Longitude = 31,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 9 ,
                   Nome = "XXX FITA" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude = 56 ,
                   Longitude = 54,
                   Data = "4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 10 ,
                   Nome = "Sarau Cultural" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.Sarau.jpg" ,
                   Latitude =  32,
                   Longitude = 32,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
               new AtividadeAcademica {
                   Id = 11 ,
                   Nome = "RallyPaper" ,
                   Descricao = "O Festival Ibérico de Tunas Académicas proporciona, para além do espetáculo, um ambiente de convívio entre tunas, estudantes, finalistas e entusiastas da cidade do Porto. Inserido no programa da Queima das Fitas do Porto, o FITA afirmou-se nos últimos anos como um dos maiores e mais enérgicos festivais de tunas do país." ,
                   Preço = "3,00€" ,
                   ImagePath = "QueimaApp.Images.AtividadesAcademicas.BaileGala.jpg" ,
                   Latitude = 43 ,
                   Longitude = 423,
                   Data ="4 de maio às 20:01",
                   Local ="Coliseu do Porto",
                   PontoVenda = "Coliseu do Porto, FAP e Campus S. João"
               },
            };
        }

        public List<AtividadeAcademica> GetAtividades()
        {
            return _atividades;
        }
    }
}
