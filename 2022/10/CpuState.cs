using System.Threading.Tasks;
namespace Day10
{
    public class CpuState
    {
        public int Cycle { get; }

        private readonly int x;

        public int Signal => Cycle * x;

        public int Col => ((Cycle - 1) % 40) + 1;

#pragma warning disable RCS1085
        public int SpritePos => x;
#pragma warning restore RCS1085

        public CpuState(int cycle, int x)
        {
            Cycle = cycle;
            this.x = x;
        }
    }
}