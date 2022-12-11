namespace Day11
{
    public class Operation
    {
        public OperationType Type { get; set; }

        public bool IsOldNumber { get; set; }

        public int Value { get; set; }

        public Operation(OperationType ot, bool isOldNumber, int value)
        {
            Type = ot;
            IsOldNumber = isOldNumber;
            Value = value;
        }
    }
}