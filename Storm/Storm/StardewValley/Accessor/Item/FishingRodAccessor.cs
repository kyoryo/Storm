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

namespace Storm.StardewValley.Accessor
{
    public interface FishingRodAccessor : ToolAccessor
    {
        Vector2 _GetBobber();
        void _SetBobber(Vector2 val);

        int _GetMinFishingBiteTime();
        void _SetMinFishingBiteTime(int val);

        int _GetMaxFishingBiteTime();
        void _SetMaxFishingBiteTime(int val);

        int _GetMinTimeToNibble();
        void _SetMinTimeToNibble(int val);

        int _GetMaxTimeToNibble();
        void _SetMaxTimeToNibble(int val);

        double _GetBaseChanceForTreasure();
        void _SetBaseChanceForTreasure(double val);

        int _GetBobberBob();
        void _SetBobberBob(int val);

        float _GetBobberTimeAccumulator();
        void _SetBobberTimeAccumulator(float val);

        float _GetTimePerBobberBob();
        void _SetTimePerBobberBob(float val);

        float _GetTimeUntilFishingBite();
        void _SetTimeUntilFishingBite(float val);

        float _GetFishingBiteAccumulator();
        void _SetFishingBiteAccumulator(float val);

        float _GetFishingNibbleAccumulator();
        void _SetFishingNibbleAccumulator(float val);

        float _GetTimeUntilFishingNibbleDone();
        void _SetTimeUntilFishingNibbleDone(float val);

        float _GetCastingPower();
        void _SetCastingPower(float val);

        float _GetCastingChosenCountdown();
        void _SetCastingChosenCountdown(float val);

        float _GetCastingTimerSpeed();
        void _SetCastingTimerSpeed(float val);

        float _GetFishWiggle();
        void _SetFishWiggle(float val);

        float _GetFishWiggleIntensity();
        void _SetFishWiggleIntensity(float val);

        bool _GetIsFishing();
        void _SetIsFishing(bool val);

        bool _GetHit();
        void _SetHit(bool val);

        bool _GetIsNibbling();
        void _SetIsNibbling(bool val);

        bool _GetFavBait();
        void _SetFavBait(bool val);

        bool _GetIsTimingCast();
        void _SetIsTimingCast(bool val);

        bool _GetIsCasting();
        void _SetIsCasting(bool val);

        bool _GetCastedButBobberStillInAir();
        void _SetCastedButBobberStillInAir(bool val);

        bool _GetDoneWithAnimation();
        void _SetDoneWithAnimation(bool val);

        bool _GetHasDoneFucntionYet();
        void _SetHasDoneFucntionYet(bool val);

        bool _GetPullingOutOfWater();
        void _SetPullingOutOfWater(bool val);

        bool _GetIsReeling();
        void _SetIsReeling(bool val);

        bool _GetFishCaught();
        void _SetFishCaught(bool val);

        bool _GetRecordSize();
        void _SetRecordSize(bool val);

        bool _GetTreasureCaught();
        void _SetTreasureCaught(bool val);

        bool _GetShowingTreasure();
        void _SetShowingTreasure(bool val);

        bool _GetHadBobber();
        void _SetHadBobber(bool val);

        bool _GetBossFish();
        void _SetBossFish(bool val);

        IList _GetAnimations();
        void _SetAnimations(IList val);

        int _GetFishSize();
        void _SetFishSize(int val);

        int _GetWhichFish();
        void _SetWhichFish(int val);

        int _GetFishQuality();
        void _SetFishQuality(int val);

        int _GetClearWaterDistance();
        void _SetClearWaterDistance(int val);

        int _GetOriginalFacingDirection();
        void _SetOriginalFacingDirection(int val);

        Cue _GetChargeSound();
        void _SetChargeSound(Cue val);

        Cue _GetReelSound();
        void _SetReelSound(Cue val);

        bool _GetUsedGamePadToCast();
        void _SetUsedGamePadToCast(bool val);
    }
}