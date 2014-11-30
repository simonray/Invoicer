using System;
using System.Collections.Generic;

namespace Invoicer.Models
{
    public class TotalRow
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Inverse { get; set; }

        public static TotalRow Make(string name, decimal value, bool inverse = false)
        {
            return new TotalRow()
            {
                Name = name,
                Value = value,
                Inverse = inverse,
            };
        }
    }
}