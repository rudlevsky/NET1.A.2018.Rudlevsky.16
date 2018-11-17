using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Models
{
    public class Node<T>
    {
        public Node<T> left;
        public Node<T> right;

        public T Data { get; set; }
        public Node(T data) => Data = data;
    }
}
