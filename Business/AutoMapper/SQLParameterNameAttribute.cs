using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class SQLParameterNameAttribute:Attribute
    {
        public string Name { get; set; }
        public SQLParameterNameAttribute() { 
        }
        public SQLParameterNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
