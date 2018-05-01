using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class ItemValue
    {

        public ItemValue(string value, string tile)
        {
            this.Title = tile;
            this.Value = value;
        }

        public string Title { get; set; }
        public string Value { get; set; }
    }
}
