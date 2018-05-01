using Business.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
  public  class LookupResolveableAttribute : Attribute
    {
        private Type _lookupType;
        public ILookup Lookup { get
            {
                try
                {
                    ILookup _lookup = (ILookup)Activator.CreateInstance(_lookupType);
                    return _lookup;
                }
                catch(Exception ex)
                {
                    return null;
                }
               } }
        public LookupResolveableAttribute(Type lookupType)
        {
            _lookupType = lookupType;
        }
    }
}
