namespace Day10
{
    public class CpuState
    {
        private readonly int cycle;

        private readonly int x;

        public int Signal => cycle * x;

        public CpuState(int cycle, int x)
        {
            this.cycle = cycle;
            this.x = x;
        }
    }
}