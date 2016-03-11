/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class GameLocation : StaticContextWrapper
    {
        public GameLocation(StaticContext parent, GameLocationAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public GameLocation()
        {

        }

        public ValueProxyDictionary<Vector2, ObjectAccessor, ObjectItem> Objects
        {
            get
            {
                var tmp = Cast<GameLocationAccessor>()._GetObjects();
                if (tmp == null) return null;
                return new ValueProxyDictionary<Vector2, ObjectAccessor, ObjectItem>(tmp,
                    o => o == null ? null : new ObjectItem(Parent, o));
            }
        }

        public ObjectItem GetObjectAt(int tileX, int tileY)
        {
            var key = new Vector2(tileX / Parent.TileSize, tileY / Parent.TileSize);
            var objects = Objects;
            if (objects.ContainsKey(key))
            {
                return objects[key];
            }
            return null;
        }

        public ValueProxyDictionary<Vector2, TerrainFeatureAccessor, TerrainFeature> TerrainFeatures
        {
            get
            {
                var tmp = Cast<GameLocationAccessor>()._GetTerrainFeatures();
                if (tmp == null) return null;
                return new ValueProxyDictionary<Vector2, TerrainFeatureAccessor, TerrainFeature>(tmp,
                    tf => tf == null ? null : new TerrainFeature(Parent, tf));
            }
        }

        public WrappedProxyList<NPCAccessor, NPC> Characters
        {
            get
            {
                var tmp = Cast<GameLocationAccessor>()._GetCharacters();
                if (tmp == null) return null;
                return new WrappedProxyList<NPCAccessor, NPC>(tmp,
                    c => c == null ? null : new NPC(Parent, c));
            }
        }

        public void AddHoeDirtAt(Vector2 tileLocation)
        {
            Cast<GameLocationAccessor>()._MakeHoeDirt(tileLocation);
        }

        public string GetTileProperty(int tileX, int tileY, string propName, string layerName)
        {
            return Cast<GameLocationAccessor>()._GetTileProperty(tileX, tileY, propName, layerName);
        }

        public bool IsOutdoors
        {
            get { return Cast<GameLocationAccessor>()._GetIsOutdoors(); }
            set { Cast<GameLocationAccessor>()._SetIsOutdoors(value); }
        }

        public string Name
        {
            get { return Cast<GameLocationAccessor>()._GetName(); }
            set { Cast<GameLocationAccessor>()._SetName(value); }
        }

        public Event CurrentEvent
        {
            get
            {
                var tmp = Cast<GameLocationAccessor>()._GetCurrentEvent();
                if (tmp == null) return null;
                return new Event(Parent, tmp);
            }
            set { Cast<GameLocationAccessor>()._SetCurrentEvent(value?.Cast<EventAccessor>()); }
        }

        public void GrowWeedGrass(int iterations)
        {
            Cast<GameLocationAccessor>()._GrowWeedGrass(iterations);
        }
    }
}