using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class BobberBar : Wrapper<BobberBarAccessor>
    {
        private StaticContext Parent { get; }
        private BobberBarAccessor accessor;

        public BobberBar(StaticContext parent, BobberBarAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public float Difficulty
        {
            get { return accessor._GetDifficulty(); }
            set { accessor._SetDifficulty(value); }
        }

        public int MotionType
        {
            get { return accessor._GetMotionType(); }
            set { accessor._SetMotionType(value); }
        }

        public int WhichFish
        {
            get { return accessor._GetWhichFish(); }
            set { accessor._SetWhichFish(value); }
        }

        public float BobberPosition
        {
            get { return accessor._GetBobberPosition(); }
            set { accessor._SetBobberPosition(value); }
        }

        public float BobberSpeed
        {
            get { return accessor._GetBobberSpeed(); }
            set { accessor._SetBobberSpeed(value); }
        }

        public float BobberAcceleration
        {
            get { return accessor._GetBobberAcceleration(); }
            set { accessor._SetBobberAcceleration(value); }
        }

        public float BobberTargetPosition
        {
            get { return accessor._GetBobberTargetPosition(); }
            set { accessor._SetBobberTargetPosition(value); }
        }

        public float Scale
        {
            get { return accessor._GetScale(); }
            set { accessor._SetScale(value); }
        }

        public float EverythingShakeTimer
        {
            get { return accessor._GetEverythingShakeTimer(); }
            set { accessor._SetEverythingShakeTimer(value); }
        }

        public float FloaterSinkerAcceleration
        {
            get { return accessor._GetFloaterSinkerAcceleration(); }
            set { accessor._SetFloaterSinkerAcceleration(value); }
        }

        public float TreasurePosition
        {
            get { return accessor._GetTreasurePosition(); }
            set { accessor._SetTreasurePosition(value); }
        }

        public float TreasureCatchLevel
        {
            get { return accessor._GetTreasureCatchLevel(); }
            set { accessor._SetTreasureCatchLevel(value); }
        }

        public float TreasureAppearTimer
        {
            get { return accessor._GetTreasureAppearTimer(); }
            set { accessor._SetTreasureAppearTimer(value); }
        }

        public float TreasureScale
        {
            get { return accessor._GetTreasureScale(); }
            set { accessor._SetTreasureScale(value); }
        }

        public bool BobberInBar
        {
            get { return accessor._GetBobberInBar(); }
            set { accessor._SetBobberInBar(value); }
        }

        public bool ButtonPressed
        {
            get { return accessor._GetButtonPressed(); }
            set { accessor._SetButtonPressed(value); }
        }

        public bool FlipBubble
        {
            get { return accessor._GetFlipBubble(); }
            set { accessor._SetFlipBubble(value); }
        }

        public bool FadeIn
        {
            get { return accessor._GetFadeIn(); }
            set { accessor._SetFadeIn(value); }
        }

        public bool FadeOut
        {
            get { return accessor._GetFadeOut(); }
            set { accessor._SetFadeOut(value); }
        }

        public bool Treasure
        {
            get { return accessor._GetTreasure(); }
            set { accessor._SetTreasure(value); }
        }

        public bool TreasureCaught
        {
            get { return accessor._GetTreasureCaught(); }
            set { accessor._SetTreasureCaught(value); }
        }

        public bool Perfect
        {
            get { return accessor._GetPerfect(); }
            set { accessor._SetPerfect(value); }
        }

        public bool BossFish
        {
            get { return accessor._GetBossFish(); }
            set { accessor._SetBossFish(value); }
        }

        public int BobberBarHeight
        {
            get { return accessor._GetBobberBarHeight(); }
            set { accessor._SetBobberBarHeight(value); }
        }

        public int FishSize
        {
            get { return accessor._GetFishSize(); }
            set { accessor._SetFishSize(value); }
        }

        public int FishQuality
        {
            get { return accessor._GetFishQuality(); }
            set { accessor._SetFishQuality(value); }
        }

        public int MinFishSize
        {
            get { return accessor._GetMinFishSize(); }
            set { accessor._SetMinFishSize(value); }
        }

        public int MaxFishSize
        {
            get { return accessor._GetMaxFishSize(); }
            set { accessor._SetMaxFishSize(value); }
        }

        public int FishSizeReductionTimer
        {
            get { return accessor._GetFishSizeReductionTimer(); }
            set { accessor._SetFishSizeReductionTimer(value); }
        }

        public int WhichBobber
        {
            get { return accessor._GetWhichBobber(); }
            set { accessor._SetWhichBobber(value); }
        }

        public Vector2 BarShake
        {
            get { return accessor._GetBarShake(); }
            set { accessor._SetBarShake(value); }
        }

        public Vector2 FishShake
        {
            get { return accessor._GetFishShake(); }
            set { accessor._SetFishShake(value); }
        }

        public Vector2 EverythingShake
        {
            get { return accessor._GetEverythingShake(); }
            set { accessor._SetEverythingShake(value); }
        }

        public Vector2 TreasureShake
        {
            get { return accessor._GetTreasureShake(); }
            set { accessor._SetTreasureShake(value); }
        }

        public float ReelRotation
        {
            get { return accessor._GetReelRotation(); }
            set { accessor._SetReelRotation(value); }
        }

        public float BobberBarPos
        {
            get { return accessor._GetBobberBarPos(); }
            set { accessor._SetBobberBarPos(value); }
        }

        public float BobberBarSpeed
        {
            get { return accessor._GetBobberBarSpeed(); }
            set { accessor._SetBobberBarSpeed(value); }
        }

        public float BobberBarAcceleration
        {
            get { return accessor._GetBobberBarAcceleration(); }
            set { accessor._SetBobberBarAcceleration(value); }
        }

        public float DistanceFromCatching
        {
            get { return accessor._GetDistanceFromCatching(); }
            set { accessor._SetDistanceFromCatching(value); }
        }

        public Cue ReelSound
        {
            get { return accessor._GetReelSound(); }
            set { accessor._SetReelSound(value); }
        }

        public Cue UnReelSound
        {
            get { return accessor._GetUnReelSound(); }
            set { accessor._SetUnReelSound(value); }
        }

        public BobberBarAccessor Expose() => accessor;
    }
}
