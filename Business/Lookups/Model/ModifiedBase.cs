using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
   public class ModifiedBase<T>
    {
        public T Old { get; set; }
        public T New { get; set; }
    }
}
