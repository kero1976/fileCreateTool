using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commons.Tests
{
    [TestClass]
    public class CreateNameTest
    {
        [TestMethod]
        public void createFileListVarI連番なし()
        {
            var list = CreateName.createFileListVarI("test",100,true);
            Assert.IsNull(list);
        }

        [TestMethod]
        public void createFileListVarI固定あり()
        {
            var list = CreateName.createFileListVarI("test<連番i>", 100, true);
            Assert.AreEqual(list[0],"test001");
            Assert.AreEqual(list[99], "test100");
        }

        [TestMethod]
        public void createFileListVarI固定なし()
        {
            var list = CreateName.createFileListVarI("test<連番i>", 100, false);
            Assert.AreEqual(list[0], "test1");
            Assert.AreEqual(list[99], "test100");
        }

        [TestMethod]
        public void fixCalTestテスト()
        {
            Assert.AreEqual(CreateName.fixCal(1), 1);
            Assert.AreEqual(CreateName.fixCal(9), 1);
            Assert.AreEqual(CreateName.fixCal(10), 2);
            Assert.AreEqual(CreateName.fixCal(99), 2);
            Assert.AreEqual(CreateName.fixCal(100), 3);
            Assert.AreEqual(CreateName.fixCal(999), 3);
        }

        
    }
}
