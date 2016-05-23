using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace QueimaApp.Pages
{
    public partial class AtividadeMapaPage : ContentPage
    {
        public AtividadeMapaPage()
        {
            this.createView();
            InitializeComponent();    
        }

        private void createView()
        {
            var mapView = new TKCustomMap();
            mapView.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            mapView.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            mapView.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            this.Content = mapView;
        }
    }
}
