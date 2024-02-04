namespace ZeroToHero.DecisionsAndIterations.PracticeWithTests
{
    [TestFixture]
    public class ExcerciseTests
    {
        [Test]
        public void ConvertHoursIntoSeconds_Tests()
        {
            var inputs = new List<int> { 2, 10, 24 };
            var outputs = new List<int> { 7200, 36000, 86400 };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.ConvertHoursIntoSeconds(inputs[i]);
                Assert.That(outputs[i], Is.EqualTo(response));
            }
        }

        [Test]
        public void CircuitPower_Tests()
        {
            var inputs = new List<Tuple<int, int>> { Tuple.Create(230, 10), Tuple.Create(110, 3), Tuple.Create(480, 20) };
            var outputs = new List<int> { 2300, 330, 9600 };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.CircuitPower(inputs[i].Item1, inputs[i].Item2);
                Assert.That(outputs[i], Is.EqualTo(response));
            }
        }

        [Test]
        public void CalculateCompoundInterest_Tests()
        {
            var inputs = new List<Tuple<double, int, double, int>>
            {
                Tuple.Create(1000.0, 5, 0.05, 3),
                Tuple.Create(500.0, 10, 0.1, 2),
                Tuple.Create(2000.0, 8, 0.08, 5)
            };
            var outputs = new List<double> { 157.63, 105.0, 734.02 };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.CalculateCompoundInterest(inputs[i].Item1, inputs[i].Item2, inputs[i].Item3, inputs[i].Item4);
                Assert.That(outputs[i], Is.EqualTo(response).Within(0.01));
            }
        }

        [Test]
        public void ValidatePassword_Tests()
        {
            var inputs = new List<string> { "Abcd@123", "Passw0rd", "StrongPwd!22" };
            var outputs = new List<bool> { true, false, true };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.ValidatePassword(inputs[i]);
                Assert.That(outputs[i], Is.EqualTo(response));
            }
        }

        [Test]
        public void ReverseString_Tests()
        {
            var inputs = new List<string> { "hello", "world", "C# is fun" };
            var outputs = new List<string> { "olleh", "dlrow", "nuf si #C" };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.ReverseString(inputs[i]);
                Assert.That(outputs[i], Is.EqualTo(response));
            }
        }

        [Test]
        public void FindLargest_Tests()
        {
            var inputs = new List<int[][]>
            {
                new int[][] { [4, 2, 7, 1], [20, 70, 40, 90], [1, 2, 0] },
                new int[][] { [-34, -54, -74], [-32, -2, -65], [-54, 7, -43] },
                new int[][] { [5, 8, 2, 15], [12, 3, 9, 1], [11, 7, 14] }
            };
            var outputs = new List<int[]>
            {
                { [ 7,  90,  2]  },
                { [-34, -2, 7] },
                { [15, 12,  14]  }
            };

            for (int i = 0; i < inputs.Count; i++)
            {
                var response = Excercises.FindLargest(inputs[i]);
                Assert.That(outputs[i], Is.EqualTo(response));
            }
        }
    }
}