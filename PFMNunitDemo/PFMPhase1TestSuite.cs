using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMNunitDemo
{
    [TestFixture]
    class PFMPhase1TestSuite
    {
        public PFMPhase1TestSuite()
        {

        }

        [Suite]
        public static IEnumerable CreateSuite
        {
            get
            {
                var suite = new ArrayList();
                suite.Add(new PFMPhase1TestSuite());
                suite.Add(new TPFMScheduleTest());
                suite.Add(new TPFMHandlerTest());
                return suite;
            }
        }
    }
}
