using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class NonNullableSqlAttribute : Attribute
    {
        public bool HasDefaultValue { get;private set; }
        public string Default_Value { get;private set; }
        public NonNullableSqlAttribute()
        {

        }

        public NonNullableSqlAttribute(string _Default_Value)
        {
            Default_Value = _Default_Value;
            this.HasDefaultValue = true;
        }

    }
}
