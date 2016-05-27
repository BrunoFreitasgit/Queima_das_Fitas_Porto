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
        public ObservableCollection<Barraca> Barracas { get; set; }
        Barraca _selectedBarraca;
        public string SearchText { get; set; }
        public BarracasListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public override void Init(object initData)
        {
            Barracas = new ObservableCollection<Barraca>(_databaseService.GetBarracas());
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
        public Command<string> SearchCommand
        {
            get
            {
                return new Xamarin.Forms.Command<string>(DoSearchCommand, CanExecuteSearchCommand);
            }
        }

        private bool CanExecuteSearchCommand(object arg)
        {
            return true;
        }

        private void DoSearchCommand(object obj)
        {
            List<Barraca> entities = (from e in Barracas
                                      where e.Nome.Contains(SearchText)
                                      select e).ToList<Barraca>();
            if (entities != null && entities.Any())
            {
                Barracas = new ObservableCollection<Barraca>(entities);
            }
        }
    }
}
