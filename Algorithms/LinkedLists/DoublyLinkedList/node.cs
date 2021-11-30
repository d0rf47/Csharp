using System;

namespace DoublyLinkedList
{
    internal class Node
    {
        internal int data;
        internal Node next;
        internal Node prev;

        public Node(int d)
        {
            data = d;
            next = null;
            prev = null;
        }
    }
}
