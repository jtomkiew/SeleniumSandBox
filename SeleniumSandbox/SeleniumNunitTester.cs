using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSandbox
{
    public class SeleniumNunitTester
    {
        protected Context Context => Context.Current;

        [OneTimeSetUp]
        public void Setup()
        {
            if (Context == null)
                new Context().Init();

            Context.CanBeDisposed = false;
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Context.CanBeDisposed = true;
            TimedKiller.Enable = true;
        }
    }
}
