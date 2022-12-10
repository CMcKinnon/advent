namespace Day10
{
    public class Runner : IDay
    {
        public void Run()
        {
            string[] lines = File.ReadAllLines("datafiles/10.txt");

            List<Instruction> instructions = Parse(lines);

            Cpu cpu = new(instructions);

            cpu.RunProgram();

            cpu.DisplayPart1();
        }

        private static List<Instruction> Parse(string[] lines)
        {
            return lines.Select(line =>
            {
                string[] parts = line.Split(' ');
                if (parts[0].Equals("addx", StringComparison.OrdinalIgnoreCase))
                {
                    return new Instruction
                    {
                        OpCode = OpCode.AddX,
                        Operand = int.Parse(parts[1]),
                        Cycles = 2
                    };
                }
                else if (parts[0].Equals("noop", StringComparison.OrdinalIgnoreCase))
                {
                    return new Instruction
                    {
                        OpCode = OpCode.Noop,
                        Cycles = 1
                    };
                }
                else
                {
                    throw new InvalidOperationException($"Invalid opcode {parts[0]}");
                }
            }).ToList();
        }
    }
}