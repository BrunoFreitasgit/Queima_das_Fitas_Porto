using FreshMvvm;
using Plugin.Connectivity;
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
        IQueimaRepository _repository;
        IRestService _restService;
        AtividadeAcademica _selectedAtividade;


        public AtividadesListPageModel(IQueimaRepository repo, IRestService restService)
        {
            _repository = repo;
            _restService = restService;
        }

        public ObservableCollection<AtividadeAcademica> Atividades { get; set; }

        public override void Init(object initData)
        {
            //Atividades = new ObservableCollection<AtividadeAcademica>(_databaseService.GetAtividades());
            Atividades = new ObservableCollection<AtividadeAcademica>(_repository.GetAllAtividades());

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
                IsBusy = true;
                return new Command<AtividadeAcademica>(async (atividade) =>
                {
                    await CoreMethods.PushPageModel<AtividadeAcademicaPageModel>(atividade);
                    _selectedAtividade = null;
                });
            }
        }

        public bool IsBusy { get; set; }
        Command refreshCommand;

        public Command RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;
            if (!CrossConnectivity.Current.IsConnected)
            {
                await CurrentPage.DisplayAlert("Erro", "Tem de ter uma conexão à Internet", "OK");
            }
            IsBusy = true;
            Atividades.Clear();

            var atividades_temp = await _restService.AtividadesRefreshAsync();
            if (atividades_temp != null)
            {
                _repository.SaveAtividades(atividades_temp);
            }


            IsBusy = false;

            await CurrentPage.DisplayAlert("Refreshed", "You just refreshed the page! Nice job!", "OK");
            return;

        }

    }
}
