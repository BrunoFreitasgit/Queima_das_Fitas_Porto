using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharp;
using QueimaApp.Helpers;
using Plugin.Connectivity;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class InstagramWebPageModel : FreshBasePageModel
    {
        public InstagramWebPageModel()
        {

        }
        public override void Init(object initData)
        {

        }
        private async void GetImages()
        {
            //TODO
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    await CurrentPage.DisplayAlert("Erro", "Tem de ter uma conexão à Internet", "OK");
            //    return;
            //}
            //var clientId = InstagramApi.ClientId;
            //var clientSecret = InstagramApi.ClientSecret;
            //var redirectUri = InstagramApi.RedirectUrl;
            //var realtimeUri = "";
        }
    }
}
