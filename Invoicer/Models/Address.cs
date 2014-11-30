using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models
{
    public class Address
    {
        public string Title { get; set; }
        public string[] AddressLines { get; set; }

        public static Address Make(string title, params string[] address)
        {
            return new Address
            {
                Title = title,
                AddressLines = address,
            };
        }
    }
}
