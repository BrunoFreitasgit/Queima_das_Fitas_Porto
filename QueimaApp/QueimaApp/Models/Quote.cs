using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    public class Quote
    {
        public Quote()
        {
        }
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Total { get; set; }
    }
}
