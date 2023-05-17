using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KeyTest
    {
        public int Key { get; set; }

        //[ConcurrencyCheck]
        public int Value { get; set; }

        //[Timestamp]
        public byte[] Timestamp { get; set; }

    }
}
