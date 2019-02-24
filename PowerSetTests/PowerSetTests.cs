using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class PowerSetTests
    {
        [TestMethod()]
        public void Put_in_Empty_Set()
        {
            PowerSet<string> strSet = new PowerSet<string>(5);
            strSet.Put("word");

            Assert.IsTrue(strSet.size == 5);
            Assert.IsTrue(strSet.Get("word"));
        }
    }
}