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
using Microsoft.Xna.Framework.Audio;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class FishingRod : Tool
    {
        private readonly FishingRodAccessor accessor;

        public FishingRod(StaticContext parent, FishingRodAccessor accessor) :
            base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public Vector2 Bobber
        {
            get { return accessor._GetBobber(); }
            set { accessor._SetBobber(value); }
        }

        public int MinFishingBiteTime
        {
            get { return accessor._GetMinFishingBiteTime(); }
            set { accessor._SetMinFishingBiteTime(value); }
        }

        public int MaxFishingBiteTime
        {
            get { return accessor._GetMaxFishingBiteTime(); }
            set { accessor._SetMaxFishingBiteTime(value); }
        }

        public int MinTimeToNibble
        {
            get { return accessor._GetMinTimeToNibble(); }
            set { accessor._SetMinTimeToNibble(value); }
        }

        public int MaxTimeToNibble
        {
            get { return accessor._GetMaxTimeToNibble(); }
            set { accessor._SetMaxTimeToNibble(value); }
        }

        public double BaseChanceForTreasure
        {
            get { return accessor._GetBaseChanceForTreasure(); }
            set { accessor._SetBaseChanceForTreasure(value); }
        }

        public int BobberBob
        {
            get { return accessor._GetBobberBob(); }
            set { accessor._SetBobberBob(value); }
        }

        public float BobberTimeAccumulator
        {
            get { return accessor._GetBobberTimeAccumulator(); }
            set { accessor._SetBobberTimeAccumulator(value); }
        }

        public float TimePerBobberBob
        {
            get { return accessor._GetTimePerBobberBob(); }
            set { accessor._SetTimePerBobberBob(value); }
        }

        public float TimeUntilFishingBite
        {
            get { return accessor._GetTimeUntilFishingBite(); }
            set { accessor._SetTimeUntilFishingBite(value); }
        }

        public float FishingBiteAccumulator
        {
            get { return accessor._GetFishingBiteAccumulator(); }
            set { accessor._SetFishingBiteAccumulator(value); }
        }

        public float FishingNibbleAccumulator
        {
            get { return accessor._GetFishingNibbleAccumulator(); }
            set { accessor._SetFishingNibbleAccumulator(value); }
        }

        public float TimeUntilFishingNibbleDone
        {
            get { return accessor._GetTimeUntilFishingNibbleDone(); }
            set { accessor._SetTimeUntilFishingNibbleDone(value); }
        }

        public float CastingPower
        {
            get { return accessor._GetCastingPower(); }
            set { accessor._SetCastingPower(value); }
        }

        public float CastingChosenCountdown
        {
            get { return accessor._GetCastingChosenCountdown(); }
            set { accessor._SetCastingChosenCountdown(value); }
        }

        public float CastingTimerSpeed
        {
            get { return accessor._GetCastingTimerSpeed(); }
            set { accessor._SetCastingTimerSpeed(value); }
        }

        public float FishWiggle
        {
            get { return accessor._GetFishWiggle(); }
            set { accessor._SetFishWiggle(value); }
        }

        public float FishWiggleIntensity
        {
            get { return accessor._GetFishWiggleIntensity(); }
            set { accessor._SetFishWiggleIntensity(value); }
        }

        public bool IsFishing
        {
            get { return accessor._GetIsFishing(); }
            set { accessor._SetIsFishing(value); }
        }

        public bool Hit
        {
            get { return accessor._GetHit(); }
            set { accessor._SetHit(value); }
        }

        public bool IsNibbling
        {
            get { return accessor._GetIsNibbling(); }
            set { accessor._SetIsNibbling(value); }
        }

        public bool FavBait
        {
            get { return accessor._GetFavBait(); }
            set { accessor._SetFavBait(value); }
        }

        public bool IsTimingCast
        {
            get { return accessor._GetIsTimingCast(); }
            set { accessor._SetIsTimingCast(value); }
        }

        public bool IsCasting
        {
            get { return accessor._GetIsCasting(); }
            set { accessor._SetIsCasting(value); }
        }

        public bool CastedButBobberStillInAir
        {
            get { return accessor._GetCastedButBobberStillInAir(); }
            set { accessor._SetCastedButBobberStillInAir(value); }
        }

        public bool DoneWithAnimation
        {
            get { return accessor._GetDoneWithAnimation(); }
            set { accessor._SetDoneWithAnimation(value); }
        }

        public bool HasDoneFucntionYet
        {
            get { return accessor._GetHasDoneFucntionYet(); }
            set { accessor._SetHasDoneFucntionYet(value); }
        }

        public bool PullingOutOfWater
        {
            get { return accessor._GetPullingOutOfWater(); }
            set { accessor._SetPullingOutOfWater(value); }
        }

        public bool IsReeling
        {
            get { return accessor._GetIsReeling(); }
            set { accessor._SetIsReeling(value); }
        }

        public bool FishCaught
        {
            get { return accessor._GetFishCaught(); }
            set { accessor._SetFishCaught(value); }
        }

        public bool RecordSize
        {
            get { return accessor._GetRecordSize(); }
            set { accessor._SetRecordSize(value); }
        }

        public bool TreasureCaught
        {
            get { return accessor._GetTreasureCaught(); }
            set { accessor._SetTreasureCaught(value); }
        }

        public bool ShowingTreasure
        {
            get { return accessor._GetShowingTreasure(); }
            set { accessor._SetShowingTreasure(value); }
        }

        public bool HadBobber
        {
            get { return accessor._GetHadBobber(); }
            set { accessor._SetHadBobber(value); }
        }

        public bool BossFish
        {
            get { return accessor._GetBossFish(); }
            set { accessor._SetBossFish(value); }
        }

        public IList Animations
        {
            get { return accessor._GetAnimations(); }
            set { accessor._SetAnimations(value); }
        }

        public int FishSize
        {
            get { return accessor._GetFishSize(); }
            set { accessor._SetFishSize(value); }
        }

        public int WhichFish
        {
            get { return accessor._GetWhichFish(); }
            set { accessor._SetWhichFish(value); }
        }

        public int FishQuality
        {
            get { return accessor._GetFishQuality(); }
            set { accessor._SetFishQuality(value); }
        }

        public int ClearWaterDistance
        {
            get { return accessor._GetClearWaterDistance(); }
            set { accessor._SetClearWaterDistance(value); }
        }

        public int OriginalFacingDirection
        {
            get { return accessor._GetOriginalFacingDirection(); }
            set { accessor._SetOriginalFacingDirection(value); }
        }

        public Cue ChargeSound
        {
            get { return accessor._GetChargeSound(); }
            set { accessor._SetChargeSound(value); }
        }

        public Cue ReelSound
        {
            get { return accessor._GetReelSound(); }
            set { accessor._SetReelSound(value); }
        }

        public bool UsedGamePadToCast
        {
            get { return accessor._GetUsedGamePadToCast(); }
            set { accessor._SetUsedGamePadToCast(value); }
        }

        public new FishingRodAccessor Expose() => accessor;
    }
}