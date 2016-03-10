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

namespace Storm.StardewValley.Accessor
{
    public interface MineShaftAccessor : GameLocationAccessor
    {
        System.Collections.IDictionary _GetPermanentMineChanges();
        void _SetPermanentMineChanges(System.Collections.IDictionary val);

        System.Collections.IList _GetResourceClumps();
        void _SetResourceClumps(System.Collections.IList val);

        System.Random _GetMineRandom();
        void _SetMineRandom(System.Random val);

        int _GetMineLevel();
        void _SetMineLevel(int val);

        int _GetNextLevel();
        void _SetNextLevel(int val);

        int _GetLowestLevelReached();
        void _SetLowestLevelReached(int val);

        Microsoft.Xna.Framework.Content.ContentManager _GetMineLoader();
        void _SetMineLoader(Microsoft.Xna.Framework.Content.ContentManager val);

        Microsoft.Xna.Framework.Vector2 _GetTileBeneathLadder();
        void _SetTileBeneathLadder(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Vector2 _GetTileBeneathElevator();
        void _SetTileBeneathElevator(Microsoft.Xna.Framework.Vector2 val);

        int _GetStonesLeftOnThisLevel();
        void _SetStonesLeftOnThisLevel(int val);

        int _GetTimeSinceLastMusic();
        void _SetTimeSinceLastMusic(int val);

        int _GetTimeUntilElevatorLightUp();
        void _SetTimeUntilElevatorLightUp(int val);

        int _GetFogTime();
        void _SetFogTime(int val);

        Microsoft.Xna.Framework.Point _GetElevatorLightSpot();
        void _SetElevatorLightSpot(Microsoft.Xna.Framework.Point val);

        bool _GetLadderHasSpawned();
        void _SetLadderHasSpawned(bool val);

        bool _GetGhostAdded();
        void _SetGhostAdded(bool val);

        bool _GetLoadedDarkArea();
        void _SetLoadedDarkArea(bool val);

        bool _GetIsSlimeArea();
        void _SetIsSlimeArea(bool val);

        bool _GetIsMonsterArea();
        void _SetIsMonsterArea(bool val);

        bool _GetIsFallingDownShaft();
        void _SetIsFallingDownShaft(bool val);

        bool _GetAmbientFog();
        void _SetAmbientFog(bool val);

        Microsoft.Xna.Framework.Vector2 _GetFogPos();
        void _SetFogPos(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Color _GetLighting();
        void _SetLighting(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Color _GetFogColor();
        void _SetFogColor(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Point _GetMostRecentLadder();
        void _SetMostRecentLadder(Microsoft.Xna.Framework.Point val);

        float _GetFogAlpha();
        void _SetFogAlpha(float val);

        Microsoft.Xna.Framework.Audio.Cue _GetBugLevelLoop();
        void _SetBugLevelLoop(Microsoft.Xna.Framework.Audio.Cue val);

        bool _GetRainbowLights();
        void _SetRainbowLights(bool val);

        bool _GetIsLightingDark();
        void _SetIsLightingDark(bool val);

        int _GetLastLevelsDownFallen();
        void _SetLastLevelsDownFallen(int val);

        Microsoft.Xna.Framework.Rectangle _GetFogSource();
        void _SetFogSource(Microsoft.Xna.Framework.Rectangle val);
    }
}