using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.Pages
{
    public class FacebookWebPage : ContentPage
    {
        public FacebookWebPage()
        {
            var browser = new WebView();

            browser.Source = "https://www.facebook.com/FAP1989/";

            Content = browser;
        }
    }
}
