using ZeroToHero.BestPractices.Console.YAGNI.After;
using ZeroToHero.BestPractices.Console.YAGNI.Before;

namespace ZeroToHero.BestPractices.Console.YAGNI
{
    public class YagniDriver
    {
        public static void Build()
        {
            ViolatingYagni.Build();
            ApplyingYagni.Build();
        }
    }
}
