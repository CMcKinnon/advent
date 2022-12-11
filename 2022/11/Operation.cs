namespace Day11
{
    public class Operation
    {
        public OperationType Type { get; set; }

        public bool IsOldNumber { get; set; }

        public ulong Value { get; set; }

        public Operation(OperationType ot, bool isOldNumber, ulong value)
        {
            Type = ot;
            IsOldNumber = isOldNumber;
            Value = value;
        }
    }
}