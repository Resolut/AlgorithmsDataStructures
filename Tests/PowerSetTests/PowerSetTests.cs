using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class PowerSetTests
    {
        [TestMethod()]
        public void Put_in_Empty_Set()
        {
            PowerSet<string> strSet = new PowerSet<string>();
            strSet.Put("word");

            Assert.IsTrue(strSet.Size() == 1);
            Assert.IsTrue(strSet.Get("word"));
        }

        [TestMethod()]
        public void Put_if_Set_Already_Has_This_Elem()
        {
            PowerSet<string> strSet = new PowerSet<string>();
            strSet.Put("word");

            Assert.IsTrue(strSet.Size() == 1);
            Assert.IsTrue(strSet.Get("word"));

            strSet.Put("word");

            Assert.IsTrue(strSet.Size() == 1);
        }

        [TestMethod()]
        public void Put_Several_Values_in_Set()
        {
            PowerSet<string> strSet = new PowerSet<string>();

            strSet.Put("word");

            Assert.IsTrue(strSet.Size() == 1);

            strSet.Put("Lord");

            Assert.IsTrue(strSet.Size() == 2);

            strSet.Put("cord");

            Assert.IsTrue(strSet.Size() == 3);

            Assert.IsTrue(strSet.Get("word"));
            Assert.IsTrue(strSet.Get("Lord"));
            Assert.IsTrue(strSet.Get("cord"));
            Assert.IsFalse(strSet.Get("lord"));

        }

        [TestMethod()]
        public void Remove_if_Set_Has_Value_()
        {
            PowerSet<string> strSet = new PowerSet<string>();

            strSet.Put("word");

            Assert.IsTrue(strSet.Size() == 1);

            strSet.Put("Lord");

            Assert.IsTrue(strSet.Size() == 2);

            strSet.Put("cord");

            Assert.IsTrue(strSet.Size() == 3);

            bool isRemoved = strSet.Remove("Lord");

            Assert.IsTrue(strSet.Get("word"));
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(strSet.Get("cord"));
            Assert.IsFalse(strSet.Get("Lord"));
            Assert.IsTrue(strSet.Size() == 2);
        }

        [TestMethod()]
        public void Remove_if_Set_Is_Empty()
        {
            PowerSet<string> strSet = new PowerSet<string>();

            bool isRemoved = strSet.Remove("Lord");

            Assert.IsFalse(isRemoved);
            Assert.IsTrue(strSet.Size() == 0);
        }

        [TestMethod()]
        public void Intersection_has_2_values()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(3);
            set2.Put(4);
            set2.Put(6);
            set2.Put(9);

            PowerSet<int> interSet = testSet.Intersection(set2);
 
            Assert.IsTrue(interSet.Size() == 2);
            Assert.IsTrue(interSet.Get(3));
            Assert.IsTrue(interSet.Get(4));

        }

        [TestMethod()]
        public void Intersection_has_not_values()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(5);
            set2.Put(6);
            set2.Put(7);
            set2.Put(8);

            PowerSet<int> interSet = testSet.Intersection(set2);

            Assert.IsTrue(interSet.Size() == 0);
        }

        [TestMethod()]
        public void Intersection_Is_Both_Sets_has_not_values()
        {
            PowerSet<int> testSet = new PowerSet<int>();
            PowerSet<int> set2 = new PowerSet<int>();

            PowerSet<int> interSet = testSet.Intersection(set2);

            Assert.IsTrue(interSet.Size() == 0);
        }

        [TestMethod()]
        public void Union_both_Sets_has_values()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(5);
            set2.Put(6);
            set2.Put(7);
            set2.Put(8);

            PowerSet<int> interSet = testSet.Union(set2);

            Assert.IsTrue(interSet.Size() == 8);
            Assert.IsTrue(interSet.Get(1));
            Assert.IsTrue(interSet.Get(2));
            Assert.IsTrue(interSet.Get(3));
            Assert.IsTrue(interSet.Get(4));
            Assert.IsTrue(interSet.Get(5));
            Assert.IsTrue(interSet.Get(6));
            Assert.IsTrue(interSet.Get(7));
            Assert.IsTrue(interSet.Get(8));
        }

        [TestMethod()]
        public void Union_if_One_Set_is_Empty()
        {
            PowerSet<int> testSet = new PowerSet<int>();
            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(1);
            set2.Put(2);
            set2.Put(3);
            set2.Put(4);

            PowerSet<int> interSet = testSet.Union(set2);

            Assert.IsTrue(interSet.Size() == 4);
            Assert.IsTrue(interSet.Get(1));
            Assert.IsTrue(interSet.Get(2));
            Assert.IsTrue(interSet.Get(3));
            Assert.IsTrue(interSet.Get(4));

        }

        [TestMethod()]
        public void Union_if_Second_Set_is_Empty()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            PowerSet<int> interSet = testSet.Union(set2);

            Assert.IsTrue(interSet.Size() == 4);
            Assert.IsTrue(interSet.Get(1));
            Assert.IsTrue(interSet.Get(2));
            Assert.IsTrue(interSet.Get(3));
            Assert.IsTrue(interSet.Get(4));

        }

        [TestMethod()]
        public void Union_Both_Sets_Are_Empty()
        {
            PowerSet<int> testSet = new PowerSet<int>();
            PowerSet<int> set2 = new PowerSet<int>();

            PowerSet<int> interSet = testSet.Union(set2);

            Assert.IsTrue(interSet.Size() == 0);
        }

        [TestMethod()]
        public void Difference_Both_Sets_Are_Empty()
        {
            PowerSet<int> testSet = new PowerSet<int>();
            PowerSet<int> set2 = new PowerSet<int>();

            PowerSet<int> interSet = testSet.Difference(set2);

            Assert.IsTrue(interSet.Size() == 0);
        }

        [TestMethod()]
        public void Difference_Both_Sets_Has_Different_Values()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(5);
            set2.Put(6);
            set2.Put(7);
            set2.Put(8);

            PowerSet<int> interSet = testSet.Difference(set2);

            Assert.IsTrue(interSet.Size() == 4);
            Assert.IsTrue(interSet.Get(1));
            Assert.IsTrue(interSet.Get(2));
            Assert.IsTrue(interSet.Get(3));
            Assert.IsTrue(interSet.Get(4));
        }

        [TestMethod()]
        public void Difference_if_Both_Sets_Have_Cross()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(2);
            set2.Put(3);
            set2.Put(7);
            set2.Put(8);

            PowerSet<int> interSet = testSet.Difference(set2);

            Assert.IsTrue(interSet.Size() == 2);
            Assert.IsTrue(interSet.Get(1));
            Assert.IsTrue(interSet.Get(4));
        }

        [TestMethod()]
        public void Subset_if_One_Set_Has_Second_Set()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(1);
            set2.Put(2);
            set2.Put(3);

            bool isSubset = testSet.IsSubset(set2);

            Assert.IsTrue(testSet.Size() == 4);
            Assert.IsTrue(isSubset);
            Assert.IsTrue(set2.Size() == 3);
        }

        [TestMethod()]
        public void Subset_if_Second_Set_Includes_One_Set()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);
            testSet.Put(5);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(1);
            set2.Put(2);
            set2.Put(3);
            set2.Put(4);
            set2.Put(5);
            set2.Put(6);
            set2.Put(7);
            set2.Put(8);

            bool isSubset = testSet.IsSubset(set2);

            Assert.IsTrue(testSet.Size() == 4);
            Assert.IsFalse(isSubset);
            Assert.IsTrue(set2.Size() == 8);
        }

        [TestMethod()]
        public void Subset_if_One_Set_Includes_Second_Set_Incompletely()
        {
            PowerSet<int> testSet = new PowerSet<int>();

            testSet.Put(1);
            testSet.Put(2);
            testSet.Put(3);
            testSet.Put(4);
            testSet.Put(5);
            testSet.Put(6);

            PowerSet<int> set2 = new PowerSet<int>();

            set2.Put(1);
            set2.Put(3);
            set2.Put(4);
            set2.Put(5);
            set2.Put(6);
            set2.Put(7);

            bool isSubset = testSet.IsSubset(set2);

            Assert.IsTrue(testSet.Size() == 6);
            Assert.IsFalse(isSubset);
            Assert.IsTrue(set2.Size() == 6);
        }
    }
}