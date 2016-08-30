using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    public class IntroPageModel : FreshBasePageModel
    {
        public IntroPageModel()
        {

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
        public Command FacebookButtonCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<LoginFacebookMockPageModel>();
                });
            }
        }

    }
}
