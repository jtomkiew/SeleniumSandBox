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
        private static object obj = new object();
        private static object locker = new object();

        private static Timer timer;

        protected static ConcurrentDictionary<int, Context> contexts = new ConcurrentDictionary<int, Context>();

        public static void Check(Object stateInfo)
        {
            contexts.Select(c => c.Value).Where(v => v.CanBeDisposed).ToList().ForEach(c => c.Dispose());
        }

        public static void StartTimer()
        {
            if (timer == null)
            {
                lock (locker)
                {
                    if (timer == null)
                    {
                        timer = new Timer(Check, obj, 1000, 1000);
                    }
                }
            }
        }
    }
}
