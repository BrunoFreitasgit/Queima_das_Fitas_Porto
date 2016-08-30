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
    public partial class SocialPage : TabbedPage
    {
        public SocialPage()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("", "Home.png", () =>
            {
                Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            }));

            var facebookPage = FreshPageModelResolver.ResolvePageModel<FacebookWebPageModel>();
            var instaPage = FreshPageModelResolver.ResolvePageModel<InstagramWebPageModel>();
            facebookPage.Title = "Facebook";
            instaPage.Title = "Instagram";
            facebookPage.Icon = "icon.png";
            instaPage.Icon = "icon.png";
            this.BarBackgroundColor = (Color)Application.Current.Resources["BrandColorDark"];
            this.Children.Add(facebookPage);
            this.Children.Add(instaPage);

        }
    }
}
