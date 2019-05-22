using System;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryHeapTests
{
    [TestClass]
    public class BinaryHeapTests
    {
        [TestMethod]
        public void MakeHeap_3_level_Heap()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 6, 5, 2, 3, 1, 7, 4 }, 2);

            Assert.AreEqual(heap.HeapArray[0], 7);
            Assert.IsTrue(heap.HeapSize == 7);
        }

        [TestMethod]
        public void MakeHeap_if_Root_Only()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 19 }, 0);

            Assert.AreEqual(heap.HeapArray[0], 19);
            Assert.IsTrue(heap.HeapSize == 1);
        }

        [TestMethod]
        public void GetMax_3_level_Heap()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 6, 5, 2, 3, 1, 7, 4 }, 2);
            int maxKey = heap.GetMax();

            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }

            Assert.AreEqual(maxKey, 7);
        }

        [TestMethod]
        public void GetMax_3_level_Heap_Another_InArr()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 8, 3, 2, 1, 16, 9, 7 }, 2);
            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            int maxKey = heap.GetMax();

            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }

            Assert.AreEqual(maxKey, 16);
        }
        [TestMethod]
        public void GetMax_2_level_Heap()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 1, 16, 8 }, 1);

            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            int maxKey = heap.GetMax();
            int maxKey2 = heap.GetMax();
            int maxKey3 = heap.GetMax();
            int maxKey4 = heap.GetMax();

            Assert.AreEqual(maxKey, 16);
            Assert.AreEqual(maxKey2, 8);
            Assert.AreEqual(maxKey3, 1);
            Assert.AreEqual(maxKey4, -1);
        }

        [TestMethod]
        public void GetMax_if_Root_Only()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 19 }, 0);

            Assert.AreEqual(heap.HeapArray[0], 19);
            Assert.IsTrue(heap.HeapSize == 1);

            int maxKey = heap.GetMax();
            Assert.AreEqual(maxKey, 19);
            Assert.AreEqual(heap.HeapArray[0], 0);
            Assert.IsTrue(heap.HeapSize == 0);
        }

        [TestMethod]
        public void GetMax_if_Heap_is_Empty()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 19 }, 0);

            int maxKey = heap.GetMax();
            int maxFromEmptyHeap = heap.GetMax();

            Assert.AreEqual(maxKey, 19);
            Assert.AreEqual(maxFromEmptyHeap, -1);
            Assert.IsTrue(heap.HeapSize == 0);
        }

        [TestMethod]
        public void Add_if_Heap_is_Full()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 6, 5, 2, 3, 1, 7, 4 }, 2);
            bool isAdded = heap.Add(170);

            Assert.AreEqual(heap.HeapArray[0], 7);
            Assert.IsTrue(heap.HeapSize == 7);
            Assert.IsFalse(isAdded);
        }
    }
}
