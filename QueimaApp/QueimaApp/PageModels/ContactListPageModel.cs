using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class ContactListPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;

        Contact _selectedContact;

        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                if (value != null)
                {
                    ContactSelected.Execute(value);
                }
            }
        }

        public ContactListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ObservableCollection<Contact> Contacts { get; set; }

        public override void Init(object initData)
        {
            Contacts = new ObservableCollection<Contact>(_databaseService.GetContacts());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }
        

        public override void ReverseInit(object value)
        {
            var newContact = value as Contact;
            if (!Contacts.Contains(newContact))
            {
                Contacts.Add(newContact);
            }
        }


        public Command AddContact
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<ContactPageModel>();
                });
            }
        }

        public Command<Contact> ContactSelected
        {
            get
            {
                return new Command<Contact>(async (contact) =>
                {
                    await CoreMethods.PushPageModel<ContactPageModel>(contact);
                    _selectedContact = null;
                });
            }
        }
    }
}
