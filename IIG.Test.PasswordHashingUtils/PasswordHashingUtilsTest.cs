using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.PasswordHashingUtils;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class PasswordHashingUtilsTest
    {
        [TestMethod]
        public void TestGetHash01245()
        {
            string password = "password";
            Assert.IsNotNull(PasswordHasher.GetHash(password));

            password = "password1";
            Assert.IsNotNull(PasswordHasher.GetHash(password));

            password = "password!";
            Assert.IsNotNull(PasswordHasher.GetHash(password));

            password = "Password";
            Assert.IsNotNull(PasswordHasher.GetHash(password));  

            password = "";
            Assert.IsNotNull(PasswordHasher.GetHash(password));

            password = "password";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "salt"));

            password = "password";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "salt", 0));

            password = "password";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "", 8));

            password = "password";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "salt", 8));
        }

        [TestMethod]
        public void TestGetHash0125()
        {
            string password = null;
            Assert.ThrowsException<System.ArgumentNullException>(() => PasswordHasher.GetHash(password));
        }

        [TestMethod]
        public void TestGetHash012345()
        {
            string password = "❤";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            Assert.AreEqual(PasswordHasher.GetHash(password).Length, 64);
        }

        [TestMethod]
        public void TestInit0123()
        {
            string password = "password";
            PasswordHasher.Init("salt", 8);
            string hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init("salt", 8);
            string hash2 = PasswordHasher.GetHash(password);
            Assert.AreEqual(hash1, hash2);

            password = "password1";
            PasswordHasher.Init("salt", 8);
            hash1 = PasswordHasher.GetHash(password);
            password = "password2";
            PasswordHasher.Init("salt", 8);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);

            password = "password";
            PasswordHasher.Init("salt", 8);
            hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init("anotherSalt", 8);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);

            password = "password";
            PasswordHasher.Init("salt", 8);
            hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init("salt", 16);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void TestInit013()
        {
            string password = "password";
            Assert.AreEqual(PasswordHasher.GetHash(password, "salt"), PasswordHasher.GetHash(password, "salt"));

            password = "password";
            Assert.AreNotEqual(PasswordHasher.GetHash(password, "salt"), PasswordHasher.GetHash(password, "anotherSalt"));

            password = "password";
            PasswordHasher.Init("salt", 0);
            string hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init("salt", 0);
            string hash2 = PasswordHasher.GetHash(password);
            Assert.AreEqual(hash1, hash2);

            password = "password1";
            PasswordHasher.Init("salt", 0);
            hash1 = PasswordHasher.GetHash(password);
            password = "password2";
            PasswordHasher.Init("salt", 0);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);

            password = "password";
            PasswordHasher.Init("salt", 0);
            hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init("anotherSalt", 0);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void TestInit023()
        {
            string password = "password";
            Assert.AreEqual(PasswordHasher.GetHash(password, null, 8), PasswordHasher.GetHash(password, null, 8));

            password = "password";
            Assert.AreNotEqual(PasswordHasher.GetHash(password, null, 8), PasswordHasher.GetHash(password, null, 16));

            password = "password";
            PasswordHasher.Init(null, 8);
            string hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init(null, 8);
            string hash2 = PasswordHasher.GetHash(password);
            Assert.AreEqual(hash1, hash2);

            password = "password1";
            PasswordHasher.Init(null, 8);
            hash1 = PasswordHasher.GetHash(password);
            password = "password2";
            PasswordHasher.Init(null, 8);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);

            password = "password";
            PasswordHasher.Init(null, 8);
            hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init(null, 16);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void TestInit03()
        {
            string password = "password";
            Assert.AreEqual(PasswordHasher.GetHash(password), PasswordHasher.GetHash(password, null, 0));

            password = "password";
            PasswordHasher.Init(null, 0);
            string hash1 = PasswordHasher.GetHash(password);
            password = "password";
            PasswordHasher.Init(null, 0);
            string hash2 = PasswordHasher.GetHash(password);
            Assert.AreEqual(hash1, hash2);

            password = "password1";
            PasswordHasher.Init(null, 0);
            hash1 = PasswordHasher.GetHash(password);
            password = "password2";
            PasswordHasher.Init(null, 0);
            hash2 = PasswordHasher.GetHash(password);
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}
