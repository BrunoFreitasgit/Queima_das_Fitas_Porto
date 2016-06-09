using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class ArtistaPageModel : FreshBasePageModel
    {
        IDatabaseService _dataService;
        public Artista Artista { get; set; }
        public string Titulo { get; set; }
        public ArtistaPageModel(IDatabaseService dataService)
        {
            _dataService = dataService;
        }

        public override void Init(object initData)
        {
            if (initData != null)
            {
                Artista = (Artista)initData;
                Titulo = Artista.Nome;
            }
            else
            {
                Artista = new Artista();
            }
        }
    }
}
