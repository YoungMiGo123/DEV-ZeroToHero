namespace ZeroToHero.Interfaces.PracticeWithTests
{
    using NUnit.Framework;
    using System.IO;


    /* 
    Problem: Implement the IFileReader - ReadFile method to read the contents of a file and return it as a string.
    
    */
    public interface IFileReader
    {
        string ReadFile(string filePath);
    }

    public class FileReader : IFileReader
    {
        public string ReadFile(string filePath)
        {
            // TODO: Implement file reading logic here
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class FileReaderExerciseTests
    {
        [Test]
        public void FileReader_ReadFile_Tests()
        {
            var fileReader = new FileReader();

            // Create a sample text file for testing
            string filePath = "testfile.txt";
            File.WriteAllText(filePath, "Hello, World!");

            Assert.That(fileReader.ReadFile(filePath), Is.EqualTo("Hello, World!"));

            // Clean up: Delete the test file
            File.Delete(filePath);
        }
    }

}
