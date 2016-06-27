using FreshMvvm;
using QueimaApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace QueimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtividadeMapaPage : ContentPage
    {
        private TKCustomMap mapView;
        public AtividadeMapaPage()
        {
            if (mapView == null)
            {
                createView(mapView);
            }
            InitializeComponent();     
        }


        private void createView(TKCustomMap mapView)
        {
            //var mapView = new TKCustomMap(new MapSpan(new Position(41.152506, -8.636040), 41.152506, -8.636040).WithZoom(5));
            //var local = new Position(PageModel.Atividade.Latitude, PageModel.Atividade.Longitude);
            var default_place = new Position(41.152506, -8.636040);
            mapView = new TKCustomMap( MapSpan.FromCenterAndRadius(default_place, Distance.FromKilometers(5)));
            //var pin = new TKCustomMapPin();
            //pin.IsVisible = true;
            //pin.Position = local;
            //pin.ShowCallout = true;
            mapView.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            mapView.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            mapView.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            mapView.IsRegionChangeAnimated = true;
            this.Content = mapView;
            
        }
    }
}
