using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class PontoVendaListPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        private readonly List<string> _allItems = new List<string>();
        private readonly ObservableCollection<string> _pontosVenda;
        public ObservableCollection<string> Items => _pontosVenda;
        public ObservableCollection<PontoVenda> PontosVenda { get; set; }
        public string SearchText { get; set; }
        PontoVenda _selectedPontoVenda;
        public ICommand SearchCommand { get; private set; }


        public PontoVendaListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            this.SearchCommand = new Command(this.ExecuteSearchCommand, this.CanExecuteSearchCommand);
        }
        public override void Init(object initData)
        {
            PontosVenda = new ObservableCollection<PontoVenda>(_databaseService.GetPontosVenda());
        }
        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            Debug.WriteLine("View is appearing");
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        public PontoVenda SelectedPontoVenda
        {
            get
            {
                return _selectedPontoVenda;
            }
            set
            {
                _selectedPontoVenda = value;
                if (value != null)
                    PontoVendaSelected.Execute(value);
            }
        }
        public Command<PontoVenda> PontoVendaSelected
        {
            get
            {
                return new Command<PontoVenda>(async (ponto) =>
                {
                    await CoreMethods.PushPageModel<PontoVendaPageModel>(ponto);
                });
            }
        }

        protected virtual bool CanExecuteSearchCommand()
        {
            return true;
        }

        protected virtual void ExecuteSearchCommand()
        {
            this.Items.Clear();
            IEnumerable<string> foundItems;
            if (string.IsNullOrEmpty(this.SearchText))
            {
                foundItems = _allItems;
            }
            else
            {
                foundItems = _allItems.Where(p => p.ToLower().Contains(this.SearchText.ToLower()));
            }
            foreach (var foundItem in foundItems)
            {
                this.Items.Add(foundItem);
            }
        }


    }
}
