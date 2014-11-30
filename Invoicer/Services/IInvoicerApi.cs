using Invoicer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicer.Services
{
    public interface IInvoicerApi : IInvoicerOptions
    {

    }

    public interface IInvoicerOptions : IInvoicerActions
    {
        /// <summary>
        /// Set a custom html color to personalize the document background
        /// </summary>
        IInvoicerOptions BackColor(string color);
        
        /// <summary>
        /// Set a custom html color to personalize the document text
        /// </summary>
        IInvoicerOptions TextColor(string color);

        /// <summary>
        /// Add a logo to the left corner of the document.
        /// </summary>
        IInvoicerOptions Image(string image, int width, int height);

        /// <summary>
        /// Set the title used on the document (e.g. 'invoice' or 'quote').
        /// </summary>
        /// <param name="title">Title. Default is 'Invoice'.</param>
        IInvoicerOptions Title(string title);

        /// <summary>
        /// A unique reference number for the document.
        /// </summary>
        /// <param name="reference">Reference (e.g. '123456-1'). If ommited the default is year, week, weekday.</param>
        IInvoicerOptions Reference(string reference);

        /// <summary>
        /// Set the document billing date
        /// </summary>
        /// <param name="date">Date, if ommited this is set to todays date.</param>
        IInvoicerOptions BillingDate(DateTime date);

        /// <summary>
        /// Set the due date.
        /// </summary>
        /// <param name="dueDate">Date, if ommited this is set to todays date + 14 days.</param>
        IInvoicerOptions DueDate(DateTime dueDate);

        /// <summary>
        /// Set the company address
        /// </summary>
        IInvoicerOptions Company(Address address);
        
        /// <summary>
        /// Set the client address.
        /// </summary>
        IInvoicerOptions Client(Address address);
        
        /// <summary>
        /// Switch the position of the company address (default left).
        /// </summary>
        /// <param name="position">Orientation left or right.</param>
        IInvoicerOptions CompanyOrientation(PositionOption position);

        /// <summary>
        /// You can add titles and paragraphs to display information on the bottom area
        /// of the document such as payment details or shipping information.
        /// </summary>
        IInvoicerOptions Details(List<DetailRow> details);

        /// <summary>
        /// Set a footer, this would typically be a web url.
        /// </summary>
        IInvoicerOptions Footer(string title);

        /// <summary>
        /// Add a new product or service row to your document below the company and 
        /// client information, paging is automatic.
        /// </summary>
        IInvoicerOptions Items(List<ItemRow> items);

        /// <summary>
        /// Add a row below the products and services for calculations and totals.
        /// </summary>
        IInvoicerOptions Totals(List<TotalRow> totals);
    };

    public interface IInvoicerActions
    {
        /// <summary>
        /// Save the document with a password
        /// </summary>
        /// <param name="filename">Filename of the PDF that will be created</param>
        /// <param name="password">Leave null (default) or set a password</param>
        void Save(string filename = null, string password = null);
    }
}
