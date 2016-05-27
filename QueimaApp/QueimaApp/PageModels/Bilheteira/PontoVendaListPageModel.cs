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
        public ObservableCollection<PontoVenda> PontosVenda { get; set; }
        PontoVenda _selectedPontoVenda;


        public PontoVendaListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
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
                {
                    PontoVendaSelected.Execute(value);
                }

            }
        }
        public Command<PontoVenda> PontoVendaSelected
        {
            get
            {
                return new Command<PontoVenda>(async (ponto) =>
                {
                    await CoreMethods.PushPageModel<PontoVendaPageModel>(ponto);
                    _selectedPontoVenda = null;
                });
            }
        }
    }
}
