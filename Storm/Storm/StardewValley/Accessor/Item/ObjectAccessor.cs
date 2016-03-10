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
using Microsoft.Xna.Framework.Audio;

namespace Storm.StardewValley.Accessor
{
    public interface ObjectAccessor : ItemAccessor
    {
        int _GetSellToStorePrice();

        Vector2 _GetTileLocation();
        void _SetTileLocation(Vector2 val);

        int _GetParentSheetIndex();
        void _SetParentSheetIndex(int val);

        long _GetOwner();
        void _SetOwner(long val);

        string _GetName();
        void _SetName(string val);

        string _GetType();
        void _SetType(string val);

        bool _GetCanBeSetDown();
        void _SetCanBeSetDown(bool val);

        bool _GetCanBeGrabbed();
        void _SetCanBeGrabbed(bool val);

        bool _GetIsHoedirt();
        void _SetIsHoedirt(bool val);

        bool _GetIsSpawnedObject();
        void _SetIsSpawnedObject(bool val);

        bool _GetQuestItem();
        void _SetQuestItem(bool val);

        bool _GetIsOn();
        void _SetIsOn(bool val);

        int _GetFragility();
        void _SetFragility(int val);

        bool _GetIsActive();
        void _SetIsActive(bool val);

        int _GetPrice();
        void _SetPrice(int val);

        int _GetEdibility();
        void _SetEdibility(int val);

        int _GetStack();
        void _SetStack(int val);

        int _GetQuality();
        void _SetQuality(int val);

        bool _GetBigCraftable();
        void _SetBigCraftable(bool val);

        bool _GetSetOutdoors();
        void _SetSetOutdoors(bool val);

        bool _GetSetIndoors();
        void _SetSetIndoors(bool val);

        bool _GetReadyForHarvest();
        void _SetReadyForHarvest(bool val);

        bool _GetShowNextIndex();
        void _SetShowNextIndex(bool val);

        bool _GetFlipped();
        void _SetFlipped(bool val);

        bool _GetHasBeenPickedUpByFarmer();
        void _SetHasBeenPickedUpByFarmer(bool val);

        bool _GetIsRecipe();
        void _SetIsRecipe(bool val);

        bool _GetIsLamp();
        void _SetIsLamp(bool val);

        ObjectAccessor _GetHeldObject();
        void _SetHeldObject(ObjectAccessor val);

        int _GetMinutesUntilReady();
        void _SetMinutesUntilReady(int val);

        Rectangle _GetBoundingBox();
        void _SetBoundingBox(Rectangle val);

        Vector2 _GetScale();
        void _SetScale(Vector2 val);

        int _GetShakeTimer();
        void _SetShakeTimer(int val);

        Cue _GetInternalSound();
        void _SetInternalSound(Cue val);

        int _GetHealth();
        void _SetHealth(int val);
    }
}