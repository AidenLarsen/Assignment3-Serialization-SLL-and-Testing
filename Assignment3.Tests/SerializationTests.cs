using System.Collections.Generic;
using Assignment3;
using NUnit.Framework;

namespace Assignment3.Tests
{
    public class SerializationTests

    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.json";

        [SetUp]
        public void Setup()
        {
            this.users = new LinkedList();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }


        [TearDown]
        public void TearDown()
        {
            this.users?.Clear();
            users = null;
        }

        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.That(File.Exists(testFileName), Is.True);
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.That(users.Count(), Is.EqualTo(deserializedUsers.Count()));

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.That(actual.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.Name, Is.EqualTo(expected.Name));
                Assert.That(actual.Email, Is.EqualTo(expected.Email));
                Assert.That(actual.Password, Is.EqualTo(expected.Password));
            }
        }

        [Test]
        public void ListIsEmpty()
        {
            users.Clear();
            Assert.That(users.IsEmpty(), Is.True);
        }

        [Test]
        public void Prepend()
        {
            var userToPrepend = users.GetValue(3);
            users.AddFirst(userToPrepend);

            var firstUser = users.GetValue(0);
            Assert.That(firstUser.Id, Is.EqualTo(userToPrepend.Id));
        }

        [Test]
        public void Appended()
        {
            var userToAppend = users.GetValue(0);
            users.AddLast(userToAppend);

            var lastUser = users.GetValue(users.Count() - 1);
            Assert.That(lastUser.Id, Is.EqualTo(userToAppend.Id));
        }

        [Test]
        public void InsertAtIndex()
        {
            var userToInsert = users.GetValue(1);
            users.Add(userToInsert, 2);

            var insertedUser = users.GetValue(2);
            Assert.That(insertedUser.Id, Is.EqualTo(userToInsert.Id));
        }

        [Test]
        public void ReplaceAtIndex()
        {
            var replacementUser = users.GetValue(2);
            users.Replace(replacementUser, 1);

            var replacedUser = users.GetValue(1);
            Assert.That(replacedUser.Id, Is.EqualTo(replacementUser.Id));
        }

        [Test]
        public void DeleteFromBeginning()
        {
            users.RemoveFirst();

            var firstUser = users.GetValue(0);
            Assert.That(firstUser.Id, Is.EqualTo(2));
        }

        [Test]
        public void DeleteFromEnd()
        {
            users.RemoveLast();

            var lastUser = users.GetValue(users.Count() - 1);
            Assert.That(lastUser.Id, Is.EqualTo(3));
        }

        [Test]
        public void DeleteFromMiddle()
        {
            users.Remove(1);

            var userAtIndex = users.GetValue(1);
            Assert.That(userAtIndex.Id, Is.EqualTo(3));
        }

        [Test]
        public void FindAndRetrieveExistingItem()
        {
            var targetUser = users.GetValue(2);
            var index = users.IndexOf(targetUser);

            Assert.That(index, Is.EqualTo(2));
            Assert.That(users.GetValue(index).Id, Is.EqualTo(targetUser.Id));
        }
    }
}
