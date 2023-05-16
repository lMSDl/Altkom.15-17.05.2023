using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public abstract class AbstractCompany : Company
    {
        public int NumberOfWorkers { get; set; }
    }
}
