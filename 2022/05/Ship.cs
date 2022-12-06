namespace Advent05
{
    public class Ship
    {
        public Stack<string>[] Stacks { get; set; } = new Stack<string>[]
        {
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>(),
            new Stack<string>()
        };
    }
}