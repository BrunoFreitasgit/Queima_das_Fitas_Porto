using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using System;
using QueimaApp.Interfaces;
using QueimaApp.Models;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class ContactPageModel : FreshBasePageModel
    {
        IDatabaseService _dataService;

        public ContactPageModel(IDatabaseService dataService)
        {
            _dataService = dataService;

            this.WhenAny(HandleContactChanged, o => o.Contact);
        }

        void HandleContactChanged(string propertyName)
        {
            //handle the property changed, nice
        }

        public Contact Contact { get; set; }

        public override void Init(object initData)
        {
            if (initData != null)
            {
                Contact = (Contact)initData;
            }
            else
            {
                Contact = new Contact();
            }
        }

        public Command TestModal
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<ModalPageModel>(null, true);
                });
            }
        }
    }
}
