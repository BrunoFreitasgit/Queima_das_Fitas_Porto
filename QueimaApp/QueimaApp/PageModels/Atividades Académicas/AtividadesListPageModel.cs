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
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class AtividadesListPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        AtividadeAcademica _selectedAtividade;

        public AtividadesListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ObservableCollection<AtividadeAcademica> Atividades { get; set; }

        public override void Init(object initData)
        {
            //Atividades = new ObservableCollection<AtividadeAcademica>(_databaseService.GetAtividades());
            Atividades = new ObservableCollection<AtividadeAcademica>(App.QueimaDA.GetAllAtividades());

        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        public override void ReverseInit(object value)
        {
            var newAtividade = value as AtividadeAcademica;
            if (!Atividades.Contains(newAtividade))
            {
                Atividades.Add(newAtividade);
            }
        }

        public AtividadeAcademica SelectedAtividade
        {
            get
            {
                return _selectedAtividade;
            }
            set
            {
                _selectedAtividade = value;
                if (value != null)
                    AtividadeSelected.Execute(value);
            }
        }

        public Command<AtividadeAcademica> AtividadeSelected
        {
            get
            {
                return new Command<AtividadeAcademica>(async (atividade) =>
                {
                    await CoreMethods.PushPageModel<AtividadeAcademicaPageModel>(atividade);
                    _selectedAtividade = null;
                });
            }
        }
    }
}
