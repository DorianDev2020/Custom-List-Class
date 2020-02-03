using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListProj;

namespace CustomListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class CustomListTest
        {

            [TestMethod]
            public void Add_VerifyZeroIndex()
            {
                CustomList<int> list = new CustomList<int>();
                int value = 50;

                list.Add(value);

                Assert.AreEqual(value, list[0]);
            }
            [TestMethod]
            public void Add_VerifyLastIndex()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 5;
                int valueTwo = 10;
                int valueThree = 15;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);

                Assert.AreEqual(valueThree, list[2]);
            }
            [TestMethod]
            public void Add_VerifyCountAfterInitialAdd()
            {
                CustomList<int> list = new CustomList<int>();
                int value = 77;
                int expected = 1;

                list.Add(value);

                Assert.AreEqual(expected, list.Count);
            }
            [TestMethod]
            public void Add_VerifyCountAfterThreeAddCalls()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 2;
                int valueTwo = 4;
                int valueThree = 6;
                int expected = 3;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);

                Assert.AreEqual(expected, list.Count);
            }
            [TestMethod]
            public void Add_VerifyInitialCapacity()
            {
                //verify capacity
                CustomList<int> list = new CustomList<int>();
                int expected = 0;

                Assert.AreEqual(expected, list.Capacity);
            }
            public void Add_VerifyFirstItemCapacity()
            {
                CustomList<int> list = new CustomList<int>();
                int expected = 4;

                list.Add(4);

                Assert.AreEqual(expected, list.Capacity);
            }
            [TestMethod]
            public void Add_VerifyCapacityIncrements()
            {

                CustomList<int> list = new CustomList<int>();
                int valueOne = 1;
                int valueTwo = 3;
                int valueThree = 5;
                int valueFour = 7;
                int valueFive = 9;
                int expected = 8;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Add(valueFour);
                list.Add(valueFive);

                Assert.AreEqual(expected, list.Capacity);
            }
            [TestMethod]
            public void Add_VerifyCountWhenExceeded()
            {

                CustomList<int> list = new CustomList<int>();
                int valueOne = 10;
                int valueTwo = 20;
                int valueThree = 30;
                int valueFour = 40;
                int valueFive = 50;
                int expected = 5;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Add(valueFour);
                list.Add(valueFive);

                Assert.AreEqual(expected, list.Count);
            }
            [TestMethod]
            public void Add_VerifyValueWhenCapacityExceeded()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 11;
                int valueTwo = 21;
                int valueThree = 31;
                int valueFour = 41;
                int valueFive = 51;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Add(valueFour);
                list.Add(valueFive);

                Assert.AreEqual(valueFive, list[4]);
            }

            // REMOVE TESTS
            [TestMethod]
            public void Remove_VerifyZeroIndexAfterRemove()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 1;
                int valueTwo = 2;
                int valueThree = 3;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Remove(valueOne);

                Assert.AreEqual(valueTwo, list[0]);
            }
            [TestMethod]
            public void Remove_VerifyFirstIndexAfterRemove()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 1;
                int valueTwo = 2;
                int valueThree = 3;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Remove(valueOne);

                Assert.AreEqual(valueThree, list[1]);
            }
            [TestMethod]
            public void Remove_VerifyOnlyFirstValueRemoved()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 20;
                int valueTwo = 30;
                int valueThree = 40;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Add(valueOne);
                list.Remove(valueOne);

                Assert.AreEqual(valueOne, list[2]);
            }
            [TestMethod]
            public void Remove_VerifyCountAfterRemove()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 10;
                int valueTwo = 20;
                int valueThree = 30;
                int expected = 2;

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.Remove(valueTwo);

                Assert.AreEqual(expected, list.Count);
            }
            [TestMethod]
            public void ToString_VerifyIntNowString()
            {
                CustomList<int> list = new CustomList<int>();
                int valueOne = 2;
                int valueTwo = 4;
                int valueThree = 6;
                string expected = "2, 4, 6";

                list.Add(valueOne);
                list.Add(valueTwo);
                list.Add(valueThree);
                list.ToString();

                Assert.AreEqual(expected, list.ToString());
            }
            [TestMethod]
            public void ToString_VerifyStringNowString()
            {
                CustomList<string> list = new CustomList<string>();
                string nameone = "Ben";
                string nametwo = "Sean";
                string namethree = "Brent";
                string expected = "Ben, Sean, Brent";

                list.Add(nameone);
                list.Add(nametwo);
                list.Add(namethree);
                list.ToString();

                Assert.AreEqual(expected, list.ToString());
            }
            [TestMethod]
            public void OverloadAddOperator_VerifyInt()
            {
                CustomList<int> listOne = new CustomList<int>() { 1, 2, 3 };
                CustomList<int> listTwo = new CustomList<int>() { 4, 5, 6 };
                CustomList<int> expected = new CustomList<int>() { 1, 2, 3, 4, 5, 6 };
                CustomList<int> result = new CustomList<int>();

                result = listOne + listTwo;

                Assert.AreEqual(expected.ToString(), result.ToString());
            }
            [TestMethod]
            public void OverloadAddOperator_VerifyString()
            {
                CustomList<string> listOne = new CustomList<string>() { "One", "Two", "Three" };
                CustomList<string> listTwo = new CustomList<string>() { "Four", "Five", "Six" };
                CustomList<string> expected = new CustomList<string>() { "One", "Two", "Three", "Four", "Five", "Six" };
                CustomList<string> result = new CustomList<string>();

                result = listOne + listTwo;

                Assert.AreEqual(expected.ToString(), result.ToString());
            }
            [TestMethod]
            public void OverloadMinusOperator_VerifyInt()
            {
                CustomList<int> listOne = new CustomList<int>() { 1, 3, 5 };
                CustomList<int> listTwo = new CustomList<int>() { 2, 1, 6 };
                CustomList<int> expected = new CustomList<int>() { 3, 5 };
                CustomList<int> result = new CustomList<int>();

                result = listOne - listTwo;

                Assert.AreEqual(expected.ToString(), result.ToString());
            }
            [TestMethod]
            public void OverloadMinusOperator_VerifyString()
            {
                CustomList<string> listOne = new CustomList<string>() { "Sarah", "Becky", "Myiah" };
                CustomList<string> listTwo = new CustomList<string>() { "Bridgette", "Dani", "Elza" };
                CustomList<string> expected = new CustomList<string>() { "Are", "Awsome" };
                CustomList<string> result = new CustomList<string>();

                result = listOne - listTwo;

                Assert.AreEqual(expected.ToString(), result.ToString());
            }
            [TestMethod]
            public void Zip_VerifyZeroIndex()
            {
                CustomList<int> odd = new CustomList<int>() { 1, 3, 5, 7 };
                CustomList<int> even = new CustomList<int>() { 2, 4, 6 };
                int expected = 1;
                CustomList<int> result = new CustomList<int>();

                result = result.Zip(odd, even);

                Assert.AreEqual(expected, result[0]);
            }

            [TestMethod]
            public void Zip_VerifyAlternateNumbers()
            {
                CustomList<int> odd = new CustomList<int>() { 1, 3, 5, 7 };
                CustomList<int> even = new CustomList<int>() { 2, 4, 6 };
                CustomList<int> expected = new CustomList<int> { 1, 2, 3, 4, 5, 6 };
                CustomList<int> result = new CustomList<int>();

                result = result.Zip(odd, even);

                Assert.AreEqual(expected.ToString(), result.ToString());
            }
            [TestMethod]
            public void Zip_VerifyCountFirstList()
            {
                CustomList<int> odd = new CustomList<int>() { 1, 3, 5, 7 };
                CustomList<int> even = new CustomList<int>() { 2, 4, 6 };
                CustomList<int> result = new CustomList<int>();
                int expected = 6;

                result = result.Zip(odd, even);

                Assert.AreEqual(expected, result.Count);
            }
            [TestMethod]
            public void Zip_VerifyFirstListShorter()
            {
                CustomList<int> odd = new CustomList<int>() { 1, 3, 5 };
                CustomList<int> even = new CustomList<int>() { 2, 4, 6, 8, 10 };
                CustomList<int> result = new CustomList<int>();
                int expected = 6;

                result = result.Zip(odd, even);

                Assert.AreEqual(expected, result.Count);
            }
            [TestMethod]
            public void Zip_Capacity()
            {
                CustomList<int> odd = new CustomList<int>() { 1, 3, 5, 7 };
                CustomList<int> even = new CustomList<int>() { 2, 4, 6 };
                CustomList<int> result = new CustomList<int>();
                int expected = 8;

                result = result.Zip(odd, even);

                Assert.AreEqual(expected, result.Capacity);
            }
            [TestMethod]
            [ExpectedException(typeof(IndexOutOfRangeException))]
            public void Indexer_OutOfBounds_Exception()
            {
                CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4 };

                int result = list[-1];
            }
            [TestMethod]
            public void Sort_VerifyIntOrder()
            {
                CustomList<int> list = new CustomList<int>() { 2, 1, 5, 4, 6, 7, 3 };
                CustomList<int> expected = new CustomList<int>() { 1, 2, 3, 4, 5, 6, 7 };

                list.Sort();

                Assert.AreEqual(expected.ToString(), list.ToString());
            }
            [TestMethod]
            public void Sort_VerifyIntOrderAlreadySorted()
            {
                CustomList<int> list = new CustomList<int>() { 3, 17, 23, 29, 37, 47, 71 };
                CustomList<int> expected = new CustomList<int>() { 3, 17, 23, 29, 37, 47, 71 };

                list.Sort();

                Assert.AreEqual(expected.ToString(), list.ToString());
            }
            [TestMethod]
            public void Sort_VerifyStringOrder()
            {
                CustomList<string> list = new CustomList<string>() { "c", "f", "a", "d", "e", "g", "b" };
                CustomList<string> expected = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g" };

                list.Sort();

                Assert.AreEqual(expected.ToString(), list.ToString());
            }
            [TestMethod]
            public void Sort_VerifyStringOrderAlreadySorted()
            {
                CustomList<string> list = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g" };
                CustomList<string> expected = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g" };

                list.Sort();

                Assert.AreEqual(expected.ToString(), list.ToString());
            }
        }
    }
}
