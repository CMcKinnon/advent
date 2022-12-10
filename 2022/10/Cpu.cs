namespace Day10
{
    public class Cpu
    {
        private readonly List<Instruction> instructions;

        private int x = 1;

        private int cycle = 1;

        private readonly List<CpuState> cpuState = new();

        public Cpu(List<Instruction> instructions) => this.instructions = instructions;

        public void RunProgram()
        {
            foreach (Instruction instruction in instructions)
            {
                for (int i = 0; i < instruction.Cycles; i++)
                {
                    cpuState.Add(new CpuState(cycle, x));
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
                int signal = cpuState[cycle - 1].Signal;
                sum += signal;
                cycle += 40;
            }

            Console.WriteLine($"Part 1: {sum}");
        }
    }
}