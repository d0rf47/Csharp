using System;
using DoublyLinkedList;

/**
* Data Structure useful for order processing
* Elems are added to back (enqueue) and removed from front (dequeue)
* incldes peek method to view item at front
* FIFO order
*/
namespace Queue
{
    class Queue<T>
    {
        DList<T> list;

        public void enqueue(T data)
        {
            list.PushBack(data);
        }

        public T dequeue()
        {
            Node<T> data = list.GetHead();
            list.RemoveFirst();
            return data.data;
        }

        public T peek()
        {
            return list.GetHead().data;
        }
    }
}
