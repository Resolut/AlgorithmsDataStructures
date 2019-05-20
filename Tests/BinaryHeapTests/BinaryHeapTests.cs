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
    }
}
