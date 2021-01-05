using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;
using System;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class BinaryFlagTest
    {

        [TestMethod]
        public void TestMinValue()
        {
            ulong tmp = UInt64.MinValue;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMinValueHigher()
        {
            ulong tmp = UInt64.MinValue + 1;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMinValueNew()
        {
            ulong tmp = 2;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMinValueNewLower()
        {
            ulong tmp = 1;
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(tmp, true));
        }

        [TestMethod]
        public void TestMinValueNewHigher()
        {
            ulong tmp = 3;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMaxValue()
        {
            ulong tmp = UInt64.MaxValue;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMaxValueLower()
        {
            ulong tmp = UInt64.MaxValue - 1;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMaxValueNew()
        {
            ulong tmp = 17179868703;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMaxValueNewLower()
        {
            ulong tmp = 17179868702;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestMaxValueNewHigher()
        {
            ulong tmp = 17179868704;
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(tmp, true));
        }

        [TestMethod]
        public void TestGetFlag()
        {
            ulong tmp = 8;
            MultipleBinaryFlag testFlag1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag testFlag2 = new MultipleBinaryFlag(tmp, false);
            Assert.IsTrue(testFlag1.GetFlag());
            Assert.IsFalse(testFlag2.GetFlag());
        }

        [TestMethod]
        public void TestSetResetFlagMin()
        {
            ulong tmp = 8;
            ulong pos = UInt64.MinValue;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.ResetFlag(pos);
            Assert.IsFalse(testFlag.GetFlag());
            testFlag.SetFlag(pos);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestSetResetFlagMinHigher()
        {
            ulong tmp = 8;
            ulong pos = UInt64.MinValue + 1;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.ResetFlag(pos);
            Assert.IsFalse(testFlag.GetFlag());
            testFlag.SetFlag(pos);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestSetResetFlagMax()
        {
            ulong tmp = 8;
            ulong pos = tmp - 1;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.ResetFlag(pos);
            Assert.IsFalse(testFlag.GetFlag());
            testFlag.SetFlag(pos);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestSetResetFlagMaxLower()
        {
            ulong tmp = 8;
            ulong pos = tmp - 2;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.ResetFlag(pos);
            Assert.IsFalse(testFlag.GetFlag());
            testFlag.SetFlag(pos);
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestSetResetFlagMaxHigher()
        {
            ulong tmp = 8;
            ulong pos = tmp;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => testFlag.ResetFlag(pos));
            Assert.IsTrue(testFlag.GetFlag());
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => testFlag.SetFlag(pos));
            Assert.IsTrue(testFlag.GetFlag());
        }

        [TestMethod]
        public void TestDisposeMin()
        {
            ulong tmp = 2;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.Dispose();
            Assert.ThrowsException<System.ArgumentNullException>(() => testFlag.GetFlag());
        }

        [TestMethod]
        public void TestDisposeMinHigher()
        {
            ulong tmp = 3;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.Dispose();
            Assert.ThrowsException<System.ArgumentNullException>(() => testFlag.GetFlag());
        }

        [TestMethod]
        public void TestDisposeMax()
        {
            ulong tmp = 17179868703;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.Dispose();
            Assert.ThrowsException<System.ArgumentNullException>(() => testFlag.GetFlag());
        }

        [TestMethod]
        public void TestDisposeMaxLower()
        {
            ulong tmp = 17179868702;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.Dispose();
            Assert.ThrowsException<System.ArgumentNullException>(() => testFlag.GetFlag());
        }

        [TestMethod]
        public void TestDisposeMaxHigher()
        {
            ulong tmp = 17179868704;
            MultipleBinaryFlag testFlag = new MultipleBinaryFlag(tmp, true);
            testFlag.Dispose();
            Assert.ThrowsException<System.ArgumentNullException>(() => testFlag.GetFlag());
        }

    }
}
