using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Configuration;

namespace Shop.BLLTests
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.Initialize();
        }
    }
}
