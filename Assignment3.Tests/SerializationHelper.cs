using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users 
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            var userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            string json = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Deserializes (decodes) users 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var userList = JsonSerializer.Deserialize<List<User>>(json);

            ILinkedListADT linkedList = new LinkedList();
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    linkedList.AddLast(user);
                }
            }

            return linkedList;
        }
    }
}
