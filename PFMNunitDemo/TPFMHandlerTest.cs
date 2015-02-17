using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMNunitDemo
{
    [TestFixture]
    class TPFMHandlerTest
    {
        public THandlerFactory HandlerFactory { get; set; }

        public TPFMHandlerTest()
        {
            
        }

        [SetUp]
        public void PFMSetUp()
        {
            HandlerFactory = new THandlerFactory();
        }

        [TearDown]
        public void PFMTearDown()
        {
            HandlerFactory = null;
        }

        [Test]
        [Category("PFM處理元測試")]
        public void TestDefaultHandler()
        {
            TPFMHandler handler = null;
            handler = HandlerFactory.CreateHandler("");

            Assert.IsNotNull(handler);
            Assert.IsTrue(handler is TPFMHandler);
        }

        [Test]
        [Category("PFM處理元測試")]
        public void TestFileHandler()
        {
            TPFMHandler handler = null;
            handler = HandlerFactory.CreateHandler("FILE");

            Assert.IsNotNull(handler);
            Assert.IsTrue(handler is TFileHandler);
        }

        [Test]
        [Category("PFM處理元測試")]
        public void TestZipHandler()
        {
            TPFMHandler handler = null;
            handler = HandlerFactory.CreateHandler("ZIP");

            Assert.IsNotNull(handler);
            Assert.IsTrue(handler is TZipHandler);
        }
    }
}
