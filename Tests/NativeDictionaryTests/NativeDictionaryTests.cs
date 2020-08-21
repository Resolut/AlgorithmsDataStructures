using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class NativeDictionaryTests
    {
        [TestMethod()]
        public void IsKeyTest()
        {
            NativeDictionary<string> profs = new NativeDictionary<string>(5);
            string key = "Dmitry";
            string value = "engineer";

            profs.Put(key, value);

            Assert.IsTrue(profs.IsKey(key));
            Assert.IsFalse(profs.IsKey("football player"));
        }

        [TestMethod()]
        public void IsKey_in_Empty_Dict()
        {
            NativeDictionary<string> clients = new NativeDictionary<string>(3);
            string key = "Laura";

            Assert.IsFalse(clients.IsKey(key));
            Assert.IsFalse(clients.IsKey("John"));
        }

        [TestMethod()]
        public void PutTest()
        {
            NativeDictionary<string> programmers = new NativeDictionary<string>(5);

            string key = "Jimmy";
            string value = "Nube";
            string key2 = "Li";
            string value2 = "Junior";
            string key3 = "Gordon";
            string value3 = "Middle";
            string key4 = "Fred";
            string value4 = "Senior";
            string key5 = "Jessica";
            string value5 = "Team Lead";

            programmers.Put(key, value);
            programmers.Put(key2, value2);
            programmers.Put(key3, value3);
            programmers.Put(key4, value4);
            programmers.Put(key5, value5);

            int expectedSize = 5;
            string expectedKey = "Gordon";
            string expectedValue = "Middle";
            int actualSize = programmers.size;
            string actualKey = programmers.slots[2];
            string actualValue = programmers.values[2];

            Assert.IsTrue(programmers.IsKey(key));
            Assert.IsTrue(programmers.IsKey("Jessica"));
            Assert.AreEqual(expectedSize, actualSize);
            Assert.AreEqual(expectedKey, actualKey);
            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod()]
        public void Get_in_Empty_Dict()
        {
            NativeDictionary<string> clients = new NativeDictionary<string>(3);
            string key = "Laura";

            Assert.IsNull(clients.Get(key));
        }

        [TestMethod()]
        public void Get_if_Dict_Has_Key()
        {
            NativeDictionary<string> clients = new NativeDictionary<string>(6);
            string[] names = { "Laura", "Patrik", "Stuart", "Leonard", "Delcin" };
            string[] categories = { "New", "Regular", "VIP", "Deptor" };

            Console.WriteLine("=== LOG ===");


            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}",
                                clients.HashFun(names[0]),
                                clients.HashFun(names[1]),
                                clients.HashFun(names[2]),
                                clients.HashFun(names[3]),
                                clients.HashFun(names[4]));

            clients.Put(names[0], categories[1]);
            clients.Put(names[1], categories[0]);
            clients.Put(names[2], categories[3]);
            clients.Put(names[3], categories[2]);
            clients.Put(names[4], categories[1]);

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}",
                                clients.Get(names[0]),
                                clients.Get(names[1]),
                                clients.Get(names[2]),
                                clients.Get(names[3]),
                                clients.Get(names[4]));
            Console.WriteLine("=== LOG END ===");

            string actualValue = clients.Get(names[0]);
            string actualValue2 = clients.Get(names[1]);
            string actualValue3 = clients.Get(names[2]);
            string expectedValue4 = "VIP";
            string actualValue4 = clients.Get(names[3]);
            string expectedValue5 = "Regular";
            string actualValue5 = clients.Get(names[4]);

            Assert.IsNull(actualValue);
            Assert.IsNull(actualValue2);
            Assert.IsNull(actualValue3);
            Assert.AreEqual(expectedValue4, actualValue4);
            Assert.AreEqual(expectedValue5, actualValue5);
            Assert.IsNull(clients.Get("Hue"));
            Assert.IsTrue(clients.size == 6);
        }
    }
}