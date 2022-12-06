namespace Advent05
{
    public static class Program
    {
        private static void Main()
        {
            string[] data = File.ReadAllLines("data.txt");

            FileParser parser = new(data);

            Ship ship = parser.LoadShip();

            List<Step> steps = parser.GetSteps();

            Crane crane = new(ship, steps);

            crane.ProcessSteps();

            Console.WriteLine($"Part 1: {crane.GetPart1Result()}");
        }
    }
}