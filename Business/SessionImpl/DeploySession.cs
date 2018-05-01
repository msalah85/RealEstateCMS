using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.SessionImpl
{
    public class DeploySession : ISession
    {
        public T Get<T>(SessionEnum key) where T : class
        {
            if (HttpContext.Current.Session != null)
            {
                object RetObject = HttpContext.Current.Session[key.ToString()];
                if (RetObject != null)
                {
                    return (T)RetObject;
                }
            }
            

            return null;
        }

        public object Get(SessionEnum key)
        {
           return HttpContext.Current.Session[key.ToString()];
        }

        public void Set(object obj, SessionEnum key)
        {
            HttpContext.Current.Session[key.ToString()] = obj;
        }

        public void Remove(SessionEnum key)
        {
            if (HttpContext.Current.Session[key.ToString()] !=null)
            {
                HttpContext.Current.Session.Remove(key.ToString());
            }
        }
    }
}