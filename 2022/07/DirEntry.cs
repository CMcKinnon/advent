namespace Advent07
{
    public class DirEntry
    {
        public DirEntryType DirEntryType { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public List<DirEntry> Children { get; set; } = new List<DirEntry>();

        public DirEntry? Parent { get; set; }

        public DirEntry(DirEntryType type, string name, long size, DirEntry? parent = null)
        {
            DirEntryType = type;
            Name = name;
            Size = size;
            Parent = parent;
        }

        public void Display()
        {
            Display(0);
        }

        private void Display(int level)
        {
            string attrs = DirEntryType == DirEntryType.Directory
                ? $"(dir, size={Size})"
                : $"(file, size={Size})";

            Console.WriteLine("-".PadLeft(2 * level) + $" {Name} {attrs}");
            foreach (DirEntry child in Children)
            {
                child.Display(level + 1);
            }
        }

        public void ShowPart1Answer()
        {
            List<DirEntry> matches = new();
            FindSizeAtMost(this, 100000, matches);

            Console.WriteLine($"Part 1: {matches.Sum(d => d.Size)}");
        }

        private void FindSizeAtMost(DirEntry dir, int atMost, List<DirEntry> matches)
        {
            if (dir.Size <= atMost)
            {
                matches.Add(dir);
            }
            foreach (DirEntry child in dir.Children)
            {
                if (child.DirEntryType == DirEntryType.Directory)
                {
                    FindSizeAtMost(child, atMost, matches);
                }
            }
        }

        public void ShowPart2Answer()
        {
            long totalSize = Size;
            long unused = 70000000 - totalSize;
            const long targetUnused = 30000000L;
            long diff = targetUnused - unused;

            List<DirEntry> matches = new();
            FindSizeAtLeast(this, diff, matches);

            DirEntry smallest = matches.OrderBy(d => d.Size).First();
            Console.WriteLine($"Part 2: {smallest.Size}");
        }

        private void FindSizeAtLeast(DirEntry dir, long atLeast, List<DirEntry> matches)
        {
            if (dir.Size >= atLeast)
            {
                matches.Add(dir);
            }
            foreach (DirEntry child in dir.Children)
            {
                if (child.DirEntryType == DirEntryType.Directory)
                {
                    FindSizeAtLeast(child, atLeast, matches);
                }
            }
        }
    }
}