using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[Table("Addresses")]
    //brak klucza
    //[Keyless]
    public class Address : Entity
    {
        //public int AddressId { get; set; }

        //klucz złożony za pomocą adnotacji
        //[Key]
        //[Column(Order = 2)]
        public string Street { get; set; }
        //[Key]
        //[Column(Order = 1)]
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
