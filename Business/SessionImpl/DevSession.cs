using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.SessionImpl
{
    public class DevSession : ISession
    {
        private static Dictionary<SessionEnum, object> dic = new Dictionary<SessionEnum, object>();

        public object Get(SessionEnum key)
        {
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            return null;
        }

        public T Get<T>(SessionEnum key) where T : class
        {
            if(dic.ContainsKey(key))
            {
                return (T)dic[key];
            }
            return null;
        }

        public void Remove(SessionEnum key)
        {
            if (dic.ContainsKey(key))
            {
                 dic.Remove(key);
            }
        }

        public void Set(object obj, SessionEnum key)
        {
            if (dic.ContainsKey(key))
            {
               dic[key]=obj;
            }
            else
            {
                dic.Add(key, obj);
            }
        }
    }
}