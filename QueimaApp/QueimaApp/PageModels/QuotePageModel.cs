using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class QuotePageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;

        public Quote Quote { get; set; }

        public QuotePageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override void Init(object initData)
        {
            Quote = initData as Quote;
            if (Quote == null)
                Quote = new Quote();
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    _databaseService.UpdateQuote(Quote);
                    await CoreMethods.PopPageModel(Quote);
                });
            }
        }

        public Command TestModal
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<ModalPageModel>(null, true);
                });
            }
        }
    }
}