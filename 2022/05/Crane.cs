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

        public void ProcessStepsPart1()
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

        public void ProcessStepsPart2()
        {
            foreach (Step step in steps)
            {
                Stack<string> fromStack = ship.Stacks[step.FromStack - 1];
                Stack<string> toStack = ship.Stacks[step.ToStack - 1];

                Stack<string> tempStack = new();

                for (int i = 0; i < step.QtyToMove; i++)
                {
                    tempStack.Push(fromStack.Pop());
                }

                for (int i = 0; i < step.QtyToMove; i++)
                {
                    toStack.Push(tempStack.Pop());
                }
            }
        }

        public string GetResult()
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