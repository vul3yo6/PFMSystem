using NUnit.Framework;
using PFMCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PFMSystemTest
{
    [TestFixture]
    class PFMConfigTestCases
    {
        public TPFMConfigManager ConfigManager { get; set; }

        public PFMConfigTestCases() { }
        
        [SetUp]
        public void SetUp()
        {
            ConfigManager = new TPFMConfigManager("");
            ConfigManager.ProcessConfigs();
        }

        [TearDown]
        public void TearDown()
        {
            ConfigManager = null;
        }

        [Test]
        [Category("PFM核心測試")]
        public void TestGetConfigs()
        {
            for (int i = 0; i < ConfigManager.Count; i++)
            {
                //if (i == 0)
                //{
                //    Assert.IsTrue
                //}
            }
        }

        [Test]
        [Category("PFM核心測試")]
        public void TestGetConfigCount()
        {
            int result = ConfigManager.Count;
            Assert.AreEqual(2, result);
        }
    }
}
