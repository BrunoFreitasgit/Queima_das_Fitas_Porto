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

        public BarracasListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public override void Init(object initData)
        {
            Barracas = new ObservableCollection<Barraca>(_databaseService.GetBarracas());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }
       
    }
}
