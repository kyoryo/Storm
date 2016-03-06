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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ObjectAccessor : ItemAccessor
    {
        bool _GetCanBeGrabbed();
        void _SetCanBeGrabbed(bool canBeGrabbed);

        bool _GetCanBeSetDown();
        void _SetCanBeSetDown(bool canBeSetDown);

        int _GetEdibility();
        void _SetEdibility(int edibility);

        bool _GetFlipped();
        void _SetFlipped(bool flipped);

        int _GetFragility();
        void _SetFragility(int fragility);

        bool _GetHasBeenPickedUpByFarmer();
        void _SetHasBeenPickedUpByFarmer(bool hasBeenPickedUp);

        bool _GetIsActive();
        void _SetIsActive(bool active);

        bool _GetIsHoeDirt();
        void _SetIsHoeDirt(bool isHoeDirt);

        bool _GetIsLamp();
        void _SetIsLamp(bool isLamp);

        bool _GetIsOn();
        void _SetIsOn(bool on);

        bool _GetIsRecipe();
        void _SetIsRecipe(bool isRecipe);

        bool _GetIsSpawnedObject();
        void _SetIsSpawnedObject(bool spawned);

        string _GetName();
        void _SetName(string name);

        long _GetOwner();
        void _SetOwner(long owner);

        int _GetPrice();
        void _SetPrice(int price);

        int _GetQuality();
        void _SetQuality(int quality);

        bool _GetIsQuestItem();
        void _SetIsQuestItem(bool questItem);

        bool _GetIsReadyForHarvest();
        void _SetIsReadyForHarvest(bool ready);

        Vector2 _GetScale();
        void _SetScale(Vector2 scale);

        string _GetType();
        void _SetType(string type);

    }
}
