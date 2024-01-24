namespace ZeroToHero.Interfaces.PracticeWithTests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    /*
  Problem:
  Implement the ICsvReader<T> interface to be able to read files and return a list of objects of type T.

  Example:
  var csvReader = new CsvReader<Student>();
  var students = csvReader.ReadCsv(filePath).ToList();  // List of Student objects
*/
    public interface ICsvReader<T>
    {
        IEnumerable<T> ReadCsv(string filePath);
    }

    public class CsvReader<T> : ICsvReader<T>
    {
        // TODO: Implement CSV reading logic for a given type
        public IEnumerable<T> ReadCsv(string filePath)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class CsvReaderExerciseTests
    {
        [Test]
        public void CsvReader_ReadCsv_Tests()
        {
            var csvReader = new CsvReader<Student>();

            // Create a sample CSV file for testing
            string filePath = "students.csv";
            File.WriteAllText(filePath, "John,Doe,25\nJane,Smith,22");

            // Test CSV reading
            var students = csvReader.ReadCsv(filePath).ToList();
            Assert.That(students, Has.Count.EqualTo(2));
            Assert.That(students[0].FirstName, Is.EqualTo("John"));
            Assert.That(students[0].LastName, Is.EqualTo("Doe"));
            Assert.That(students[0].Age, Is.EqualTo(25));

            // Clean up: Delete the test file
            File.Delete(filePath);
        }

        // Example class for CSV data
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }

}
