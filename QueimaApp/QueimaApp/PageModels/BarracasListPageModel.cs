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
                    PontoVendaSelected.Execute(value);
                }

            }
        }
        public Command<Barraca> PontoVendaSelected
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
    }
}
