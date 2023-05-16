using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StandaloneAddress : Entity
    {
        private Location _location;

        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        private ILazyLoader LazyLoader { get; set; }

        public StandaloneAddress()
        {
        }

        public StandaloneAddress(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Location Location { get {
                try { return LazyLoader?.Load(this, ref _location) ?? _location; }
                catch { return null; };
            } set => _location = value; }
    }
}
