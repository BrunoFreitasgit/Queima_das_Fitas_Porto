using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        }
        public AtividadeAcademicaPageModel()
        {
                
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
        public Command LocationCommand
        {
            get
            {
                return new Command(async () => {
                    // TODO
                    // PUSH MAPVIEW WITH COORDINATES
                    await CoreMethods.PushPageModel<AtividadeMapaPageModel>(AtividadeAcademica, true);
                }
                );
            }
        }
    }
}
