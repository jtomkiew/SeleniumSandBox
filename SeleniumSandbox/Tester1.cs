using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumSandbox
{
    public class Tester1 : SeleniumNunitTester
    {
        [Test]
        public void Test1()
        {
            Thread.Sleep(1000);
        }

        [Test]
        public void Test2()
        {
            Thread.Sleep(1000);
        }

        [Test]
        public void Test3()
        {
            Thread.Sleep(1000);
        }
    }
}
