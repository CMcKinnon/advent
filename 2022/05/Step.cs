namespace Day05
{
    public class Step
    {
        public int QtyToMove { get; set; }

        public int FromStack { get; set; }

        public int ToStack { get; set; }

        public override string ToString() => $"move {QtyToMove} from {FromStack} to {ToStack}";
    }
}