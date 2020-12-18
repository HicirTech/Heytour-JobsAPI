using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ResourceParameters
{
    public class JobsFilterParameters
    {

        /// <summary>
        /// enabled nullable for is active
        /// </summary>
        public bool? IsActive { get; set; }
        public DateTime PostedOn { get; set; }

        public string FilterTerm { get; set; }
    }
}
