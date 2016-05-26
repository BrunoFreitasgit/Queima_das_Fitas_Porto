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

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class BilhetesPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        public ObservableCollection<Bilhete> Bilhetes { get; set; }

        public BilhetesPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public override void Init(object initData)
        {
            Bilhetes = new ObservableCollection<Bilhete>(_databaseService.GetBilhetes());
        }
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }
    }
}
