using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.SessionImpl
{
    public interface ISession
    {
        T Get<T>(SessionEnum key) where T : class;
        object Get(SessionEnum key);
        void Set(object obj, SessionEnum key);

        void Remove(SessionEnum key);
    }
}
