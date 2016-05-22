using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class BilheteiraPageModel : FreshBasePageModel
    {
        public BilheteiraPageModel()
        {

        }

        public override void Init(object initData)
        {
           // Atividades = new ObservableCollection<AtividadeAcademica>(_databaseService.GetAtividades());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

    }
}
