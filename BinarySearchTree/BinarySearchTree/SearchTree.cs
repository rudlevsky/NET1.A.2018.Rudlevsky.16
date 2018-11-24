using BinarySearchTree.Models;
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class SearchTree<T>
    {
        private Node<T> root;
        private Node<T> currentNode;
        private Comparison<T> comparer;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public SearchTree()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new NotImplementedException("Interface IComparable is not implemented.");
            }

            comparer = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Constructor with one parameter.
        /// </summary>
        /// <param name="comparison">Delegate for comparison.</param>
        public SearchTree(Comparison<T> comparison) => comparer = comparison ??
            throw new ArgumentNullException($"{nameof(comparison)} was null.");

        /// <summary>
        /// Constructor with one parameter.
        /// </summary>
        /// <param name="collection">Collection which initizlizes tree.</param>
        public SearchTree(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} was null.");
            }

            comparer = Comparer<T>.Default.Compare;
            AddCollection(collection);
        }

        /// <summary>
        /// Constructor with two parameters.
        /// </summary>
        /// <param name="collection">Collection which initizlizes tree.</param>
        /// <param name="comparison">Delegate for comparison.</param>
        public SearchTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} was null.");
            }

            comparer = comparison ?? throw new ArgumentNullException($"{nameof(comparison)} was null.");
            AddCollection(collection);
        }

        /// <summary>
        /// Current count of all elements in the tree.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds element in the tree.
        /// </summary>
        /// <param name="nodeElem">Element for adding.</param>
        public void Add(T nodeElem)
        {
            if (nodeElem == null)
            {
                throw new ArgumentNullException($"{nameof(nodeElem)} was null.");
            }

            if(root == null)
            {
                root = new Node<T>(nodeElem);
                currentNode = root;
                Count++;
                return;
            }

            Insert(nodeElem);
        }

        /// <summary>
        /// Checks if element is a part of the tree.
        /// </summary>
        /// <param name="elem">Elment for checking.</param>
        /// <returns>Result of the checking.</returns>
        public bool Contains(T elem)
        {
            if(elem == null)
            {
                throw new ArgumentNullException($"{nameof(elem)} can't be equal to null.");
            }

            while (currentNode != null)
            {
                if (comparer(elem, currentNode.Data) == 0)
                {
                    currentNode = root;
                    return true;
                }

                if (comparer(elem, currentNode.Data) > 0)
                {
                    currentNode = currentNode.right;
                    continue;
                }

                if (comparer(elem, currentNode.Data) < 0)
                {
                    currentNode = currentNode.left;
                }
            }

            currentNode = root;

            return false;
        }

        /// <summary>
        /// Clears all nodes from the tree.
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Preorder getting elements.
        /// </summary>
        /// <returns>Taken element.</returns>
        public IEnumerable<T> Preorder() => Preorder(root);

        /// <summary>
        /// Inorder getting elements.
        /// </summary>
        /// <returns>Taken element.</returns>
        public IEnumerable<T> Inorder() => Inorder(root);

        /// <summary>
        /// Postorder getting elements.
        /// </summary>
        /// <returns>Taken element.</returns>
        public IEnumerable<T> Postorder() => Postorder(root);

        private void AddCollection(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        private void Insert(T nodeElem)
        {
            while (true)
            {
                if (comparer(nodeElem, currentNode.Data) >= 0)
                {

                    if (currentNode.right == null)
                    {
                        currentNode.right = new Node<T>(nodeElem);
                        break;
                    }

                    currentNode = currentNode.right;
                    continue;
                }

                if (comparer(nodeElem, currentNode.Data) < 0)
                {

                    if (currentNode.left == null)
                    {
                        currentNode.left = new Node<T>(nodeElem);
                        break;
                    }

                    currentNode = currentNode.left;
                }
            }

            currentNode = root;
            Count++;
        }

        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.Data;

            if (node.left != null)
            {
                foreach (var item in Preorder(node.left))
                {
                    yield return item;
                }
            }

            if (node.right != null)
            {
                foreach (var item in Preorder(node.right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.left != null)
            {
                foreach (var item in Inorder(node.left))
                {
                    yield return item;
                }
            }

            yield return node.Data;

            if (node.right != null)
            {
                foreach (var item in Inorder(node.right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.left != null)
            {
                foreach (var item in Postorder(node.left))
                {
                    yield return item;
                }
            }

            if (node.right != null)
            {
                foreach (var item in Postorder(node.right))
                {
                    yield return item;
                }
            }

            yield return node.Data;
        }
    }
}
