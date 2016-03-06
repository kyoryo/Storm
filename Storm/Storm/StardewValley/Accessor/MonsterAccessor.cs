/*
    Copyright 2016 Inari

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

namespace Storm.StardewValley.Accessor
{
    public interface MonsterAccessor : NPCAccessor
    {
        int _GetDamageToFarmer();
        void _SetDamageToFarmer(int val);

        int _GetHealth();
        void _SetHealth(int val);

        int _GetMaxHealth();
        void _SetMaxHealth(int val);

        int _GetCoinsToDrop();
        void _SetCoinsToDrop(int val);

        int _GetDurationOfRandomMovements();
        void _SetDurationOfRandomMovements(int val);

        int _GetResilience();
        void _SetResilience(int val);

        int _GetSlipperiness();
        void _SetSlipperiness(int val);

        int _GetExperienceGained();
        void _SetExperienceGained(int val);

        double _GetJitteriness();
        void _SetJitteriness(double val);

        double _GetMissChance();
        void _SetMissChance(double val);

        bool _GetIsGlider();
        void _SetIsGlider(bool val);

        bool _GetMineMonster();
        void _SetMineMonster(bool val);

        bool _GetHasSpecialItem();
        void _SetHasSpecialItem(bool val);

        IList _GetObjectsToDrop();
        void _SetObjectsToDrop(IList val);

        int _GetSkipHorizontal();
        void _SetSkipHorizontal(int val);

        int _GetInvincibleCountdown();
        void _SetInvincibleCountdown(int val);

        bool _GetSkipHorizontalUp();
        void _SetSkipHorizontalUp(bool val);

        int _GetDefaultAnimationInterval();
        void _SetDefaultAnimationInterval(int val);

        bool _GetFocusedOnFarmers();
        void _SetFocusedOnFarmers(bool val);

        int _GetSlideAnimationTimer();
        void _SetSlideAnimationTimer(int val);
    }
}