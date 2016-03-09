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
    public interface BobberBarAccessor : ClickableMenuAccessor
    {
        float _GetDifficulty();
        void _SetDifficulty(float val);

        int _GetMotionType();
        void _SetMotionType(int val);

        int _GetWhichFish();
        void _SetWhichFish(int val);

        float _GetBobberPosition();
        void _SetBobberPosition(float val);

        float _GetBobberSpeed();
        void _SetBobberSpeed(float val);

        float _GetBobberAcceleration();
        void _SetBobberAcceleration(float val);

        float _GetBobberTargetPosition();
        void _SetBobberTargetPosition(float val);

        float _GetScale();
        void _SetScale(float val);

        float _GetEverythingShakeTimer();
        void _SetEverythingShakeTimer(float val);

        float _GetFloaterSinkerAcceleration();
        void _SetFloaterSinkerAcceleration(float val);

        float _GetTreasurePosition();
        void _SetTreasurePosition(float val);

        float _GetTreasureCatchLevel();
        void _SetTreasureCatchLevel(float val);

        float _GetTreasureAppearTimer();
        void _SetTreasureAppearTimer(float val);

        float _GetTreasureScale();
        void _SetTreasureScale(float val);

        bool _GetBobberInBar();
        void _SetBobberInBar(bool val);

        bool _GetButtonPressed();
        void _SetButtonPressed(bool val);

        bool _GetFlipBubble();
        void _SetFlipBubble(bool val);

        bool _GetFadeIn();
        void _SetFadeIn(bool val);

        bool _GetFadeOut();
        void _SetFadeOut(bool val);

        bool _GetTreasure();
        void _SetTreasure(bool val);

        bool _GetTreasureCaught();
        void _SetTreasureCaught(bool val);

        bool _GetPerfect();
        void _SetPerfect(bool val);

        bool _GetBossFish();
        void _SetBossFish(bool val);

        int _GetBobberBarHeight();
        void _SetBobberBarHeight(int val);

        int _GetFishSize();
        void _SetFishSize(int val);

        int _GetFishQuality();
        void _SetFishQuality(int val);

        int _GetMinFishSize();
        void _SetMinFishSize(int val);

        int _GetMaxFishSize();
        void _SetMaxFishSize(int val);

        int _GetFishSizeReductionTimer();
        void _SetFishSizeReductionTimer(int val);

        int _GetWhichBobber();
        void _SetWhichBobber(int val);

        Vector2 _GetBarShake();
        void _SetBarShake(Vector2 val);

        Vector2 _GetFishShake();
        void _SetFishShake(Vector2 val);

        Vector2 _GetEverythingShake();
        void _SetEverythingShake(Vector2 val);

        Vector2 _GetTreasureShake();
        void _SetTreasureShake(Vector2 val);

        float _GetReelRotation();
        void _SetReelRotation(float val);

        float _GetBobberBarPos();
        void _SetBobberBarPos(float val);

        float _GetBobberBarSpeed();
        void _SetBobberBarSpeed(float val);

        float _GetBobberBarAcceleration();
        void _SetBobberBarAcceleration(float val);

        float _GetDistanceFromCatching();
        void _SetDistanceFromCatching(float val);

        Cue _GetReelSound();
        void _SetReelSound(Cue val);

        Cue _GetUnReelSound();
        void _SetUnReelSound(Cue val);
    }
}