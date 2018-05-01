using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class ModifiedItem
    {
        /// <summary>
        /// Old Value
        /// </summary>
        public string O { get; set; }
        /// <summary>
        /// New Value
        /// </summary>
        public string N { get; set; }
        /// <summary>
        /// Property Name
        /// </summary>
        public string P { get; set; }
    }
}
