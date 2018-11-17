using System;
using System.Collections.Generic;
using BinarySearchTree;
using BinarySearchTreeTests.Models;
using NUnit.Framework;

namespace BinarySearchTreeTests
{
    [TestFixture]
    public class SearchTreeTests
    {
        [TestCase(new int[] { 10, 15, 20, 5, 6 }, ExpectedResult = "10 5 6 15 20 ")]
        [TestCase(new int[] { 18, 20, 5, 1, 55, 4 }, ExpectedResult = "18 5 1 4 20 55 ")]
        [TestCase(new int[] { 53, 532, 234, 1, 34, 2 }, ExpectedResult = "53 1 34 2 532 234 ")]
        public string SearchTree_PreorderMethod(int[] array)
        {
            var tree = new SearchTree<int>();

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

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, ExpectedResult = "6 5 20 15 10 ")]
        [TestCase(new int[] { 18, 20, 5, 1, 55, 4 }, ExpectedResult = "4 1 5 55 20 18 ")]
        [TestCase(new int[] { 53, 532, 234, 1, 34, 2 }, ExpectedResult = "2 34 1 234 532 53 ")]
        public string SearchTree_PostorderMethod(int[] array)
        {
            var tree = new SearchTree<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Postorder())
            {
                result += item + " ";
            }

            return result;
        }

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, ExpectedResult = "5 6 10 15 20 ")]
        [TestCase(new int[] { 18, 20, 5, 1, 55, 4 }, ExpectedResult = "1 4 5 18 20 55 ")]
        [TestCase(new int[] { 53, 532, 234, 1, 34, 2 }, ExpectedResult = "1 2 34 53 234 532 ")]
        public string SearchTree_InorderMethod(int[] array)
        {
            var tree = new SearchTree<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Inorder())
            {
                result += item + " ";
            }

            return result;
        }

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, ExpectedResult = 0)]
        public int SearchTree_ClearMethod(int[] array)
        {
            var tree = new SearchTree<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            tree.Clear();

            return tree.Count;
        }

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, 15, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15 }, 10, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15 }, 6, ExpectedResult = false)]
        public bool SearchTree_ContainsMethod(int[] array, int elem)
        {
            var tree = new SearchTree<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(elem);
        }

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, 15, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15 }, 10, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15 }, 6, ExpectedResult = false)]
        public bool SearchTree_ContainsMethod_CustomComparer(int[] array, int elem)
        {
            int compare(int a, int b)
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            }

            var tree = new SearchTree<int>(compare);

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(elem);
        }

        [TestCase(new int[] { 10, 15, 20, 5, 6 }, ExpectedResult = 5)]
        public int SearchTree_ContProperty(int[] array)
        {
            var tree = new SearchTree<int>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Count;
        }

        [TestCase(new int[] { 10, 15, 20 }, 10, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15, 20 }, 15, ExpectedResult = true)]
        [TestCase(new int[] { 10, 15, 20 }, 20, ExpectedResult = true)]
        public bool SearchTree_IEnumerableConstructor(int[] array, int elem)
        {
            var list = new List<int>(array);
            var tree = new SearchTree<int>(list);

            return tree.Contains(elem);
        }

        [Test]
        public void SearchTree_PreorderMethodString()
        {
            var array = new string[] { "dog", "city", "hello", "world" };
            var expectedResult = "dog city hello world ";
            var tree = new SearchTree<string>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Preorder())
            {
                result += item + " ";
            }

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void SearchTree_PostorderMethodString()
        {
            var array = new string[] { "dog", "city", "hello", "world" };
            var expectedResult = "city world hello dog ";
            var tree = new SearchTree<string>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Postorder())
            {
                result += item + " ";
            }

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void SearchTree_InorderMethodString()
        {
            var array = new string[] { "dog", "city", "hello", "world" };
            var expectedResult = "city dog hello world ";
            var tree = new SearchTree<string>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            string result = default;

            foreach (var item in tree.Inorder())
            {
                result += item + " ";
            }

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [TestCase("dog", ExpectedResult = true)]
        [TestCase("city", ExpectedResult = true)]
        [TestCase("hello", ExpectedResult = true)]
        [TestCase("test", ExpectedResult = false)]
        public bool SearchTree_ContainsMethodString(string elem)
        {
            var array = new string[] { "dog", "city", "hello" };
            var tree = new SearchTree<string>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(elem);
        }

        [TestCase("dog", ExpectedResult = true)]
        [TestCase("city", ExpectedResult = true)]
        [TestCase("hello", ExpectedResult = true)]
        [TestCase("test", ExpectedResult = false)]
        public bool SearchTree_ContainsMethodString_CustomComparer(string elem)
        {
            int compare(string a, string b)
            {
                if (a.CompareTo(b) > 0) return 1;
                if (a.CompareTo(b) < 0) return -1;
                return 0;
            }

            var array = new string[] { "dog", "city", "hello" };
            var tree = new SearchTree<string>(compare);

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(elem);
        }

        [TestCase(10, ExpectedResult = true)]
        [TestCase(15, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        public bool SearchTree_CustomBook(int elem)
        {
            var array = new Book[] { new Book(10), new Book(15), new Book(20) };
            var tree = new SearchTree<Book>();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(new Book(elem));
        }

        [TestCase(10, ExpectedResult = true)]
        [TestCase(15, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        public bool SearchTree_CustomBook_CustomComparer(int elem)
        {
            int compare(Book a, Book b)
            {
                if (a.Price > b.Price) return 1;
                if (a.Price < b.Price) return -1;
                return 0;
            }

            var array = new Book[] { new Book(10), new Book(15), new Book(20) };
            var tree = new SearchTree<Book>(compare);

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(new Book(elem));
        }

        [TestCase(10, 15, ExpectedResult = true)]
        [TestCase(15, 55, ExpectedResult = true)]
        [TestCase(20, 45, ExpectedResult = true)]
        public bool SearchTree_CustomPoint_CustomComparer(int first, int second)
        {
            int compare(Point a, Point b)
            {
                if (a.X > b.X) return 1;
                if (a.X < b.X) return -1;
                return 0;
            }

            var array = new Point[] { new Point(10, 15), new Point(15, 55), new Point(20, 45) };
            var tree = new SearchTree<Point>(compare);

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            return tree.Contains(new Point(first, second));
        }

        [Test]
        public void SearchTree_ConstructorNull_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new SearchTree<int>(null, null));

        [Test]
        public void SearchTree_MethodAdd_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new SearchTree<string>().Add(null));

        [Test]
        public void SearchTree_MethodContains_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new SearchTree<string>().Contains(null));
        

    }
}
