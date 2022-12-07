using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Regex days = new(@"Day\d\d\.Runner");
            Assembly asm = Assembly.GetExecutingAssembly();
            IEnumerable<Type> entries = asm.ExportedTypes.Where(d => days.IsMatch(d.FullName!));

            if (args.Length > 0)
            {
                if (args[0] == "-a")
                {
                    foreach (Type t in entries.OrderBy(d => d.FullName))
                    {
                        RunDay(t);
                    }
                }
                else
                {
                    foreach (string arg in args)
                    {
                        if (int.TryParse(arg, out int dayNum))
                        {
                            string dayStr = dayNum.ToString("00");
                            Type? t = entries.FirstOrDefault(d => d.FullName == $"Day{dayStr}.Runner");
                            if (t != null)
                            {
                                RunDay(t);
                            }
                        }
                    }
                }
            }
            else
            {
                Type? t = entries.OrderByDescending(d => d.FullName).FirstOrDefault();
                if (t != null)
                {
                    RunDay(t);
                }
            }
        }

        private static void RunDay(Type t)
        {
            Console.WriteLine("===========================");
            Console.WriteLine($"Executing day {t.FullName?.GetDayNum()}");
            IDay? day = (IDay?)Activator.CreateInstance(t);
            Stopwatch sw = Stopwatch.StartNew();
            day?.Run();
            sw.Stop();
            Console.WriteLine($"{Environment.NewLine}Elapsed: {sw.Elapsed}{Environment.NewLine}");
        }

        private static string? GetDayNum(this string name) => name?.Replace("Day", "")?.Replace(".Runner", "");
    }
}