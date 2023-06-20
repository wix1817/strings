using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{
    public class IllegalDictionary
    {
        public int Id { get; }
        public int DigitsCount { get; }
        public string Value { get; }

        public IllegalDictionary(int id, int digitsCount, string value)
        {
            Id = id;
            DigitsCount = digitsCount;
            Value = value;
        }
    }
}
