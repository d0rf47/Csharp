using System;

namespace DoublyLinkedList
{
    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;
        internal Node<T> prev;

        public Node(T d)
        {
            data = d;
            next = null;
            prev = null;
        }
    }
}
