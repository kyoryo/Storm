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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class FishingRod : Tool
    {
        public FishingRod(StaticContext parent, FishingRodAccessor accessor) :
            base(parent, accessor)
        {
        }

        public FishingRod()
        {
        }

        public Vector2 Bobber
        {
            get { return Cast<FishingRodAccessor>()._GetBobber(); }
            set { Cast<FishingRodAccessor>()._SetBobber(value); }
        }

        public int MinFishingBiteTime
        {
            get { return Cast<FishingRodAccessor>()._GetMinFishingBiteTime(); }
            set { Cast<FishingRodAccessor>()._SetMinFishingBiteTime(value); }
        }

        public int MaxFishingBiteTime
        {
            get { return Cast<FishingRodAccessor>()._GetMaxFishingBiteTime(); }
            set { Cast<FishingRodAccessor>()._SetMaxFishingBiteTime(value); }
        }

        public int MinTimeToNibble
        {
            get { return Cast<FishingRodAccessor>()._GetMinTimeToNibble(); }
            set { Cast<FishingRodAccessor>()._SetMinTimeToNibble(value); }
        }

        public int MaxTimeToNibble
        {
            get { return Cast<FishingRodAccessor>()._GetMaxTimeToNibble(); }
            set { Cast<FishingRodAccessor>()._SetMaxTimeToNibble(value); }
        }

        public double BaseChanceForTreasure
        {
            get { return Cast<FishingRodAccessor>()._GetBaseChanceForTreasure(); }
            set { Cast<FishingRodAccessor>()._SetBaseChanceForTreasure(value); }
        }

        public int BobberBob
        {
            get { return Cast<FishingRodAccessor>()._GetBobberBob(); }
            set { Cast<FishingRodAccessor>()._SetBobberBob(value); }
        }

        public float BobberTimeAccumulator
        {
            get { return Cast<FishingRodAccessor>()._GetBobberTimeAccumulator(); }
            set { Cast<FishingRodAccessor>()._SetBobberTimeAccumulator(value); }
        }

        public float TimePerBobberBob
        {
            get { return Cast<FishingRodAccessor>()._GetTimePerBobberBob(); }
            set { Cast<FishingRodAccessor>()._SetTimePerBobberBob(value); }
        }

        public float TimeUntilFishingBite
        {
            get { return Cast<FishingRodAccessor>()._GetTimeUntilFishingBite(); }
            set { Cast<FishingRodAccessor>()._SetTimeUntilFishingBite(value); }
        }

        public float FishingBiteAccumulator
        {
            get { return Cast<FishingRodAccessor>()._GetFishingBiteAccumulator(); }
            set { Cast<FishingRodAccessor>()._SetFishingBiteAccumulator(value); }
        }

        public float FishingNibbleAccumulator
        {
            get { return Cast<FishingRodAccessor>()._GetFishingNibbleAccumulator(); }
            set { Cast<FishingRodAccessor>()._SetFishingNibbleAccumulator(value); }
        }

        public float TimeUntilFishingNibbleDone
        {
            get { return Cast<FishingRodAccessor>()._GetTimeUntilFishingNibbleDone(); }
            set { Cast<FishingRodAccessor>()._SetTimeUntilFishingNibbleDone(value); }
        }

        public float CastingPower
        {
            get { return Cast<FishingRodAccessor>()._GetCastingPower(); }
            set { Cast<FishingRodAccessor>()._SetCastingPower(value); }
        }

        public float CastingChosenCountdown
        {
            get { return Cast<FishingRodAccessor>()._GetCastingChosenCountdown(); }
            set { Cast<FishingRodAccessor>()._SetCastingChosenCountdown(value); }
        }

        public float CastingTimerSpeed
        {
            get { return Cast<FishingRodAccessor>()._GetCastingTimerSpeed(); }
            set { Cast<FishingRodAccessor>()._SetCastingTimerSpeed(value); }
        }

        public float FishWiggle
        {
            get { return Cast<FishingRodAccessor>()._GetFishWiggle(); }
            set { Cast<FishingRodAccessor>()._SetFishWiggle(value); }
        }

        public float FishWiggleIntensity
        {
            get { return Cast<FishingRodAccessor>()._GetFishWiggleIntensity(); }
            set { Cast<FishingRodAccessor>()._SetFishWiggleIntensity(value); }
        }

        public bool IsFishing
        {
            get { return Cast<FishingRodAccessor>()._GetIsFishing(); }
            set { Cast<FishingRodAccessor>()._SetIsFishing(value); }
        }

        public bool Hit
        {
            get { return Cast<FishingRodAccessor>()._GetHit(); }
            set { Cast<FishingRodAccessor>()._SetHit(value); }
        }

        public bool IsNibbling
        {
            get { return Cast<FishingRodAccessor>()._GetIsNibbling(); }
            set { Cast<FishingRodAccessor>()._SetIsNibbling(value); }
        }

        public bool FavBait
        {
            get { return Cast<FishingRodAccessor>()._GetFavBait(); }
            set { Cast<FishingRodAccessor>()._SetFavBait(value); }
        }

        public bool IsTimingCast
        {
            get { return Cast<FishingRodAccessor>()._GetIsTimingCast(); }
            set { Cast<FishingRodAccessor>()._SetIsTimingCast(value); }
        }

        public bool IsCasting
        {
            get { return Cast<FishingRodAccessor>()._GetIsCasting(); }
            set { Cast<FishingRodAccessor>()._SetIsCasting(value); }
        }

        public bool CastedButBobberStillInAir
        {
            get { return Cast<FishingRodAccessor>()._GetCastedButBobberStillInAir(); }
            set { Cast<FishingRodAccessor>()._SetCastedButBobberStillInAir(value); }
        }

        public bool DoneWithAnimation
        {
            get { return Cast<FishingRodAccessor>()._GetDoneWithAnimation(); }
            set { Cast<FishingRodAccessor>()._SetDoneWithAnimation(value); }
        }

        public bool HasDoneFucntionYet
        {
            get { return Cast<FishingRodAccessor>()._GetHasDoneFucntionYet(); }
            set { Cast<FishingRodAccessor>()._SetHasDoneFucntionYet(value); }
        }

        public bool PullingOutOfWater
        {
            get { return Cast<FishingRodAccessor>()._GetPullingOutOfWater(); }
            set { Cast<FishingRodAccessor>()._SetPullingOutOfWater(value); }
        }

        public bool IsReeling
        {
            get { return Cast<FishingRodAccessor>()._GetIsReeling(); }
            set { Cast<FishingRodAccessor>()._SetIsReeling(value); }
        }

        public bool FishCaught
        {
            get { return Cast<FishingRodAccessor>()._GetFishCaught(); }
            set { Cast<FishingRodAccessor>()._SetFishCaught(value); }
        }

        public bool RecordSize
        {
            get { return Cast<FishingRodAccessor>()._GetRecordSize(); }
            set { Cast<FishingRodAccessor>()._SetRecordSize(value); }
        }

        public bool TreasureCaught
        {
            get { return Cast<FishingRodAccessor>()._GetTreasureCaught(); }
            set { Cast<FishingRodAccessor>()._SetTreasureCaught(value); }
        }

        public bool ShowingTreasure
        {
            get { return Cast<FishingRodAccessor>()._GetShowingTreasure(); }
            set { Cast<FishingRodAccessor>()._SetShowingTreasure(value); }
        }

        public bool HadBobber
        {
            get { return Cast<FishingRodAccessor>()._GetHadBobber(); }
            set { Cast<FishingRodAccessor>()._SetHadBobber(value); }
        }

        public bool BossFish
        {
            get { return Cast<FishingRodAccessor>()._GetBossFish(); }
            set { Cast<FishingRodAccessor>()._SetBossFish(value); }
        }

        public IList Animations
        {
            get { return Cast<FishingRodAccessor>()._GetAnimations(); }
            set { Cast<FishingRodAccessor>()._SetAnimations(value); }
        }

        public int FishSize
        {
            get { return Cast<FishingRodAccessor>()._GetFishSize(); }
            set { Cast<FishingRodAccessor>()._SetFishSize(value); }
        }

        public int WhichFish
        {
            get { return Cast<FishingRodAccessor>()._GetWhichFish(); }
            set { Cast<FishingRodAccessor>()._SetWhichFish(value); }
        }

        public int FishQuality
        {
            get { return Cast<FishingRodAccessor>()._GetFishQuality(); }
            set { Cast<FishingRodAccessor>()._SetFishQuality(value); }
        }

        public int ClearWaterDistance
        {
            get { return Cast<FishingRodAccessor>()._GetClearWaterDistance(); }
            set { Cast<FishingRodAccessor>()._SetClearWaterDistance(value); }
        }

        public int OriginalFacingDirection
        {
            get { return Cast<FishingRodAccessor>()._GetOriginalFacingDirection(); }
            set { Cast<FishingRodAccessor>()._SetOriginalFacingDirection(value); }
        }

        public Cue ChargeSound
        {
            get { return Cast<FishingRodAccessor>()._GetChargeSound(); }
            set { Cast<FishingRodAccessor>()._SetChargeSound(value); }
        }

        public Cue ReelSound
        {
            get { return Cast<FishingRodAccessor>()._GetReelSound(); }
            set { Cast<FishingRodAccessor>()._SetReelSound(value); }
        }

        public bool UsedGamePadToCast
        {
            get { return Cast<FishingRodAccessor>()._GetUsedGamePadToCast(); }
            set { Cast<FishingRodAccessor>()._SetUsedGamePadToCast(value); }
        }
    }
}