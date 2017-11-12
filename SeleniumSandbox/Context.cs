using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                return (Context) CallContext.LogicalGetData("TContext");
            }
            set
            {
                CallContext.LogicalSetData("TContext", value);
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
            contexts.Add(this);
            Current = this;
            var chromeService = ChromeDriverService.CreateDefaultService();
            Driver = new ChromeDriver(chromeService);
            Service = chromeService;
        }

        public void Dispose()
        {
            Driver.Quit();
            contexts.Remove(this);
            Current = null;
        }
    }
}
