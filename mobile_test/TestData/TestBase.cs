using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace mobile_test.TestData
{
    [TestClass]
    public abstract class TestBase
    {
        CultureInfo _defaultCulture;
        CultureInfo _defaultUICulture;

        [TestInitialize]
        public void Initialize()
        {
            _defaultCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            _defaultUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            Device.PlatformServices = new MockPlatformServices();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Device.PlatformServices = null;
            System.Threading.Thread.CurrentThread.CurrentCulture = _defaultCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = _defaultUICulture;
        }
    }
}
