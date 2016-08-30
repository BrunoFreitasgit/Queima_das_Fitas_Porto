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
    public partial class BarracaPage : ContentPage
    {
        //private TKCustomMap BarracaMap;
        public BarracaPage()
        {

            InitializeComponent();
            createView();
            BarracaMap.SetBinding(TKCustomMap.IsEnabledProperty, "TemLocalizacao");
        }
        protected override void OnAppearing()
        {
            BarracaMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.172653, -8.685432), Distance.FromMiles(0.5)));
            base.OnAppearing();
        }
        private void createView()
        {
            var default_place = new Position(41.172653, -8.685432);
            //BarracaMap = new TKCustomMap(MapSpan.FromCenterAndRadius(default_place, Distance.FromKilometers(5)));
            //var pin = new TKCustomMapPin();
            //pin.IsVisible = true;
            //pin.Position = local;
            //pin.ShowCallout = true;
            BarracaMap.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            BarracaMap.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            BarracaMap.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            BarracaMap.IsRegionChangeAnimated = true;
            //BarracaMap.MoveToRegion(new MapSpan());
            //MapLayout.Children.Add(BarracaMap, new Rectangle(0, 0, 1.0, 1.0));
            //AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0, 0, 1.0, 1.0"
        }
    }
}
