namespace ZeroToHero.Collections.Console
{
    using System;
    using System.Collections.Generic;

    public class HashSetExamples
    {
        public static void EasyExample()
        {
            HashSet<int> uniqueNumbers = [1, 2, 3, 4, 5, 5, 4, 3, 2, 1];

            Console.WriteLine("Easy HashSet Example:");
            foreach (var number in uniqueNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static void MediumExample()
        {
            // Medium example for HashSet: Tracking unique emails in a mailing list
            Console.WriteLine("Medium HashSet Example:");
            HashSet<string> emailList =
            [
                "user@example.com",
                "admin@example.com",
                "user@example.com", // Duplicate email
            ];

            Console.WriteLine("Unique Emails in Mailing List:");
            foreach (var email in emailList)
            {
                Console.WriteLine(email);
            }
        }

        public static void ComplexExample()
        {
            // Real-world example: Social media friends' interests
            Console.WriteLine("Complex HashSet Example:");
            HashSet<string> myInterests = ["Programming", "Travel", "Photography"];
            HashSet<string> friend1Interests = ["Travel", "Reading", "Cooking"];
            HashSet<string> friend2Interests = ["Programming", "Photography", "Fitness"];

            // Union of interests
            HashSet<string> combinedInterests = new HashSet<string>(myInterests);
            combinedInterests.Union(friend1Interests);
            combinedInterests.Union(friend2Interests);

            Console.WriteLine("Combined Interests with Friends:");
            foreach (var interest in combinedInterests)
            {
                Console.WriteLine(interest);
            }
        }

        public static void BuildExamples()
        {
            EasyExample();
            MediumExample();
            ComplexExample();
        }
    }
}
