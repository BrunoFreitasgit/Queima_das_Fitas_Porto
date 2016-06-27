using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class FacebookWebPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        public UrlWebViewSource webFacebookUri;
        public FacebookWebPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public override void Init(object initData)
        {
            //TODO
            //webFacebookUri = new Social(_databaseService.GetSocial());
            webFacebookUri = new UrlWebViewSource
            {
                Url = "https://www.facebook.com/FAP1989/"
            };

        }
    }
}
