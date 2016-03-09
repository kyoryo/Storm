using System;

namespace Storm
{
    public sealed class Command
    {
        public string Name { get; set; }
        public string[] Args { get; set; }

        public static Command ParseCommand(string input)
        {
            string[] spaces = input.Split(new[] {" "}, 2, StringSplitOptions.RemoveEmptyEntries);
            return spaces[0] == input ? new Command(input) : new Command(spaces[0].TrimStart(new[] {'.', '/'}), spaces[1].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
        }

        public Command(string name, string[] args = null)
        {
            Name = name;
            Args = args;
        }
    }
}
