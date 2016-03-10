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

using System.Collections;
using Microsoft.Xna.Framework;
using xTile;

namespace Storm.StardewValley.Accessor
{
    public interface GameLocationAccessor
    {
        void _GrowWeedGrass(int iterations);

        Map _GetMap();
        void _SetMap(Map val);

        IList _GetCharacters();
        void _SetCharacters(IList val);

        IDictionary _GetObjects();
        void _SetObjects(IDictionary val);

        IList _GetTemporarySprites();
        void _SetTemporarySprites(IList val);

        IList _GetWarps();
        void _SetWarps(IList val);

        IDictionary _GetDoors();
        void _SetDoors(IDictionary val);

        IDictionary _GetDoorSprites();
        void _SetDoorSprites(IDictionary val);

        IList _GetFarmers();
        void _SetFarmers(IList val);

        IList _GetProjectiles();
        void _SetProjectiles(IList val);

        IList _GetLargeTerrainFeatures();
        void _SetLargeTerrainFeatures(IList val);

        IList _GetCritters();
        void _SetCritters(IList val);

        IDictionary _GetTerrainFeatures();
        void _SetTerrainFeatures(IDictionary val);

        IList _GetDebris();
        void _SetDebris(IList val);

        Point _GetFishSplashPoint();
        void _SetFishSplashPoint(Point val);

        Point _GetOrePanPoint();
        void _SetOrePanPoint(Point val);

        TempAnimatedSpriteAccessor _GetFishSplashAnimation();
        void _SetFishSplashAnimation(TempAnimatedSpriteAccessor val);

        TempAnimatedSpriteAccessor _GetOrePanAnimation();
        void _SetOrePanAnimation(TempAnimatedSpriteAccessor val);

        bool _GetWaterTiles();
        void _SetWaterTiles(bool val);

        string _GetUniqueName();
        void _SetUniqueName(string val);

        string _GetName();
        void _SetName(string val);

        Color _GetWaterColor();
        void _SetWaterColor(Color val);

        string _GetLastQuestionKey();
        void _SetLastQuestionKey(string val);

        Vector2 _GetLastTouchActionLocation();
        void _SetLastTouchActionLocation(Vector2 val);

        float _GetLightLevel();
        void _SetLightLevel(float val);

        bool _GetIsFarm();
        void _SetIsFarm(bool val);

        bool _GetIsOutdoors();
        void _SetIsOutdoors(bool val);

        bool _GetIsStructure();
        void _SetIsStructure(bool val);

        bool _GetIgnoreDebrisWeather();
        void _SetIgnoreDebrisWeather(bool val);

        bool _GetIgnoreOutdoorLighting();
        void _SetIgnoreOutdoorLighting(bool val);

        bool _GetIgnoreLights();
        void _SetIgnoreLights(bool val);

        bool _GetWasUpdated();
        void _SetWasUpdated(bool val);

        IList _GetTerrainFeaturesToRemoveList();
        void _SetTerrainFeaturesToRemoveList(IList val);

        int _GetNumberOfSpawnedObjectsOnMap();
        void _SetNumberOfSpawnedObjectsOnMap(int val);

        EventAccessor _GetCurrentEvent();
        void _SetCurrentEvent(EventAccessor val);

        ObjectAccessor _GetActionObjectForQuestionDialogue();
        void _SetActionObjectForQuestionDialogue(ObjectAccessor val);

        int _GetWaterAnimationIndex();
        void _SetWaterAnimationIndex(int val);

        int _GetWaterAnimationTimer();
        void _SetWaterAnimationTimer(int val);

        bool _GetWaterTileFlip();
        void _SetWaterTileFlip(bool val);

        bool _GetForceViewportPlayerFollow();
        void _SetForceViewportPlayerFollow(bool val);

        float _GetWaterPosition();
        void _SetWaterPosition(float val);

        Vector2 _GetSnowPos();
        void _SetSnowPos(Vector2 val);

        IList _GetLightGlows();
        void _SetLightGlows(IList val);

        int _GetFireIDBase();
        void _SetFireIDBase(int val);

        int _GetClicks();
        void _SetClicks(int val);

        void _MakeHoeDirt(Vector2 loc);

        string _GetTileProperty(int tileX, int tileY, string propName, string layerName);
    }
}