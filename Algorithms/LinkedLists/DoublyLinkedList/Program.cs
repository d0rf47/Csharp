using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DList<string> dList = new DList<string>();

            for(int i = 0; i < 10; i++)
            {
                dList.PushBack(i.ToString());
            }
            dList.InsertAfter(dList.GetNodeByValue("2"), "99");            
            Node<string> temp = dList.GetHead();
            while(temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }

            Console.WriteLine(dList.Contains("99"));
            dList.RemoveNodeByValue("99");
            Console.WriteLine(dList.Contains("99"));
            dList.RemoveFirst();
            Console.WriteLine(dList.Contains("0"));
            dList.RemoveLast();
            Console.WriteLine(dList.Contains("9"));
            dList.RemoveNodeAtPos(2);
            foreach(string i in dList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(dList.GetHead().data);
        }
    }
}
