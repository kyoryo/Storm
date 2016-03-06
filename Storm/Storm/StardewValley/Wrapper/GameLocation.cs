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
using Microsoft.Xna.Framework;
using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class GameLocation : Wrapper<GameLocationAccessor>
    {
        public StaticContext Parent { get; }
        private GameLocationAccessor accessor;

        public GameLocation(StaticContext parent, GameLocationAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public Dictionary<Vector2, Object> Objects
        {
            get
            {
                var orig = accessor._GetObjects();
                var conv = new Dictionary<Vector2, Object>();
                foreach (var vec in orig.Keys)
                {
                    conv.Add((Vector2)vec, new Object(Parent, (ObjectAccessor)orig[vec]));
                }
                return conv;
            }
        }

        public Dictionary<Vector2, TerrainFeature> TerrainFeatures
        {
            get
            {
                var orig = accessor._GetTerrainFeatures();
                var conv = new Dictionary<Vector2, TerrainFeature>();
                foreach (var vec in orig.Keys)
                {
                    conv.Add((Vector2)vec, new TerrainFeature(Parent, (TerrainFeatureAccessor)orig[vec]));
                }
                return conv;
            }
        }

        public void GrowWeedGrass(int iterations)
        {
            accessor._GrowWeedGrass(iterations);
        }

        public bool IsOutdoors
        {
            get { return accessor._GetIsOutdoors(); }
            set { accessor._SetIsOutdoors(value); }
        }

        public List<NPC> Characters
        {
            get
            {
                var charList = accessor._GetCharacters().Cast<NPCAccessor>().ToList<NPCAccessor>();
                if (charList == null)
                {
                    return null;
                }
                return charList.Select(c => new NPC(Parent, c as NPCAccessor)).ToList();
            }
        }

        public List<Monster> Monsters
        {
            get
            {
                var charList = accessor._GetCharacters().Cast<NPCAccessor>().ToList<NPCAccessor>();
                if (charList == null)
                {
                    return null;
                }

                var monsters = charList.Where(c => c is MonsterAccessor).Select(c => new Monster(Parent, c as MonsterAccessor)).ToList();
                return monsters;
            }
        }

        public Object GetObjectAt(int tileX, int tileY)
        {
            var game = StaticGameContext.WrappedGame;
            var key = new Vector2(tileX / game.TileSize, tileY / game.TileSize);
            var objects = Objects;
            if (objects.ContainsKey(key))
            {
                return objects[key];
            }
            return null;
        }

        public GameLocationAccessor Expose() => accessor;
    }
}
