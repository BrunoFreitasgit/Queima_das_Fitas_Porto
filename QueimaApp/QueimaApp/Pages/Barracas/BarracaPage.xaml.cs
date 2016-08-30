using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace QueimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarracaPage : ContentPage
    {
        public BarracaPage()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            QueimaMap = new Map();
            QueimaMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(1)));
            base.OnAppearing();
        }
    }
}
