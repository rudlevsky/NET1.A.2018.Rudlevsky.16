using System;
using BinarySearchTree;
using NUnit.Framework;

namespace BinarySearchTreeTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(ExpectedResult = "10 5 6 15 20 ")]
        [TestCase(ExpectedResult = "10 5 6 15 20 ")]
        [TestCase(ExpectedResult = "10 5 6 15 20 ")]
        public string SearchTree_PreorderMethod()
        {
            var tree = new SearchTree<int>();
            var array = new int[5] { 10, 15, 20, 5, 6 };

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Preorder())
            {
                result += item + " ";
            }

            return result;
        }
    }
}
