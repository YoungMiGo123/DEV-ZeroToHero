using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroToHero.BestPractices.Console.DRY.After;
using ZeroToHero.BestPractices.Console.DRY.Before;

namespace ZeroToHero.BestPractices.Console.DRY
{
    public class DryDriver
    {
        public static void Build()
        {
            ViolatingDry.Build();
            ApplyingDry.Build();
        }
    }
}
