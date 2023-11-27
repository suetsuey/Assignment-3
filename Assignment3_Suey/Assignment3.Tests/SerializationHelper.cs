using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users to JSON and stores in a file
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName">File name to store the serialized data</param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<User> userList = new List<User>();

            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            string json = JsonSerializer.Serialize(userList);
            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Deserializes (decodes) users from a JSON file
        /// </summary>
        /// <param name="fileName">File name containing the serialized data</param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            string json = File.ReadAllText(fileName);
            List<User> userList = JsonSerializer.Deserialize<List<User>>(json);

            ILinkedListADT linkedList = new SinglyLinkedList();

            foreach (User user in userList)
            {
                linkedList.AddLast(user);
            }

            return linkedList;
        }
    }
}
