using Invoicer.Helpers;
using Invoicer.Models;
using Invoicer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Invoicer.Services
{
    public class InvoicerApi : IInvoicerApi
    {
        public Invoice Invoice { get; protected set; }
        
        public static string DefaultReference
        {
            get
            {
                DateTime now = DateTime.Now;
                return string.Format("{0}{1}{2}", now.GetShortYear(), now.GetWeekNumber(), (int)now.DayOfWeek);
            }
        }

        public InvoicerApi(
            SizeOption size = SizeOption.A4,
            OrientationOption orientation = OrientationOption.Portrait,
            string currency = "£"
            )
        {
            Invoice = new Invoice();
            Invoice.Title = "Invoice";
            Invoice.PageSize = size;
            Invoice.PageOrientation = orientation;
            Invoice.Currency = currency;
            Invoice.BillingDate = DateTime.Now;
            Invoice.DueDate = Invoice.BillingDate.AddDays(14);
            Invoice.Reference = DefaultReference;
        }

        public IInvoicerOptions BackColor(string color)
        {
            Invoice.BackColor = color;
            return this;
        }

        public IInvoicerOptions TextColor(string color)
        {
            Invoice.TextColor = color;
            return this;
        }

        public IInvoicerOptions Image(string image, int width, int height)
        {
            Invoice.Image = image;
            Invoice.ImageSize = new Size(width, height);
            return this;
        }


        public IInvoicerOptions Title(string title)
        {
            Invoice.Title = title;
            return this;
        }

        public IInvoicerOptions Reference(string reference)
        {
            Invoice.Reference = reference;
            return this;
        }

        public IInvoicerOptions BillingDate(DateTime date)
        {
            Invoice.BillingDate = date;
            return this;
        }

        public IInvoicerOptions DueDate(DateTime dueDate)
        {
            Invoice.DueDate = dueDate;
            return this;
        }

        public IInvoicerOptions Company(Address address)
        {
            Invoice.Company = address;
            return this;
        }

        public IInvoicerOptions Client(Address address)
        {
            Invoice.Client = address;
            return this;
        }

        public IInvoicerOptions CompanyOrientation(PositionOption position)
        {
            Invoice.CompanyOrientation = position;
            return this;
        }

        public IInvoicerOptions Details(List<DetailRow> details)
        {
            Invoice.Details = details;
            return this;
        }

        public IInvoicerOptions Footer(string title)
        {
            Invoice.Footer = title;
            return this;
        }

        public IInvoicerOptions Items(List<ItemRow> items)
        {
            Invoice.Items = items;
            return this;
        }

        public IInvoicerOptions Totals(List<TotalRow> totals)
        {
            Invoice.Totals = totals;
            return this;
        }

        public void Save(string filename, string password = null)
        {
            if (filename == null || !System.IO.Path.HasExtension(filename))
                filename = System.IO.Path.ChangeExtension(Invoice.Reference, "pdf");
           new PdfInvoice(Invoice).Save(filename, password);
        }
    }
}
