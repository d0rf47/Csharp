using System;
using System.Collections;
namespace DoublyLinkedList
{
    /**
    * Custom Doubly Linked List Templated Class
    * With customer iterator implemented via IEnumerable
    */
    class DList<T> :IEnumerable
    {
        Node<T> head;
        Node<T> current;
        int size = 0;

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

            this.size++;
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
            
            this.size++;    
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

            this.size++;                       
        }

        public Node<T> GetHead()
        {
            if(this.IsEmpty())
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

        public void RemoveFirst()
        {
            if(this.IsEmpty())
                throw new NullReferenceException("This List is currently Empty!");
            this.head = this.head.next;
            this.size--;
        }

        public void RemoveLast()
        {
            if(this.IsEmpty())
                throw new NullReferenceException("This List is currently Empty!");
            Node<T> tail = this.GetTail();
            tail.prev.next = null;
            this.size--;
        }
        public void RemoveNodeByValue(T val)
        {
            if(this.IsEmpty())
                throw new NullReferenceException("Current list is empty!");
            Node<T> current = head;
            while(current != null)
            {
                if(current.data.Equals(val))
                {                    
                    current.next.prev = current.prev;
                    current.prev.next = current.next;
                    this.size--;
                    return;
                }
                current = current.next;
            }            
        }

        /**
        *   Uses sub 0 indexing
        *   removes node from nth Position in list
        */
        public void RemoveNodeAtPos(int position)
        {
            //check for pos > than list size
            if(position > this.size)
                throw new OutOfMemoryException("Position is greater than list size!");     
            //special case check to ensure integrity for iterator       
            if(position == 0)
            {
                head = head.next;
                this.size--;
                return;
            }
            Node<T> current = head;
            for(int i = 0; i <= position; i++)
            {
                if(i == position)
                {
                    // Console.WriteLine($"Removing {current.data}");
                    current.next.prev = current.prev;       
                    current.prev.next = current.next;     
                    this.size--;                                                        
                    return;
                }
                current = current.next;
            }
        }

        public bool Contains(T val)
        {
            if(this.head == null)
                return false;

            Node<T> current = head;
            while(current != null)
            {
                if(current.data.Equals(val))
                    return true;
                current = current.next;
            }
            return false;
        }

        internal bool IsEmpty()
        {
            return this.size == 0;
        }
        public int Count()
        {
            return this.size;
        }

        //Used to allow list to be
        // traversed like typical collections
        public IEnumerator GetEnumerator()
        {   
            current = head;
            
            while(current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
    
    }
}
