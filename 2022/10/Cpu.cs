namespace Day10
{
    public class Cpu
    {
        private readonly List<Instruction> instructions;

        private int x = 1;

        private int cycle = 1;

        private readonly List<CpuState> cpuStates = new();

        public Cpu(List<Instruction> instructions) => this.instructions = instructions;

        public void RunProgram()
        {
            foreach (Instruction instruction in instructions)
            {
                for (int i = 0; i < instruction.Cycles; i++)
                {
                    cpuStates.Add(new CpuState(cycle, x));
                    cycle++;
                }
                if (instruction.OpCode == OpCode.AddX)
                {
                    x += instruction.Operand;
                }
            }
        }

        public void DisplayPart1()
        {
            int cycle = 20;
            int sum = 0;
            while (cycle <= 220)
            {
                int signal = cpuStates[cycle - 1].Signal;
                sum += signal;
                cycle += 40;
            }

            Console.WriteLine($"Part 1: {sum}");
        }

        public void DisplayPart2()
        {
            Console.WriteLine($"{Environment.NewLine}Part 2:{Environment.NewLine}");

            foreach (CpuState cpuState in cpuStates)
            {
                int col = cpuState.Col - 1;
                int sprite = cpuState.SpritePos;

                if (sprite - 1 == col || sprite == col || sprite + 1 == col)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }

                if (col == 39)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}