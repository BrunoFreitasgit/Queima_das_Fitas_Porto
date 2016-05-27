using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class LoginFacebookMockPageModel : FreshBasePageModel
    {
        public LoginFacebookMockPageModel()
        {

        }

        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            Debug.WriteLine("View is appearing");
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, System.EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
        public Command CloseCommand
        {
            get
            {
                return new Command(() =>
                {
                    CoreMethods.PopPageModel(true);
                });
            }
        }
    }
}
