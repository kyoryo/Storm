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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class BobberBar : ClickableMenu
    {
        public BobberBar(StaticContext parent, BobberBarAccessor accessor) :
            base(parent, accessor)
        {
        }

        public BobberBar()
        {
        }

        public float Difficulty
        {
            get { return Cast<BobberBarAccessor>()._GetDifficulty(); }
            set { Cast<BobberBarAccessor>()._SetDifficulty(value); }
        }

        public int MotionType
        {
            get { return Cast<BobberBarAccessor>()._GetMotionType(); }
            set { Cast<BobberBarAccessor>()._SetMotionType(value); }
        }

        public int WhichFish
        {
            get { return Cast<BobberBarAccessor>()._GetWhichFish(); }
            set { Cast<BobberBarAccessor>()._SetWhichFish(value); }
        }

        public float BobberPosition
        {
            get { return Cast<BobberBarAccessor>()._GetBobberPosition(); }
            set { Cast<BobberBarAccessor>()._SetBobberPosition(value); }
        }

        public float BobberSpeed
        {
            get { return Cast<BobberBarAccessor>()._GetBobberSpeed(); }
            set { Cast<BobberBarAccessor>()._SetBobberSpeed(value); }
        }

        public float BobberAcceleration
        {
            get { return Cast<BobberBarAccessor>()._GetBobberAcceleration(); }
            set { Cast<BobberBarAccessor>()._SetBobberAcceleration(value); }
        }

        public float BobberTargetPosition
        {
            get { return Cast<BobberBarAccessor>()._GetBobberTargetPosition(); }
            set { Cast<BobberBarAccessor>()._SetBobberTargetPosition(value); }
        }

        public float Scale
        {
            get { return Cast<BobberBarAccessor>()._GetScale(); }
            set { Cast<BobberBarAccessor>()._SetScale(value); }
        }

        public float EverythingShakeTimer
        {
            get { return Cast<BobberBarAccessor>()._GetEverythingShakeTimer(); }
            set { Cast<BobberBarAccessor>()._SetEverythingShakeTimer(value); }
        }

        public float FloaterSinkerAcceleration
        {
            get { return Cast<BobberBarAccessor>()._GetFloaterSinkerAcceleration(); }
            set { Cast<BobberBarAccessor>()._SetFloaterSinkerAcceleration(value); }
        }

        public float TreasurePosition
        {
            get { return Cast<BobberBarAccessor>()._GetTreasurePosition(); }
            set { Cast<BobberBarAccessor>()._SetTreasurePosition(value); }
        }

        public float TreasureCatchLevel
        {
            get { return Cast<BobberBarAccessor>()._GetTreasureCatchLevel(); }
            set { Cast<BobberBarAccessor>()._SetTreasureCatchLevel(value); }
        }

        public float TreasureAppearTimer
        {
            get { return Cast<BobberBarAccessor>()._GetTreasureAppearTimer(); }
            set { Cast<BobberBarAccessor>()._SetTreasureAppearTimer(value); }
        }

        public float TreasureScale
        {
            get { return Cast<BobberBarAccessor>()._GetTreasureScale(); }
            set { Cast<BobberBarAccessor>()._SetTreasureScale(value); }
        }

        public bool BobberInBar
        {
            get { return Cast<BobberBarAccessor>()._GetBobberInBar(); }
            set { Cast<BobberBarAccessor>()._SetBobberInBar(value); }
        }

        public bool ButtonPressed
        {
            get { return Cast<BobberBarAccessor>()._GetButtonPressed(); }
            set { Cast<BobberBarAccessor>()._SetButtonPressed(value); }
        }

        public bool FlipBubble
        {
            get { return Cast<BobberBarAccessor>()._GetFlipBubble(); }
            set { Cast<BobberBarAccessor>()._SetFlipBubble(value); }
        }

        public bool FadeIn
        {
            get { return Cast<BobberBarAccessor>()._GetFadeIn(); }
            set { Cast<BobberBarAccessor>()._SetFadeIn(value); }
        }

        public bool FadeOut
        {
            get { return Cast<BobberBarAccessor>()._GetFadeOut(); }
            set { Cast<BobberBarAccessor>()._SetFadeOut(value); }
        }

        public bool Treasure
        {
            get { return Cast<BobberBarAccessor>()._GetTreasure(); }
            set { Cast<BobberBarAccessor>()._SetTreasure(value); }
        }

        public bool TreasureCaught
        {
            get { return Cast<BobberBarAccessor>()._GetTreasureCaught(); }
            set { Cast<BobberBarAccessor>()._SetTreasureCaught(value); }
        }

        public bool Perfect
        {
            get { return Cast<BobberBarAccessor>()._GetPerfect(); }
            set { Cast<BobberBarAccessor>()._SetPerfect(value); }
        }

        public bool BossFish
        {
            get { return Cast<BobberBarAccessor>()._GetBossFish(); }
            set { Cast<BobberBarAccessor>()._SetBossFish(value); }
        }

        public int BobberBarHeight
        {
            get { return Cast<BobberBarAccessor>()._GetBobberBarHeight(); }
            set { Cast<BobberBarAccessor>()._SetBobberBarHeight(value); }
        }

        public int FishSize
        {
            get { return Cast<BobberBarAccessor>()._GetFishSize(); }
            set { Cast<BobberBarAccessor>()._SetFishSize(value); }
        }

        public int FishQuality
        {
            get { return Cast<BobberBarAccessor>()._GetFishQuality(); }
            set { Cast<BobberBarAccessor>()._SetFishQuality(value); }
        }

        public int MinFishSize
        {
            get { return Cast<BobberBarAccessor>()._GetMinFishSize(); }
            set { Cast<BobberBarAccessor>()._SetMinFishSize(value); }
        }

        public int MaxFishSize
        {
            get { return Cast<BobberBarAccessor>()._GetMaxFishSize(); }
            set { Cast<BobberBarAccessor>()._SetMaxFishSize(value); }
        }

        public int FishSizeReductionTimer
        {
            get { return Cast<BobberBarAccessor>()._GetFishSizeReductionTimer(); }
            set { Cast<BobberBarAccessor>()._SetFishSizeReductionTimer(value); }
        }

        public int WhichBobber
        {
            get { return Cast<BobberBarAccessor>()._GetWhichBobber(); }
            set { Cast<BobberBarAccessor>()._SetWhichBobber(value); }
        }

        public Vector2 BarShake
        {
            get { return Cast<BobberBarAccessor>()._GetBarShake(); }
            set { Cast<BobberBarAccessor>()._SetBarShake(value); }
        }

        public Vector2 FishShake
        {
            get { return Cast<BobberBarAccessor>()._GetFishShake(); }
            set { Cast<BobberBarAccessor>()._SetFishShake(value); }
        }

        public Vector2 EverythingShake
        {
            get { return Cast<BobberBarAccessor>()._GetEverythingShake(); }
            set { Cast<BobberBarAccessor>()._SetEverythingShake(value); }
        }

        public Vector2 TreasureShake
        {
            get { return Cast<BobberBarAccessor>()._GetTreasureShake(); }
            set { Cast<BobberBarAccessor>()._SetTreasureShake(value); }
        }

        public float ReelRotation
        {
            get { return Cast<BobberBarAccessor>()._GetReelRotation(); }
            set { Cast<BobberBarAccessor>()._SetReelRotation(value); }
        }

        public float BobberBarPos
        {
            get { return Cast<BobberBarAccessor>()._GetBobberBarPos(); }
            set { Cast<BobberBarAccessor>()._SetBobberBarPos(value); }
        }

        public float BobberBarSpeed
        {
            get { return Cast<BobberBarAccessor>()._GetBobberBarSpeed(); }
            set { Cast<BobberBarAccessor>()._SetBobberBarSpeed(value); }
        }

        public float BobberBarAcceleration
        {
            get { return Cast<BobberBarAccessor>()._GetBobberBarAcceleration(); }
            set { Cast<BobberBarAccessor>()._SetBobberBarAcceleration(value); }
        }

        public float DistanceFromCatching
        {
            get { return Cast<BobberBarAccessor>()._GetDistanceFromCatching(); }
            set { Cast<BobberBarAccessor>()._SetDistanceFromCatching(value); }
        }

        public Cue ReelSound
        {
            get { return Cast<BobberBarAccessor>()._GetReelSound(); }
            set { Cast<BobberBarAccessor>()._SetReelSound(value); }
        }

        public Cue UnReelSound
        {
            get { return Cast<BobberBarAccessor>()._GetUnReelSound(); }
            set { Cast<BobberBarAccessor>()._SetUnReelSound(value); }
        }
    }
}