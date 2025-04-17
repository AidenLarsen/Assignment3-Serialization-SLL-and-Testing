using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class LinkedList<T> : ILinkedListADT
    {
        public Node<User> Head { get; set; }
        public Node<User> Tail { get; set; }
        public int Amount;

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Amount = 0;
        }

        public bool IsEmpty()
        {
            if(Head == null &&  Tail == null && Amount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Clear()
        {
            Head = Tail = null;
            Amount = 0;
        }

        public void AddLast(User data)
        {
            Node<User> node = new Node<User>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public void AddFirst(User data)
        {
            Node<User> node = new Node<User>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        public void Add(User data, int index)
        {
            try
            {
                if (index > Amount-1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Node<User> current = Head;
                    Node<User> node = new Node<User>(data);
                    if (Head == null)
                    {
                        Head = Tail = node;
                    }
                    else
                    {
                        while (index != Amount - 2)
                        {
                            current = current.Next;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index entered is either larger than or smaller than the number of linked lists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Replace(User data, int index)
        {
            try
            {
                if (index > Amount-1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Node<User> current = Head;
                    while (index != Amount-2)
                    {
                        current = current.Next;
                    }

                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index entered is either larger than or smaller than the number of linked lists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int Count()
        {
            return Amount;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                Console.WriteLine("List is already empty");
            }
            if (Amount == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head.Next = Head;
            }
            Amount--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                Console.WriteLine("List is already empty");
                return;
            }
            else if (Amount == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            Amount--;
        }

        public void Remove(int index)
        {
            try
            {
                if (index > Amount-1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Node<User> current = Head;
                    while (index != Amount - 2)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Amount--;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index entered is either larger than or smaller than the number of linked lists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public User Getdata(int index)
        {
            Node<User> current = Head;
            while ()
        }

        public int IndexOf(User data)
        {
            return 0;
        }

        public bool Contains(User data)
        {
            return false;
        }
    }
}
