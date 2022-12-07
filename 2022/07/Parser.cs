namespace Day07
{
    public class Parser
    {
        private readonly string[] data;

        public Parser(string[] data) => this.data = data;

        private readonly DirEntry root = new(DirEntryType.Directory, "/", 0L);

        public DirEntry Parse()
        {
            DirEntry cwd = root;

            foreach (string line in data)
            {
                DataLine dataLine = GetDataLine(line);
                cwd = ProcessLine(cwd, dataLine);
            }

            UpdateDirectorySizes(root);

            return root;
        }

        private static DataLine GetDataLine(string line)
        {
            if (line.StartsWith("$"))
            {
                return new DataLine(DataLineType.Command, line[2..], 0L);
            }
            else
            {
                string[] parts = line.Split(' ');
                if (long.TryParse(parts[0], out long size))
                {
                    return new DataLine(DataLineType.File, parts[1], size);
                }
                else if (parts[0] == "dir")
                {
                    return new DataLine(DataLineType.Directory, parts[1], 0L);
                }
                else
                {
                    throw new InvalidDataException($"Invalid line type: {line}");
                }
            }
        }

        private DirEntry ProcessLine(DirEntry cwd, DataLine line)
        {
            if (line.Type == DataLineType.Command)
            {
                return ProcessCommand(cwd, line);
            }
            else if (line.Type == DataLineType.Directory)
            {
                cwd.Children.Add(new DirEntry(DirEntryType.Directory, line.Name, 0L, cwd));
            }
            else if (line.Type == DataLineType.File)
            {
                cwd.Children.Add(new DirEntry(DirEntryType.File, line.Name, line.Size));
            }

            return cwd;
        }

        private DirEntry ProcessCommand(DirEntry cwd, DataLine line)
        {
            string cmd = line.Name;
            if (cmd.StartsWith("cd"))
            {
                string dir = cmd[3..];
                if (dir == "/")
                {
                    return root;
                }
                else if (dir == "..")
                {
                    if (cwd.Parent != null)
                    {
                        return cwd.Parent;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Tried to cd up a level, but parent was null. CWd = {cwd.Name}");
                    }
                }
                else
                {
                    DirEntry? subDir = cwd.Children.Find(c => c.Name == dir);
                    if (subDir != null)
                    {
                        return subDir;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Tried to cd to {subDir} but not found in children of {cwd.Name}");
                    }
                }
            }
            else if (cmd == "ls")
            {
                return cwd;
            }
            else
            {
                throw new InvalidOperationException($"Unknown command {cmd}");
            }
        }

        private void UpdateDirectorySizes(DirEntry cwd)
        {
            foreach (DirEntry child in cwd.Children)
            {
                if (child.DirEntryType == DirEntryType.Directory)
                {
                    UpdateDirectorySizes(child);
                }
                cwd.Size += child.Size;
            }
        }
    }
}