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
        List<Contact> GetContacts();

        void UpdateContact(Contact contact);

        List<Quote> GetQuotes();

        void UpdateQuote(Quote quote);

        List<AtividadeAcademica> GetAtividades();

    }
}
