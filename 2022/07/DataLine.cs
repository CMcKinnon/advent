namespace Advent07
{
    public class DataLine
    {
        public DataLineType Type { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public DataLine(DataLineType type, string name, long size)
        {
            Type = type;
            Name = name;
            Size = size;
        }
    }
}