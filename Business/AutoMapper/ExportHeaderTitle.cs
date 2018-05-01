using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class ExportHeaderTitle:Attribute
    {
        public string Title { get; set; }
        public bool Ignore { get; set; }
    }
}
