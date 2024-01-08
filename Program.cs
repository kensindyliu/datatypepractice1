
using System.Reflection.Emit;

namespace secondApp;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter interest rate level (high, medium, low):");
        string interestRateLevel = Console.ReadLine().ToLower();
        if (interestRateLevel != "high" && interestRateLevel != "medium" && interestRateLevel != "low")
        {
            Console.WriteLine($"You entered an invalid level: {interestRateLevel}");
            return;
        }

        Console.WriteLine("Enter growth level (high, medium, low):");
        string growthLevel = Console.ReadLine().ToLower();
        if (growthLevel != "high" && growthLevel != "medium" && growthLevel != "low")
        {
            Console.WriteLine($"You entered an invalid level: {interestRateLevel}");
            return;
        }

        Console.WriteLine("Enter the most recent dividend(0-100):");
        int dividend = Convert.ToInt32(Console.ReadLine());

        if(dividend < 0 || dividend > 100)
        {
            Console.WriteLine("dividend amount muse between 0 and 100!");
            return;
        }
        Console.WriteLine("Enter the number of shares:");
        int shares = Convert.ToInt32(Console.ReadLine());
        if (shares < 0)
        {
            Console.WriteLine("shares amount muse be over 1!");
            return;
        }

        double marketValue = CalculateMarketValue(interestRateLevel, growthLevel, dividend, shares);
        Console.WriteLine($"Projected Market Value: {marketValue}");
        Console.ReadKey();
    }

    static double CalculateMarketValue(string interestRateLevel, string growthLevel, int dividend, int shares)
    {
        double interestRates = 0.2;
        switch (interestRateLevel){
            case "high":
                interestRates = 0.2;
                break;
            case "medium":
                interestRates = 0.1;
                break;
            case "low":
                interestRates = 0.08;
                break;
        }

        double growthRates = 0.075;
        switch (growthLevel)
        {
            case "high":
                growthRates = 0.075;
                break;
            case "medium":
                growthRates = 0.05;
                break;
            case "low":
                growthRates = 0.025;
                break;
        }

        double R = interestRates;
        double G = growthRates;

        double P = dividend / (R - G);
        return P * shares;

    }
}




