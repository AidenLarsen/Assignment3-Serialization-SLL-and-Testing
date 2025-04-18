using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class LinkedList : ILinkedListADT
    {
        public Node<User> Head { get; set; }
        public int Amount;

        public LinkedList()
        {
            Head = null;
            Amount = 0;
        }

        public bool IsEmpty()
        {
            return Head == null && Amount == 0;
        }

        public void Clear()
        {
            Head = null;
            Amount = 0;
        }

        public void AddLast(User data)
        {
            Node<User> node = new Node<User>(data);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
            Amount++;
        }

        public void AddFirst(User data)
        {
            Node<User> node = new Node<User>(data);
            node.Next = Head;
            Head = node;
            Amount++;
        }

        public void Add(User data, int index)
        {
            try
            {
                if (index > Amount || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<User> node = new Node<User>(data);

                if (index == 0)
                {
                    AddFirst(data);
                }
                else
                {
                    Node<User> current = Head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    node.Next = current.Next;
                    current.Next = node;
                    Amount++;
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
                if (index >= Amount || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<User> current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = data;
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
                return;
            }

            Head = Head.Next;
            Amount--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                Console.WriteLine("List is already empty");
                return;
            }

            if (Amount == 1)
            {
                Head = null;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next.Next != null)
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
                if (index >= Amount || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    Node<User> current = Head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    current.Next = current.Next.Next;
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

        public User GetValue(int index)
        {
            if (index < 0 || index >= Amount)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int IndexOf(User data)
        {
            Node<User> current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User data)
        {
            return IndexOf(data) != -1;
        }
    }
}
