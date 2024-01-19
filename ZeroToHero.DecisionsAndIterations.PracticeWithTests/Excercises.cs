namespace ZeroToHero.DecisionsAndIterations.PracticeWithTests
{
    public class Excercises
    {
        /*
         ConvertHoursIntoSeconds(2) ➞ 7200
         ConvertHoursIntoSeconds(10) ➞ 36000
         ConvertHoursIntoSeconds(24) ➞ 86400
         Notes
         60 seconds in a minute, 60 minutes in an hour.
         Don't forget to return your answer.
        */
        public static int ConvertHoursIntoSeconds(int hours)
        {
            //Write a function that converts hours into seconds.
            var seconds = hours * 60 * 60;
            return seconds;
        }

        /*
         CircuitPower(230, 10) ➞ 2300
         CircuitPower(110, 3) ➞ 330
         CircuitPower(480, 20) ➞ 9600
      
         Notes: power is voltage multiplied by current
        */
        public static int CircuitPower(int voltage, int current)
        {
            //Create a function that takes voltage and current and returns the calculated power.
            return 0;
        }

        /*
            CalculateCompoundInterest(1000, 5, 0.05, 3) ➞ 157.63
            CalculateCompoundInterest(500, 10, 0.1, 2) ➞ 105.0
            CalculateCompoundInterest(2000, 8, 0.08, 5) ➞ 734.02

            Notes:
            - The formula for compound interest is: A = P(1 + r/n)^(nt) - P, where:
              - A is the amount after t years.
              - P is the principal amount (initial investment).
              - r is the annual interest rate (as a decimal).
              - n is the number of times that interest is compounded per year.
              - t is the time the money is invested or borrowed for in years.
        */
        public static double CalculateCompoundInterest(double principal, int years, double rate, int compoundsPerYear)
        {
            // Implement a function that calculates and returns the compound interest.
            return 0.0;
        }

        /*
             ValidatePassword("Abcd@123") ➞ true
             ValidatePassword("Passw0rd") ➞ false
             ValidatePassword("StrongPwd!22") ➞ true

             Notes:
             - The password must be at least 8 characters long.
             - It must contain at least one uppercase letter, one lowercase letter, and one digit.
             - It may also contain special characters such as !, @, #, $, etc.
        */
        public static bool ValidatePassword(string password)
        {
            // Implement a function that validates if a password meets the specified criteria.
            return false;
        }

        /*
          ReverseString("hello") ➞ "olleh"
          ReverseString("world") ➞ "dlrow"
          ReverseString("C# is fun") ➞ "nuf si #C"
          
          Notes:
          - Create a function that takes a string as input and returns the reversed string.
        */
        public static string ReverseString(string input)
        {
            // Implement a function that reverses the characters in the given string. Do not use linq
            return null;
        }

        /*
         FindLargest(new int[][] { new int[] { 4, 2, 7, 1 }, new int[] { 20, 70, 40, 90 }, new int[] { 1, 2, 0 } })
         ➞ new int[] { 7, 90, 2 }

         FindLargest(new int[][] { new int[] { -34, -54, -74 }, new int[] { -32, -2, -65 }, new int[] { -54, 7, -43 } })
         ➞ new int[] { -34, -2, 7 }

         FindLargest(new int[][] { new int[] { 5, 8, 2, 15 }, new int[] { 12, 3, 9, 1 }, new int[] { 11, 7, 14 } })
         ➞ new int[] { 15, 12, 14 }

         Notes:
         - Watch out for negative numbers.
         - Create a function that takes a 2D array of integers and returns an array containing the largest integer in each subarray.
        */
        public static int[] FindLargest(int[][] input)
        {
            // Implement a function that finds and returns the largest integer in each subarray.
            return null;
        }
    }
}
