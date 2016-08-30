using FreshMvvm;
using QueimaApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QueimaApp.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartazPage : TabbedPage
    {
        public CartazPage()
        {

            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("", "Home.png", () =>
            {
                Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            }));

            var discotecaPage = FreshPageModelResolver.ResolvePageModel<CartazDiscotecaPageModel>();
            var palcoPage = FreshPageModelResolver.ResolvePageModel<CartazPalcoPageModel>();
            discotecaPage.Title = "Discoteca";
            palcoPage.Title = "Palco";
            discotecaPage.Icon = "icon.png";
            palcoPage.Icon = "icon.png";
            this.BarBackgroundColor = (Color)Application.Current.Resources["BrandColorDark"];
            this.Children.Add(palcoPage);
            this.Children.Add(discotecaPage);
        }
    }
}
