using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynArray.Tests
{
    [TestClass()]
    public class DynArrayTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            Console.WriteLine(testDynArr.ToString());
        }
    }
}