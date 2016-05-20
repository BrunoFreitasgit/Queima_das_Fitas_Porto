using FreshMvvm;
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
    public class AtividadesListPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        public AtividadesListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ObservableCollection<AtividadeAcademica> Atividades { get; set; }

        public override void Init(object initData)
        {
            Atividades = new ObservableCollection<AtividadeAcademica>(_databaseService.GetAtividades());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        public override void ReverseInit(object value)
        {
            var newAtividade = value as AtividadeAcademica;
            if (!Atividades.Contains(newAtividade))
            {
                Atividades.Add(newAtividade);
            }
        }

        AtividadeAcademica _selectedAtividade;

        public AtividadeAcademica SelectedContact
        {
            get
            {
                return _selectedAtividade;
            }
            set
            {
                _selectedAtividade = value;
                if (value != null)
                    ContactSelected.Execute(value);
            }
        }

        public Command<AtividadeAcademica> ContactSelected
        {
            get
            {
                return new Command<AtividadeAcademica>(async (contact) =>
                {
                    await CoreMethods.PushPageModel<ContactPageModel>(contact);
                });
            }
        }
    }
}
