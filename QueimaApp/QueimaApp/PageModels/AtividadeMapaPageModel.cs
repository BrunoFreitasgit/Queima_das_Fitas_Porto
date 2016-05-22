using FreshMvvm;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{
    public class AtividadeMapaPageModel : FreshBasePageModel
    {
        public double Latitude, Longitude;
        public AtividadeAcademica Atividade { get; set; }

        public override void Init(object initData)
        {
            Atividade = initData as AtividadeAcademica;
            Latitude = Atividade.Latitude;
            Longitude = Atividade.Longitude;

            if (Atividade == null)
                Atividade = new AtividadeAcademica();

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
    }
}
