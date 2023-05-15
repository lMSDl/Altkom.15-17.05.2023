using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Entity
    {
        public DateTime CreatedDate { get; }
        public DateTime? ModifiedDate { get; set; }
    }
}
