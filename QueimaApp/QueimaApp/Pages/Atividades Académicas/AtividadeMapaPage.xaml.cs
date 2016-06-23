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
        public AtividadeMapaPage()
        {
            this.createView();
            InitializeComponent(); 
        }

        private void createView()
        {
            //var mapView = new TKCustomMap(new MapSpan(new Position(41.152506, -8.636040), 41.152506, -8.636040).WithZoom(5));
            var mapView = new TKCustomMap();
            mapView.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            mapView.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            mapView.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            this.Content = mapView;
        }
    }
}
