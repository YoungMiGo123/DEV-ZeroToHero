using ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.After;
using ZeroToHero.BestPractices.Console.SOLID.DependecyInjection.Before;
using ZeroToHero.BestPractices.Console.SOLID.InterfaceSegregation.After;
using ZeroToHero.BestPractices.Console.SOLID.InterfaceSegregation.Before;
using ZeroToHero.BestPractices.Console.SOLID.LiskovSubstitution.After;
using ZeroToHero.BestPractices.Console.SOLID.LiskovSubstitution.Before;
using ZeroToHero.BestPractices.Console.SOLID.OpenClosed.After;
using ZeroToHero.BestPractices.Console.SOLID.OpenClosed.Before;
using ZeroToHero.BestPractices.Console.SOLID.SingleResponsibility.After;
using ZeroToHero.BestPractices.Console.SOLID.SingleResponsibility.Before;

namespace ZeroToHero.BestPractices.Console.SOLID
{
    public class SolidDriver
    {
        public static void Build()
        {
            BuildSingleResponsibility();
            BuildOpenClosed();
            BuildInterfaceSegregation();
            BuildLiskovSubstitution();
            BuildDependencyInversion();
        }
        private static void BuildSingleResponsibility()
        {
            SingleResponsibilityVolationExample.Build();
            SingleResponsibilityApplicationExample.Build();
        }
        private static void BuildOpenClosed()
        {
            OpenClosedViolationExample.Build();
            OpenClosedApplicationExample.Build();
        }   
        private static void BuildInterfaceSegregation()
        {
            InterfaceSegregationViolationExample.Build();
            InterfaceSegregationApplicationExample.Build();
        }
        private static void BuildLiskovSubstitution()
        {
            LiskovSubstitutionViolationExample.Build();
            LiskovSubstitutionApplicationExample.Build();
        }


        private static void BuildDependencyInversion()
        {
            DependencyInversionViolationExample.Build();
            DependencyInversionApplicationExample.Build();
        }
    }
}
