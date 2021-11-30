using System;

namespace DoublyLinkedList
{
    class DList<T>
    {
        Node<T> head;


        public void PushFront(T data)
        {
            //create new node
            Node<T> newNode = new Node<T>(data);
            //set next to head of list
            newNode.next = head;
            newNode.prev = null; //redundant??
            //if head exists set prev as new node
            // current head is now second node
            if(this.head != null)
                this.head.prev = newNode;
            //set new node to head
            this.head = newNode;
        }

        public void PushBack(T data)
        {
            Node<T> newNode = new Node<T>(data);
            
            if(this.head == null)
            {
                newNode.prev = null;
                this.head = newNode;
                return;
            }
            //get last node
            Node<T> tail = this.GetTail();
            //point last node to new node
            tail.next = newNode;
            //point new node back to last node
            newNode.prev = tail;            
        }

        Node<T> GetTail()
        {
            Node<T> current = this.head;
            while(current.next != null)
                current = current.next;
            
            return current;
        }

        public void InsertAfter(Node<T> node, T data )
        {
            
            if(node == null)
                throw new ArgumentNullException("node param must not be null!");
            //create the new node
            Node<T> newNode = new Node<T>(data);
            //point new node to node's  next
            newNode.next = node.next;
            //set nodes next to new node
            node.next = newNode;
            //point new prev to node
            newNode.prev = node;      
            if(newNode.next != null)      
                newNode.next.prev = newNode;                            
        }

        public Node<T> GetHead()
        {
            if(this.head == null)
                throw new NullReferenceException("This List is currently Empty!");
            return this.head;
        }

        public Node<T> GetNodeByValue(T val)
        {
            Node<T> current = this.head;
            while(current != null)
            {
                if(current.data.Equals(val))
                    return current;
                current = current.next;
            }
            return null;
        }

        public void RemoveNodeByValue(T val)
        {
            if(head == null)
                throw new NullReferenceException("Current list is empty!");
            Node<T> current = head;
            while(current != null)
            {
                if(current.data.Equals(val))
                {
                    current.next.prev = current.prev;
                    current.prev.next = current.next;
                    return;
                }
                current = current.next;
            }
        }


    }
}
