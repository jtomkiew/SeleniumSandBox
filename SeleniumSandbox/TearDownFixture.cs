using NUnit.Framework;
using SeleniumSandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[SetUpFixture]
public class TearDownFixture
{
    [OneTimeSetUp]
    public void SetUp()
    {
        TimedKiller.StartTimer();
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        TimedKiller.REvent.WaitOne();
    }
}
