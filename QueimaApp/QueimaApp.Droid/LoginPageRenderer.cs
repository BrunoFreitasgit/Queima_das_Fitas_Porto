using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QueimaApp.Pages;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;

[assembly: ExportRenderer(typeof(LoginFacebookMockPage), typeof(QueimaApp.Droid.LoginPageRenderer))]
namespace QueimaApp.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "586277958219772",  // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accesing, delimited by "+" symbols
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
                );

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiresDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");

                    Console.WriteLine("OLÁ {0}", name);
                }else
                {
                    Console.WriteLine("OLÁ DESCONHECIDO");
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}