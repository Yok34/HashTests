using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static HashTab.Program;

namespace HashTab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOfThreeElements()
        {
            var hashTable = new HashTable(3);
            var a = 1;
            var b = "jasdkdmv";
            var c = true;
            var keyOfa = 66;
            var keyOfb = new[] { 1, 2, 3 };
            var keyOfc = "ab";

            hashTable.PutPair(keyOfa, a);
            hashTable.PutPair(keyOfb, b);
            hashTable.PutPair(keyOfc, c);

            Assert.AreEqual(a, hashTable.GetValueByKey(keyOfa));
            Assert.AreEqual(b, hashTable.GetValueByKey(keyOfb));
            Assert.AreEqual(c, hashTable.GetValueByKey(keyOfc));
        }
        [TestMethod]
        public void TestTheSameKey()
        {
            var hashTable = new HashTable(2);
            var a = 734;
            var b = 's';
            var key = "52ns";

            hashTable.PutPair(key, a);
            hashTable.PutPair(key, b);

            Assert.AreEqual(b, hashTable.GetValueByKey(key));
        }
        [TestMethod]
        public void TenThousandAndFindOne()
        {
            var hashTable = new HashTable(10000);
            var random = new Random();
            var flag = random.Next(10000);
            var foundValue = 0;
            var keyFound = 0;
            for (var i = 0; i < 10000;i++)
            {
                var key = i;
                var value = random.Next();
                hashTable.PutPair(key, value);

                if (flag == i)
                {
                    foundValue = value;
                    keyFound = key;
                }
            }
            Assert.AreEqual(foundValue, hashTable.GetValueByKey(keyFound));
        }
        [TestMethod]
        public void TenThousandAndFindThousand()
        {
            var hashTable = new HashTable(10000);
            var random = new Random();
            for (var i = 0; i < 10000; i++)
            {
                var value = random.Next();
                hashTable.PutPair(i, value);
            }
            for (var i=0; i<1000;i++)
            {
                Assert.IsNull(hashTable.GetValueByKey(i + 43589));
            }
        }
    }
}
