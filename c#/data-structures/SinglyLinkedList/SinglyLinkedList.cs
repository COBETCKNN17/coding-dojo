using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
   public class SLL
    {
        public Node head;

        public SLL()
        {
            this.head = null;
        }

        public void Add(int value)
        {
            Node newNode = new Node(value);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node walker = this.head;
                while (walker.next != null)
                {
                    walker = walker.next;
                }
                walker.next = newNode;
            }
            Console.WriteLine("Adding a New Node: " + newNode.value);
        }

        public void Remove()
        {
            Node walker = this.head;
            while (walker.next.next != null)
            {
                walker = walker.next;
            }
            Console.WriteLine("Removing Node: " + walker.next.value);
            walker.next = null;
        }

        public void Display()
        {
            Node walker = this.head;
            Console.WriteLine("Printing all values in list:");
            while (walker != null)
            {
                Console.WriteLine(walker.value);
                walker = walker.next;
            }
        }

    }
}
