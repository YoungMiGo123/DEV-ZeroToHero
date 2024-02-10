using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.BestPractices.Console.CleanCoding.After;
using ZeroToHero.BestPractices.Console.CleanCoding.Before;

namespace ZeroToHero.BestPractices.Console.CleanCoding
{
    public class CleanCodeDriver
    {
        public static void Build()
        {
            ApplyingCleanCode.Build();
            ViolatingCleanCode.Build();
        }
    }
}
