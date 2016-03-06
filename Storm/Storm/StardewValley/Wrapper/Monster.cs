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
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Monster : NPC
    {
        private readonly MonsterAccessor accessor;

        public Monster(StaticContext parent, MonsterAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int DamageToFarmer
        {
            get { return accessor._GetDamageToFarmer(); }
            set { accessor._SetDamageToFarmer(value); }
        }

        public int Health
        {
            get { return accessor._GetHealth(); }
            set { accessor._SetHealth(value); }
        }

        public int MaxHealth
        {
            get { return accessor._GetMaxHealth(); }
            set { accessor._SetMaxHealth(value); }
        }

        public int CoinsToDrop
        {
            get { return accessor._GetCoinsToDrop(); }
            set { accessor._SetCoinsToDrop(value); }
        }

        public int DurationOfRandomMovements
        {
            get { return accessor._GetDurationOfRandomMovements(); }
            set { accessor._SetDurationOfRandomMovements(value); }
        }

        public int Resilience
        {
            get { return accessor._GetResilience(); }
            set { accessor._SetResilience(value); }
        }

        public int Slipperiness
        {
            get { return accessor._GetSlipperiness(); }
            set { accessor._SetSlipperiness(value); }
        }

        public int ExperienceGained
        {
            get { return accessor._GetExperienceGained(); }
            set { accessor._SetExperienceGained(value); }
        }

        public double Jitteriness
        {
            get { return accessor._GetJitteriness(); }
            set { accessor._SetJitteriness(value); }
        }

        public double MissChance
        {
            get { return accessor._GetMissChance(); }
            set { accessor._SetMissChance(value); }
        }

        public bool IsGlider
        {
            get { return accessor._GetIsGlider(); }
            set { accessor._SetIsGlider(value); }
        }

        public bool MineMonster
        {
            get { return accessor._GetMineMonster(); }
            set { accessor._SetMineMonster(value); }
        }

        public bool HasSpecialItem
        {
            get { return accessor._GetHasSpecialItem(); }
            set { accessor._SetHasSpecialItem(value); }
        }

        public IList ObjectsToDrop
        {
            get { return accessor._GetObjectsToDrop(); }
            set { accessor._SetObjectsToDrop(value); }
        }

        public int SkipHorizontal
        {
            get { return accessor._GetSkipHorizontal(); }
            set { accessor._SetSkipHorizontal(value); }
        }

        public int InvincibleCountdown
        {
            get { return accessor._GetInvincibleCountdown(); }
            set { accessor._SetInvincibleCountdown(value); }
        }

        public bool SkipHorizontalUp
        {
            get { return accessor._GetSkipHorizontalUp(); }
            set { accessor._SetSkipHorizontalUp(value); }
        }

        public int DefaultAnimationInterval
        {
            get { return accessor._GetDefaultAnimationInterval(); }
            set { accessor._SetDefaultAnimationInterval(value); }
        }

        public bool FocusedOnFarmers
        {
            get { return accessor._GetFocusedOnFarmers(); }
            set { accessor._SetFocusedOnFarmers(value); }
        }

        public int SlideAnimationTimer
        {
            get { return accessor._GetSlideAnimationTimer(); }
            set { accessor._SetSlideAnimationTimer(value); }
        }

        public new MonsterAccessor Expose() => accessor;
    }
}