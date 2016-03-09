using System;
using System.Linq;

namespace Storm
{
    public sealed class Command
    {
        public string Name { get; set; }
        public string[] Args { get; set; }

        public static Command ParseCommand(string input)
        {
            string[] spaces = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (string.Join("", spaces) == input)
            {
                return new Command(input);
            }
            return null;
        }

        public Command(string name, string[] args = null)
        {
            Name = name;
            Args = args;
        }
    }
}
