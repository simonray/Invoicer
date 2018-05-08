# Invoicer

A simple PDF invoice generator for .NET.

### Usage

    new InvoicerApi(SizeOption.A4, OrientationOption.Landscape, "£")
        .TextColor("#CC0000")
        .BackColor("#FFD6CC")
        .Image(@"vodafone.jpg", 125, 27)
        .Company(Address.Make("FROM", "Vodafone Limited", "Vodafone House", "The Connection", "Newbury", "Berkshire RG14 2FN"))
        .Client(Address.Make("BILLING TO", "Isabella Marsh", "Overton Circle", "Little Welland", "Worcester", "WR## 2DJ"))
        .Items(new List<ItemRow> { 
            ItemRow.Make("Nexus 6", "Midnight Blue", (decimal)1, 20, (decimal)166.66, (decimal)199.99),
            ItemRow.Make("24 Months (£22.50pm)", "100 minutes, Unlimited texts, 100 MB data 3G plan with 3GB of UK Wi-Fi", (decimal)1, 20, (decimal)360.00, (decimal)432.00),
            ItemRow.Make("Special Offer", "Free case (blue)", (decimal)1, 0, (decimal)0, (decimal)0),
        })
        .Totals(new List<TotalRow> {
            TotalRow.Make("Sub Total", (decimal)526.66),
            TotalRow.Make("VAT @ 20%", (decimal)105.33),
            TotalRow.Make("Total", (decimal)631.99, true),
        })
        .Details(new List<DetailRow> {
            DetailRow.Make("PAYMENT INFORMATION", "Make all cheques payable to Vodafone UK Limited.", "", "If you have any questions concerning this invoice, contact our sales department at sales@vodafone.co.uk.", "", "Thank you for your business.")
        })
        .Footer("http://www.vodafone.co.uk")
        .Save();

![Alt text](http://s14.postimg.cc/525eovuep/invoice.png "Sample Invoice")
		
### References
* [PDFsharp/MigraDoc](http://pdfsharp.com)  
* [HTML Color Picker](http://www.w3schools.com/tags/ref_colorpicker.asp)
