namespace Day05
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] data = File.ReadAllLines("datafiles/05.txt");

            FileParser parser = new(data);

            Ship ship = parser.LoadShip();

            List<Step> steps = parser.GetSteps();

            Crane crane = new(ship, steps);

            crane.ProcessStepsPart1();

            Console.WriteLine($"Part 1: {crane.GetResult()}");

            ship = parser.LoadShip();

            crane = new(ship, steps);

            crane.ProcessStepsPart2();

            Console.WriteLine($"Part 2: {crane.GetResult()}");
        }
    }
}
