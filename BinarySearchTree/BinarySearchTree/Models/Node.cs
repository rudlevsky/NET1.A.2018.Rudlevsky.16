
namespace BinarySearchTree.Models
{
    /// <summary>
    /// Class represents a node of the tree.
    /// </summary>
    /// <typeparam name="T">Type of the data in node.</typeparam>
    public class Node<T>
    {
        public Node(T data) => Data = data;

        public Node<T> left;
        public Node<T> right;
        public T Data { get; set; }
    }
}
