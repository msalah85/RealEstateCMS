using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extenions
{
    public class CompareData
    {
        public bool IsWithin(int value, double minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
    }
}
