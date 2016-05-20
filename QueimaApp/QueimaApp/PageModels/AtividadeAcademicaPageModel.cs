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
    public class AtividadeAcademicaPageModel : FreshBasePageModel
    {
        IDatabaseService _dataService;
        public AtividadeAcademica AtividadeAcademica { get; set; }

        public AtividadeAcademicaPageModel(IDatabaseService dataService)
        {
            _dataService = dataService;

            this.WhenAny(HandleContactChanged, o => o.AtividadeAcademica);
        }
        void HandleContactChanged(string propertyName)
        {
            //handle the property changed, nice
        }

        public override void Init(object initData)
        {
            if (initData != null)
            {
                AtividadeAcademica = (AtividadeAcademica)initData;
            }
            else
            {
                AtividadeAcademica = new AtividadeAcademica();
            }
        }
    }
}
