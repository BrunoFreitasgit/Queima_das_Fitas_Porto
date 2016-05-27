using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class AtividadeAcademicaPageModel : FreshBasePageModel
    {
        IDatabaseService _dataService;
        public AtividadeAcademica AtividadeAcademica { get; set; }
        public bool IsPrecoVisible { get; set; }
        public bool IsPontoVendaVisible { get; set; }
        public string Titulo { get; set; }
        public AtividadeAcademicaPageModel(IDatabaseService dataService)
        {
            _dataService = dataService;
        }
        public AtividadeAcademicaPageModel(){}

        public override void Init(object initData)
        {
            if (initData != null)
            {
                AtividadeAcademica = (AtividadeAcademica)initData;
                Titulo = AtividadeAcademica.Nome;
                if (!string.IsNullOrEmpty(AtividadeAcademica.Preço))
                {
                    IsPrecoVisible = true;
                    IsPontoVendaVisible = true;
                }
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
