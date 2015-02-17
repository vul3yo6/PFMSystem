using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMNunitDemo
{
    [TestFixture]
    class TPFMScheduleTest
    {
        public TPFMScheduleManager ScheduleManager { get; set; }

        public TPFMScheduleTest()
        {
            
        }

        [SetUp]
        public void PFMSetUp()
        {
            ScheduleManager = new TPFMScheduleManager("PFM-Schedule.XML");
        }

        [TearDown]
        public void PFMTearDown()
        {
            ScheduleManager = null;
        }

        [Test]
        [Category("PFM核心測試")]
        public void TestScheduleCount()
        {
            ScheduleManager.ProcessSchedules();
            Assert.AreEqual(2, ScheduleManager.Count);
        }

        [Test, Category("PFM核心測試")]
        public void TestSchedules()
        {
            ScheduleManager.ProcessSchedules();
            for (int i = 0; i < ScheduleManager.Count; i++)
            {
                Assert.IsTrue(ScheduleManager.GetItem(i) is TPFMSchedule); 
            }
        }
    }
}
