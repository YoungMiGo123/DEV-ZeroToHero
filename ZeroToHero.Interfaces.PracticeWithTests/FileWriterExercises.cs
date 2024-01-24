namespace ZeroToHero.Interfaces.PracticeWithTests
{
    // FileExercise.cs
    using NUnit.Framework;
    using System.IO;
    /* 
   Problem: Implement the IFileWrite - WriteToFile method to write the contents of a string to a file.
   */
    public interface IFileWriter
    {
        void WriteToFile(string filePath, string content);
    }

    public class FileWriter : IFileWriter
    {
        public void WriteToFile(string filePath, string content)
        {
            // TODO: Implement file writing logic here
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class FileWriterExerciseTests
    {
        [Test]
        public void FileWriter_WriteToFile_Tests()
        {
            var fileWriter = new FileWriter();

            // Create a sample text file for testing
            string filePath = "testfile.txt";

            // Test file writing
            fileWriter.WriteToFile(filePath, "Hello, World!");
            Assert.That(File.ReadAllText(filePath), Is.EqualTo("Hello, World!"));

            // Clean up: Delete the test file
            File.Delete(filePath);
        }
    }

}
