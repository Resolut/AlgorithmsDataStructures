using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        [TestMethod()]
        public void HashFun_if_String_is_Empty()
        {
            HashTable hTable = new HashTable(19, 3);
            string emptyStr = "";

            Assert.IsTrue(hTable.HashFun(emptyStr) == 0);
        }

        [TestMethod()]
        public void HashFun_if_String_has_chars()
        {
            HashTable hTable = new HashTable(19, 3);
            string str = "A";
            string str2 = "Test";
            string str3 = "TEST";
            string str4 = "Test: 1";

            Assert.IsTrue(hTable.HashFun(str) == 8);
            Assert.IsTrue(hTable.HashFun(str2) == 17);
            Assert.IsTrue(hTable.HashFun(str3) == 16);
            Assert.IsTrue(hTable.HashFun(str4) == 4);
        }

        [TestMethod()]
        public void SeekSlot_if_hTable_is_Null()
        {
            HashTable hTable = new HashTable(19, 3);

            Assert.IsTrue(hTable.SeekSlot("TEST") == 16);
        }

        [TestMethod()]
        public void SeekSlot_if_Slot_Already_Has_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "TEST";
            string value2 = "AA";

            int expectedStartSlot = 16;
            int startSlot = hTable.SeekSlot(value);
            hTable.Put(value);

            Assert.AreEqual(expectedStartSlot, startSlot);
            Assert.AreEqual(value, hTable.slots[16]);

            int expectedTargetSlot = 0;
            int targetSlot = hTable.SeekSlot(value2);

            Assert.AreEqual(expectedTargetSlot, targetSlot);
        }

        [TestMethod()]
        public void SeekSlot_if_HashTable_is_full()
        {
            HashTable hTable = new HashTable(5, 3);
            string value1 = "A";
            string value2 = "B";
            string value3 = "C";
            string value4 = "D";
            string value5 = "E";
            string target = "F";

            hTable.Put(value1);
            hTable.Put(value2);
            hTable.Put(value3);
            hTable.Put(value4);
            hTable.Put(value5);

            int expectedFailSlot = -1;
            int startSlot = hTable.SeekSlot(target);
            Assert.AreEqual(expectedFailSlot, startSlot);
            Assert.AreEqual(value1, hTable.slots[0]);
        }

        [TestMethod()]
        public void PutTest_if_hTable_is_empty()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "Test";

            int expectedSlot = 17;
            int actualSlot = hTable.Put(value);

            Assert.AreEqual(expectedSlot, actualSlot);
            Assert.AreEqual(value, hTable.slots[17]);
        }

        [TestMethod()]
        public void Put_if_hTable_Slot_is_already_Has_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "TEST";
            string value2 = "AA";

            int expectedSlot = 16;
            int actualSlot = hTable.Put(value);

            Assert.AreEqual(expectedSlot, actualSlot);
            Assert.AreEqual(value, hTable.slots[16]);

            int failSlot = hTable.Put(value2);
            int expectedFail = -1;

            Assert.AreEqual(expectedFail, failSlot);
            Assert.AreEqual(value, hTable.slots[16]);
        }

        [TestMethod()]
        public void Find_If_value_Exists_in_HashTable()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "Test";

            hTable.Put(value);

            int expectedSlot = 17;
            int actualFoundSlot = hTable.Find(value);

            Assert.AreEqual(expectedSlot, actualFoundSlot);
            Assert.AreEqual(value, hTable.slots[17]);
        }

        [TestMethod()]
        public void Find_If_HashTable_Has_not_the_Value()
        {
            HashTable hTable = new HashTable(19, 3);
            string value = "AA";
            string target = "TEST";

            hTable.Put(value);

            int expectedFailSlot = -1;
            int actualFoundSlot = hTable.Find(target);

            Assert.AreEqual(expectedFailSlot, actualFoundSlot);
            Assert.AreEqual(value, hTable.slots[16]);
        }
    }
}