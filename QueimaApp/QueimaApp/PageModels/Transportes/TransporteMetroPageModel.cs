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
    public class TransporteMetroPageModel : FreshBasePageModel
    {
        IQueimaRepository _repository;
        public Transporte Transporte { get; set; }
        public TransporteMetroPageModel(IQueimaRepository repository)
        {
            _repository = repository;
        }
        public override void Init(object initData)
        {
            var temp = _repository.GetTransporteByType((int)TipoTransporte.Metro);

            if (temp != null)
            {
                Transporte = _repository.GetTransporteByType((int)TipoTransporte.Metro);
            }

        }
    }
}
