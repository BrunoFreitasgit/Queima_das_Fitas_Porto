using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{

    [ImplementPropertyChanged]
    public class PontoVendaPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        public PontoVenda PontoVenda { get; set; }
        public PontoVendaPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public override void Init(object initData)
        {
            PontoVenda = initData as PontoVenda;
            if (PontoVenda == null)
                PontoVenda = new PontoVenda();
        }


    }
}
