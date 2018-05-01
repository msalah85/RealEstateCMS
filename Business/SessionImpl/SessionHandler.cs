using Business.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Business.SessionImpl
{
    public class SessionHandler : ISession
    {
        private static SessionHandler instance = new SessionHandler();
        public static SessionHandler Instance { get { return instance; } }
        private ISession _session;
        public SessionHandler()
        {
            bool check = false;
            if (check)
            {
                Console.WriteLine("IsAttached");
                _session = new DevSession();
            }
            else
            {
                _session = new DeploySession();
            }
        }

        public T Get<T>(SessionEnum key) where T : class
        {

            var ret = _session.Get<T>(key);
            if (ret == null)
            {
                switch (key)
                {
                    case SessionEnum.Language_Info:
                        ret = (T)Activator.CreateInstance(typeof(T));
                        break;
                }
            }

            return ret;
        }

        public object Get(SessionEnum key)
        {
            return _session.Get(key);
        }

        public void Set(object obj, SessionEnum key)
        {
                _session.Set(obj, key);
        }
        public void Remove(SessionEnum key)
        {
            _session.Remove(key);
        }
    }
}
