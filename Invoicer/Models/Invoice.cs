using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Invoicer.Models
{
    public class Invoice
    {
        public SizeOption PageSize { get; set; }
        public OrientationOption PageOrientation { get; set; }
        public string Currency { get; set; }

        public string BackColor { get; set; }
        public string TextColor { get; set; }
        public string Image { get; set; }
        public Size ImageSize { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime DueDate { get; set; }
        public Address Client { get; set; }
        public Address Company { get; set; }
        public PositionOption CompanyOrientation { get; set; }
        public List<DetailRow> Details { get; set; }
        public string Footer { get; set; }
        public List<ItemRow> Items { get; set; }
        public List<TotalRow> Totals { get; set; }

        /// <summary>
        /// Do any of the items have a discount specified. If there are no discounts then
        /// the column will be ommited from the invoice.
        /// </summary>
        public bool HasDiscount { get { return Items.Any(row => row.HasDiscount); } }
    }
}
