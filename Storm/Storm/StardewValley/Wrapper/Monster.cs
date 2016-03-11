/*
    Copyright 2016 Inari-Whitebear

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

namespace Storm.StardewValley.Wrapper
{
    public class Monster : NPC
    {
        public Monster(StaticContext parent, MonsterAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Monster()
        {
        }

        public int DamageToFarmer
        {
            get { return Cast<MonsterAccessor>()._GetDamageToFarmer(); }
            set { Cast<MonsterAccessor>()._SetDamageToFarmer(value); }
        }

        public int Health
        {
            get { return Cast<MonsterAccessor>()._GetHealth(); }
            set { Cast<MonsterAccessor>()._SetHealth(value); }
        }

        public int MaxHealth
        {
            get { return Cast<MonsterAccessor>()._GetMaxHealth(); }
            set { Cast<MonsterAccessor>()._SetMaxHealth(value); }
        }

        public int CoinsToDrop
        {
            get { return Cast<MonsterAccessor>()._GetCoinsToDrop(); }
            set { Cast<MonsterAccessor>()._SetCoinsToDrop(value); }
        }

        public int DurationOfRandomMovements
        {
            get { return Cast<MonsterAccessor>()._GetDurationOfRandomMovements(); }
            set { Cast<MonsterAccessor>()._SetDurationOfRandomMovements(value); }
        }

        public int Resilience
        {
            get { return Cast<MonsterAccessor>()._GetResilience(); }
            set { Cast<MonsterAccessor>()._SetResilience(value); }
        }

        public int Slipperiness
        {
            get { return Cast<MonsterAccessor>()._GetSlipperiness(); }
            set { Cast<MonsterAccessor>()._SetSlipperiness(value); }
        }

        public int ExperienceGained
        {
            get { return Cast<MonsterAccessor>()._GetExperienceGained(); }
            set { Cast<MonsterAccessor>()._SetExperienceGained(value); }
        }

        public double Jitteriness
        {
            get { return Cast<MonsterAccessor>()._GetJitteriness(); }
            set { Cast<MonsterAccessor>()._SetJitteriness(value); }
        }

        public double MissChance
        {
            get { return Cast<MonsterAccessor>()._GetMissChance(); }
            set { Cast<MonsterAccessor>()._SetMissChance(value); }
        }

        public bool IsGlider
        {
            get { return Cast<MonsterAccessor>()._GetIsGlider(); }
            set { Cast<MonsterAccessor>()._SetIsGlider(value); }
        }

        public bool MineMonster
        {
            get { return Cast<MonsterAccessor>()._GetMineMonster(); }
            set { Cast<MonsterAccessor>()._SetMineMonster(value); }
        }

        public bool HasSpecialItem
        {
            get { return Cast<MonsterAccessor>()._GetHasSpecialItem(); }
            set { Cast<MonsterAccessor>()._SetHasSpecialItem(value); }
        }

        public int SkipHorizontal
        {
            get { return Cast<MonsterAccessor>()._GetSkipHorizontal(); }
            set { Cast<MonsterAccessor>()._SetSkipHorizontal(value); }
        }

        public int InvincibleCountdown
        {
            get { return Cast<MonsterAccessor>()._GetInvincibleCountdown(); }
            set { Cast<MonsterAccessor>()._SetInvincibleCountdown(value); }
        }

        public bool SkipHorizontalUp
        {
            get { return Cast<MonsterAccessor>()._GetSkipHorizontalUp(); }
            set { Cast<MonsterAccessor>()._SetSkipHorizontalUp(value); }
        }

        public int DefaultAnimationInterval
        {
            get { return Cast<MonsterAccessor>()._GetDefaultAnimationInterval(); }
            set { Cast<MonsterAccessor>()._SetDefaultAnimationInterval(value); }
        }

        public bool FocusedOnFarmers
        {
            get { return Cast<MonsterAccessor>()._GetFocusedOnFarmers(); }
            set { Cast<MonsterAccessor>()._SetFocusedOnFarmers(value); }
        }

        public int SlideAnimationTimer
        {
            get { return Cast<MonsterAccessor>()._GetSlideAnimationTimer(); }
            set { Cast<MonsterAccessor>()._SetSlideAnimationTimer(value); }
        }
    }
}