using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [ImplementPropertyChanged]
    public class Contact
    {
        public Contact()
        {
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
