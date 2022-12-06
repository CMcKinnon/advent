namespace Advent05
{
    public class Crane
    {
        private readonly Ship ship;
        private readonly List<Step> steps;

        public Crane(Ship ship, List<Step> steps)
        {
            this.ship = ship;
            this.steps = steps;
        }

        public void ProcessSteps()
        {
            foreach (Step step in steps)
            {
                Stack<string> fromStack = ship.Stacks[step.FromStack - 1];
                Stack<string> toStack = ship.Stacks[step.ToStack - 1];

                for (int i = 0; i < step.QtyToMove; i++)
                {
                    toStack.Push(fromStack.Pop());
                }
            }
        }

        public string GetPart1Result()
        {
            string result = "";

            foreach (Stack<string> stack in ship.Stacks)
            {
                if (stack.Count > 0)
                {
                    result += stack.Peek();
                }
            }

            return result;
        }
    }
}