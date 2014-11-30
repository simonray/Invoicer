using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicer.Models
{
    public class DetailRow
    {
        public string Title { get; set; }
        public List<string> Paragraphs { get; set; }

        public static DetailRow Make(string title, params string[] paragraphs)
        {
            return new DetailRow
            {
                Title = title,
                Paragraphs = paragraphs.ToList(),
            };
        }
    }
}
