using FreshMvvm;
using PropertyChanged;
using QueimaApp.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System;
using System.ComponentModel;

namespace QueimaApp.PageModels
{

    [ImplementPropertyChanged]
    public class AtividadeMapaPageModel : FreshBasePageModel
    {
        public ObservableCollection<TKCustomMapPin> Pins { get; set; }
        public MapSpan MapRegion { get; set; }
        public Position MapCenter { get; set; }
        public string Nome { get; set; }


        public AtividadeAcademica Atividade { get; set; }

        public override void Init(object initData)
        {
            Atividade = initData as AtividadeAcademica;
            if (Atividade == null)
                Atividade = new AtividadeAcademica();

            Nome = Atividade.Nome;
            Pins = new ObservableCollection<TKCustomMapPin>();
            var Pin = new TKCustomMapPin
            {
                IsVisible = true,
                Title = Atividade.Local,
                Position = new Position(Atividade.LocalLatitude, Atividade.LocalLongitude),
                ShowCallout = true
            };
            Pins.Add(Pin);
            MapCenter = new Position(Atividade.LocalLatitude, Atividade.LocalLongitude);
            MapRegion = MapSpan.FromCenterAndRadius(Pin.Position, Distance.FromKilometers(0.5));
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

        public AtividadeMapaPageModel()
        {

        }

        //public Command CloseCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            CoreMethods.PopPageModel(true);
        //        });
        //    }
        //}
    }
}
