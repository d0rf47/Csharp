using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DList dList = new DList();

            for(int i = 0; i < 10; i++)
            {
                dList.PushBack(i);
            }
            dList.InsertAfter(dList.GetNodeByValue(2), 99);
            dList.RemoveNodeByValue(99);
            Node temp = dList.GetHead();
            while(temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
            

        }
    }
}
