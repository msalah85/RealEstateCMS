using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
   public class LogDateTypeAttribute : Attribute
    {
        public DateType DateType;
        public LogDateTypeAttribute(DateType _DateType)
        {
            this.DateType = _DateType;

        }
       
    }
    public enum DateType
    {
        Date,
        DateTime
    }
}
