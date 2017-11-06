using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSandbox
{
    public class Context : TimedKiller
    {
        public static Context Current
        {
            get
            {
                if (contexts.TryGetValue(System.Threading.Thread.CurrentThread.ManagedThreadId, out var context))
                    return context;
                return null;
            }
        }

        private DriverService Service;

        public IWebDriver Driver;

        private bool _canBeDisposed;
        private bool _canBeDisposedSecondCheck;
        public bool CanBeDisposed
        {
            get
            {
                if (_canBeDisposed)
                {
                    if (_canBeDisposedSecondCheck)
                        return true;
                    else
                    {
                        _canBeDisposedSecondCheck = true;
                        return false;
                    }
                }
                return false;
            }
            set
            {
                _canBeDisposed = value;
                _canBeDisposedSecondCheck = false;
            }
        }

        public void Init()
        {
            contexts.TryAdd(System.Threading.Thread.CurrentThread.ManagedThreadId, this);
            var chromeService = ChromeDriverService.CreateDefaultService();
            Driver = new ChromeDriver(chromeService);
            Service = chromeService;
        }

        public void Dispose()
        {
            Driver.Quit();
            contexts.TryRemove(System.Threading.Thread.CurrentThread.ManagedThreadId, out var notUsed);
        }
    }
}
