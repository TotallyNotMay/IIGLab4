using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.FileWorker;
using IIG.BinaryFlag;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class BinaryFlagFile
    {
        private string outputFile = "C:/Users/Kotenko/Desktop/QA/IIGLab4/output/output.txt";
        private string inputFileSingle = "C:/Users/Kotenko/Desktop/QA/IIGLab4/input/inputSingle.txt";
        private string inputFileMultiple = "C:/Users/Kotenko/Desktop/QA/IIGLab4/input/inputMultiple.txt";
        [TestMethod]
        public void TestWriteToString1()
        {
            ulong tmp = 8;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(BaseFileWorker.Write(testFlag.ToString(), outputFile));
        }
        [TestMethod]
        public void TestWriteToString2()
        {
            ulong tmp = 8;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, false);
            Assert.IsTrue(BaseFileWorker.Write(testFlag.ToString(), outputFile));
        }
        [TestMethod]
        public void TestReadLinesSingle()
        {
            // Input file contains 'TTTTTTTT'
            ulong tmp = 8;
            MultipleBinaryFlag testFlag1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag testFlag2 = new MultipleBinaryFlag(tmp, false);
            string[] input = BaseFileWorker.ReadLines(inputFileSingle);
            Assert.AreEqual(testFlag1.ToString(), input[0]);
            Assert.AreNotEqual(testFlag2.ToString(), input[0]);
        }
        [TestMethod]
        public void TestReadLinesMultiple()
        {
            /* 
                Input file contains 
                'TTTTTTTT'
                'FFFFFFFF'
            */
            ulong tmp = 8;
            MultipleBinaryFlag testFlag1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag testFlag2 = new MultipleBinaryFlag(tmp, false);
            string[] input = BaseFileWorker.ReadLines(inputFileMultiple);
            Assert.AreEqual(testFlag1.ToString(), input[0]);
            Assert.AreEqual(testFlag2.ToString(), input[1]);
            Assert.AreNotEqual(testFlag2.ToString(), input[0]);
            Assert.AreNotEqual(testFlag1.ToString(), input[1]);
        }
        [TestMethod]
        public void TestReadAllSingle()
        {
            // Input file contains 'TTTTTTTT'
            ulong tmp = 8;
            MultipleBinaryFlag testFlag1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag testFlag2 = new MultipleBinaryFlag(tmp, false);
            Assert.AreEqual(testFlag1.ToString(), BaseFileWorker.ReadAll(inputFileSingle));
            Assert.AreNotEqual(testFlag2.ToString(), BaseFileWorker.ReadAll(inputFileSingle));
        }
        [TestMethod]
        public void TestReadAllMultiple()
        {
            /* 
                Input file contains 
                'TTTTTTTT'
                'FFFFFFFF'
            */
            ulong tmp = 8;
            MultipleBinaryFlag testFlag1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag testFlag2 = new MultipleBinaryFlag(tmp, false);
            string testFlags1 = testFlag1.ToString() + "\r\n" + testFlag2.ToString();
            string testFlags2 = testFlag2.ToString() + "\r\n" + testFlag1.ToString();
            Assert.AreEqual(testFlags1, BaseFileWorker.ReadAll(inputFileMultiple));
            Assert.AreNotEqual(testFlags2, BaseFileWorker.ReadAll(inputFileMultiple));
        }
    }
}
