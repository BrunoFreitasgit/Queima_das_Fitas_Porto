using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    public class MainMenuPageModel : FreshBasePageModel
    {
        public MainMenuPageModel()
        {
        }

        public Command ShowQuotes
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<QuoteListPageModel>();
                });
            }
        }

        public Command ShowContacts
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<ContactListPageModel>();
                });
            }
        }
    }
}
