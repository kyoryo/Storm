using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface FishingRodAccessor : ToolAccessor
    {
        Microsoft.Xna.Framework.Vector2 _GetBobber();
        void _SetBobber(Microsoft.Xna.Framework.Vector2 val);

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

        System.Collections.IList _GetAnimations();
        void _SetAnimations(System.Collections.IList val);

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

        Microsoft.Xna.Framework.Audio.Cue _GetChargeSound();
        void _SetChargeSound(Microsoft.Xna.Framework.Audio.Cue val);

        Microsoft.Xna.Framework.Audio.Cue _GetReelSound();
        void _SetReelSound(Microsoft.Xna.Framework.Audio.Cue val);

        bool _GetUsedGamePadToCast();
        void _SetUsedGamePadToCast(bool val);

    }
}
