using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
           SLL newList= new SLL();
            newList.Add(3);
            newList.Add(15);
            newList.Add(12);
            newList.Add(56);
            newList.Add(4032);
            newList.Add(2);
            newList.Display();
            newList.Remove();
            newList.Remove();
            newList.Display();
        }
    }
}
