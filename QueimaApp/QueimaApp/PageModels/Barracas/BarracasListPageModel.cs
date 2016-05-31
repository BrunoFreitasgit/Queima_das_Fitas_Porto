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
    public class BarracasListPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        private ObservableCollection<Barraca> _barracas;
        public ObservableCollection<Barraca> Barracas
        {
            get
            {
                ObservableCollection<Barraca> theCollection = new ObservableCollection<Barraca>();
                if (_barracas != null)
                {
                    List<Barraca> entities = (from e in _barracas
                                                 where e.Nome.ToLower().Contains(_searchText.ToLower())
                                                 select e).ToList<Barraca>();
                    if (entities != null && entities.Any())
                    {
                        theCollection = new ObservableCollection<Barraca>(entities);
                    }
                }
                return theCollection;
            }
        }

        Barraca _selectedBarraca;
        private string _searchText = string.Empty;
        private Command _searchCommand;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value ?? string.Empty;
                    if (SearchCommand.CanExecute(null))
                    {
                        SearchCommand.Execute(null);
                    }
                }
            }
        }

        public BarracasListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override void Init(object initData)
        {
            _barracas = new ObservableCollection<Barraca>(_databaseService.GetBarracas());
        }

        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        public Barraca SelectedBarraca
        {
            get
            {
                return _selectedBarraca;
            }
            set
            {
                _selectedBarraca = value;
                if (value != null)
                {
                    BarracaSelected.Execute(value);
                }

            }
        }

        public Command<Barraca> BarracaSelected
        {
            get
            {
                return new Command<Barraca>(async (barraca) =>
                {
                    await CoreMethods.PushPageModel<BarracaPageModel>(barraca);
                    _selectedBarraca = null;
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private bool CanExecuteSearchCommand(object arg)
        {
            return true;
        }
        private void DoSearchCommand(object obj)
        {
            
        }
    }
}
