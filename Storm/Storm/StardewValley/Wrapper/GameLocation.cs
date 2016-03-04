/*
    Copyright 2016 Cody R. (Demmonic)

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
using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class GameLocation
    {
        private GameLocationAccessor accessor;

        public GameLocation(GameLocationAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool IsOutdoors()
        {
            return accessor._GetIsOutdoors();
        }

        public List<NPC> getCharacters()
        {
            List<NPCAccessor> chList = accessor._GetCharacters().Cast<NPCAccessor>().ToList<NPCAccessor>();
            if (chList == null) {
                Console.WriteLine("is null");
                return null;
            }
            //return chList;
            return chList.ConvertAll<NPC>(new Converter<NPCAccessor, NPC>(x =>
            {
                return new NPC(x);
            }));
        }

        public List<Monster> getMonsters()
        {
            List<NPCAccessor> chList = accessor._GetCharacters().Cast<NPCAccessor>().ToList<NPCAccessor>();
            if (chList == null)
            {
                Console.WriteLine("is null");
                return null;
            }
            //return chList;
            Console.WriteLine("accessors: " + chList.Count);
            var monsters = (from npc in chList where npc is MonsterAccessor select npc).ToList().ConvertAll<Monster>(new Converter<NPCAccessor, Monster>(x =>
            {
                return new Monster(x as MonsterAccessor);
            }));
            Console.WriteLine("monsters: " + monsters.Count);
            return monsters;
        }
    }
}
