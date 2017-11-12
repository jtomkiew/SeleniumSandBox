using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumSandbox
{
    public class TimedKiller
    {
        private static object locker = new object();
        public static AutoResetEvent REvent;

        private static Timer timer;
        public static bool Enable = false;

        protected static List<Context> contexts = new List<Context>();

        public static void Check(Object stateInfo)
        {
            if (timer == null || !Enable)
                return;
            
            contexts.Where(v => v.CanBeDisposed).ToList().ForEach(c => c.Dispose());
            if (contexts.Count == 0)
            {
                timer.Dispose();
                timer = null;
                ((AutoResetEvent) stateInfo).Set();
            }
        }

        public static void StartTimer()
        {
            if (timer == null)
            {
                lock (locker)
                {
                    if (timer == null)
                    {
                        REvent = new AutoResetEvent(false);
                        timer = new Timer(Check, REvent, 1000, 1000);
                    }
                }
            }
        }
    }
}
