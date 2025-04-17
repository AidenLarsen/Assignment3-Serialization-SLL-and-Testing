using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Node<User>
    {
        public User Data { get; set; }
        public Node<User> Next { get; set; }

        public Node(User data)
        {
            this.Data = data;
        }
    }
}
