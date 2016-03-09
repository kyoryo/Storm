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

namespace Storm.StardewValley.Accessor
{
    public interface CharacterAccessor
    {
        AnimatedSpriteAccessor _GetSprite();
        void _SetSprite(AnimatedSpriteAccessor val);

        Vector2 _GetPosition();
        void _SetPosition(Vector2 val);

        int _GetSpeed();
        void _SetSpeed(int val);

        int _GetAddedSpeed();
        void _SetAddedSpeed(int val);

        int _GetFacingDirection();
        void _SetFacingDirection(int val);

        int _GetBlockedInterval();
        void _SetBlockedInterval(int val);

        int _GetFaceTowardFarmerRadius();
        void _SetFaceTowardFarmerRadius(int val);

        int _GetFaceTowardFarmerTimer();
        void _SetFaceTowardFarmerTimer(int val);

        int _GetForceUpdateTimer();
        void _SetForceUpdateTimer(int val);

        int _GetMovementPause();
        void _SetMovementPause(int val);

        string _GetName();
        void _SetName(string val);

        bool _GetMoveUp();
        void _SetMoveUp(bool val);

        bool _GetMoveRight();
        void _SetMoveRight(bool val);

        bool _GetMoveDown();
        void _SetMoveDown(bool val);

        bool _GetMoveLeft();
        void _SetMoveLeft(bool val);

        bool _GetFreezeMotion();
        void _SetFreezeMotion(bool val);

        bool _GetIsEmoting();
        void _SetIsEmoting(bool val);

        bool _GetIsCharging();
        void _SetIsCharging(bool val);

        bool _GetWillDestroyObjectsUnderfoot();
        void _SetWillDestroyObjectsUnderfoot(bool val);

        bool _GetIsGlowing();
        void _SetIsGlowing(bool val);

        bool _GetColoredBorder();
        void _SetColoredBorder(bool val);

        bool _GetFlip();
        void _SetFlip(bool val);

        bool _GetDrawOnTop();
        void _SetDrawOnTop(bool val);

        bool _GetFaceTowardFarmer();
        void _SetFaceTowardFarmer(bool val);

        bool _GetFaceAwayFromFarmer();
        void _SetFaceAwayFromFarmer(bool val);

        int _GetCurrentEmote();
        void _SetCurrentEmote(int val);

        int _GetCurrentEmoteFrame();
        void _SetCurrentEmoteFrame(int val);

        int _GetFacingDirectionBeforeSpeakingToPlayer();
        void _SetFacingDirectionBeforeSpeakingToPlayer(int val);

        float _GetEmoteInterval();
        void _SetEmoteInterval(float val);

        float _GetXVelocity();
        void _SetXVelocity(float val);

        float _GetYVelocity();
        void _SetYVelocity(float val);

        Vector2 _GetLastClick();
        void _SetLastClick(Vector2 val);

        Vector2 _GetPositionToLerpTo();
        void _SetPositionToLerpTo(Vector2 val);

        float _GetScale();
        void _SetScale(float val);

        float _GetTimeBeforeAIMovementAgain();
        void _SetTimeBeforeAIMovementAgain(float val);

        float _GetGlowingTransparency();
        void _SetGlowingTransparency(float val);

        float _GetGlowRate();
        void _SetGlowRate(float val);

        bool _GetGlowUp();
        void _SetGlowUp(bool val);

        bool _GetNextEventcommandAfterEmote();
        void _SetNextEventcommandAfterEmote(bool val);

        bool _GetSwimming();
        void _SetSwimming(bool val);

        bool _GetCollidesWithOtherCharacters();
        void _SetCollidesWithOtherCharacters(bool val);

        bool _GetFarmerPassesThrough();
        void _SetFarmerPassesThrough(bool val);

        bool _GetIgnoreMultiplayerUpdates();
        void _SetIgnoreMultiplayerUpdates(bool val);

        bool _GetEventActor();
        void _SetEventActor(bool val);

        bool _GetIgnoreMovementAnimations();
        void _SetIgnoreMovementAnimations(bool val);

        int _GetYJumpOffset();
        void _SetYJumpOffset(int val);

        float _GetYJumpVelocity();
        void _SetYJumpVelocity(float val);

        FarmerAccessor _GetWhoToFace();
        void _SetWhoToFace(FarmerAccessor val);

        Color _GetGlowingColor();
        void _SetGlowingColor(Color val);

        bool _GetEmoteFading();
        void _SetEmoteFading(bool val);

        Rectangle _GetOriginalSourceRect();
        void _SetOriginalSourceRect(Rectangle val);

        Vector2 _GetDrawOffset();
        void _SetDrawOffset(Vector2 val);
    }
}