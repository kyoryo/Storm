/*
    Copyright 2016 Zoey (Zoryn)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace Storm
{
    public sealed class Command
    {
        public string Name { get; set; }
        public string[] Args { get; set; }

        public int ArgsCount => Args.Length;
        public bool HasArgs => ArgsCount > 0;

        public static Command ParseCommand(string input)
        {
            string[] spaces = input.Split(new[] { " " }, 2, StringSplitOptions.RemoveEmptyEntries);
            return spaces[0] == input ? new Command(input) : new Command(spaces[0].TrimStart(new[] { '.', '/' }), spaces[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }

        public Command(string name, string[] args = null)
        {
            Name = name;
            Args = args;
        }
    }
}
