using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.BestPractices.Console.KISS.After;
using ZeroToHero.BestPractices.Console.KISS.Before;

namespace ZeroToHero.BestPractices.Console.KISS
{
    public class KissDriver
    {
        public static void Build()
        {
            ViolatingKiss.Build();
            ApplyingKiss.Build();
        }
    }
}
