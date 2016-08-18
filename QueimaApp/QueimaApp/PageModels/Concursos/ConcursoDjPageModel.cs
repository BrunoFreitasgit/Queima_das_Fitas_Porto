using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class ConcursoDjPageModel : FreshBasePageModel
    {
        IQueimaRepository _repository;
        IRestService _restService;
        public Concurso Concurso { get; set; }

        public ConcursoDjPageModel(IQueimaRepository repo, IRestService restService)
        {
            _repository = repo;
            _restService = restService;
        }

        public override void Init(object initData)
        {
            var concursos = _repository.GetConcursoByType((int)TipoConcurso.DJ);
            Concurso = concursos.ElementAt(0);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

    }
}
