using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    public class ModalPageModel : FreshBasePageModel
    {
        public ModalPageModel()
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
    }
}
