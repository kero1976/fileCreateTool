using System;
using System.Diagnostics;
using System.IO;
using Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commons.Tests
{
    [TestClass]
    public class FileDirUtilTest
    {

        [ClassInitialize()]
        public static void classInitialize(TestContext test_context)
        {

        }

        [ClassCleanup()]
        public static void classCleanup()
        {

        }

        [TestInitialize()]
        public void testInitialize()
        {

        }

        [TestCleanup]
        public void testCleanup()
        {

        }

        /// <summary>
        /// Nullが渡ってきたときはfalseが返ることを確認するテスト
        /// </summary>
        [TestMethod]
        public void CreateDirNullTest()
        {
            Assert.IsFalse(FileDirUtil.CreateDir(null, null));
            Assert.IsFalse(FileDirUtil.CreateDir("c:\\", null));
            Assert.IsFalse(FileDirUtil.CreateDir(null, "test"));
        }

        [TestMethod]
        public void CreateDirフォルダ作成成功()
        {
            Assert.IsTrue(FileDirUtil.CreateDir("c:\\test", "test2"));
            Assert.IsTrue(Directory.Exists("C:\\test\\test2"));
            Assert.IsTrue(FileDirUtil.CreateDir("c:\\test", "あ①"));
            Assert.IsTrue(Directory.Exists("C:\\test\\あ①"));
        }

        [TestMethod]
        public void CreateDirフォルダ作成失敗()
        {
            Trace.WriteLine("【個別】ろぐでない");
            Assert.IsFalse(FileDirUtil.CreateDir("c:\\test", "test>2"));
        }


        [TestMethod]
        public void CreateFileファイル作成成功()
        {
            Assert.IsTrue(FileDirUtil.CreateFile("c:\\test", "test2.txt",0));
            Assert.IsTrue(File.Exists("C:\\test\\test2.txt"));
            Assert.IsTrue(FileDirUtil.CreateFile("c:\\test", "あ①.txt", 0));
            Assert.IsTrue(File.Exists("C:\\test\\あ①.txt"));
        }

        [TestMethod]
        public void BaseDirCheckNullTest()
        {
            Assert.IsFalse(FileDirUtil.BaseDirCheck(null));
        }
        
    }
}
