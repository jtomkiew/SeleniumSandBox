using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumSandbox
{
    public class Tester2 : SeleniumNunitTester
    {
        [Test]
        public void Test21()
        {
            Thread.Sleep(5000);
        }
    }
}
