using System;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryHeapTests
{
    [TestClass]
    public class BinaryHeapTests
    {
        [TestMethod]
        public void Add_with_Root_only()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 6, 5, 2, 3, 1, 7, 4 }, 2);

            Assert.AreEqual(heap.HeapArray[0], 7);
        }

        [TestMethod]
        public void GetMax_3_level_Tree()
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
        public void GetMax_3_level_Tree_Another_InArr()
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
        public void GetMax_2_level_Tree_Another_InArr()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 1, 16, 8 }, 1);
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
            Console.WriteLine();

            int maxKey2 = heap.GetMax();
            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            int maxKey3 = heap.GetMax();
            foreach (var item in heap.HeapArray)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            int maxKey4 = heap.GetMax();

            Assert.AreEqual(maxKey, 16);
            Assert.AreEqual(maxKey2, 8);
            Assert.AreEqual(maxKey3, 1);
            Assert.AreEqual(maxKey4, -1);
        }
    }
}
