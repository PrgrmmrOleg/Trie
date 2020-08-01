using System;
using System.IO;
using NUnit.Framework;

namespace PrefixTree.Tests
{
    public class TreeTests
    {
        [SetUp]
        public void SetCurrentDirectory()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
        }

        [Test]
        public void FindWord()
        {
            string text;

            using (StreamReader sr = new StreamReader(@"../../../TestFiles/Test1/TestFile.txt"))
            {
                text = sr.ReadToEnd();
            }
            string[] words = text.Split(new char[] { ' ' });


            Tree tree = new Tree(words);


            Random random = new Random();
            int index = random.Next(0, words.Length - 1);

            bool wordFound = tree.Contain(words[index]);

            Assert.That(wordFound);
        }

        [Test]
        public void AddWords()
        {
            Tree tree = new Tree();

            string text;

            using (StreamReader sr = new StreamReader(@"../../../TestFiles/Test1/TestFile.txt"))
            {
                text = sr.ReadToEnd();
            }
            string[] words = text.Split(new char[] { ' ' });

            foreach (var word in words)
            {
                tree.Add(word);
            }

            Random random = new Random();
            int index = random.Next(0, words.Length - 1);

            bool wordFound = tree.Contain(words[index]);

            Assert.That(wordFound);
        }

        [Test]
        public void AddList()
        {
            Tree tree = new Tree();

            string text;

            using (StreamReader sr = new StreamReader(@"../../../TestFiles/Test1/TestFile.txt"))
            {
                text = sr.ReadToEnd();
            }
            string[] words = text.Split(new char[] { ' ' });

            tree.AddList(words);

            Random random = new Random();
            int index = random.Next(0, words.Length - 1);

            bool wordFound = tree.Contain(words[index]);

            Assert.That(wordFound);
        }
    }
}
