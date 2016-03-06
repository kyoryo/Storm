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
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface NPCAccessor : CharacterAccessor
    {
        IDictionary _GetSchedule();
        void _SetSchedule(IDictionary val);

        IDictionary _GetDialogue();
        void _SetDialogue(IDictionary val);

        int _GetDirectionIndex();
        void _SetDirectionIndex(int val);

        int _GetLengthOfWalkingSquareX();
        void _SetLengthOfWalkingSquareX(int val);

        int _GetLengthOfWalkingSquareY();
        void _SetLengthOfWalkingSquareY(int val);

        int _GetSquarePauseAccumulation();
        void _SetSquarePauseAccumulation(int val);

        int _GetSquarePauseTotal();
        void _SetSquarePauseTotal(int val);

        int _GetSquarePauseOffset();
        void _SetSquarePauseOffset(int val);

        Rectangle _GetLastCrossroad();
        void _SetLastCrossroad(Rectangle val);

        string _GetDefaultMap();
        void _SetDefaultMap(string val);

        string _GetLoveInterest();
        void _SetLoveInterest(string val);

        string _GetBirthdaySeason();
        void _SetBirthdaySeason(string val);

        Texture2D _GetPortrait();
        void _SetPortrait(Texture2D val);

        Vector2 _GetDefaultPosition();
        void _SetDefaultPosition(Vector2 val);

        Vector2 _GetNextSquarePosition();
        void _SetNextSquarePosition(Vector2 val);

        int _GetDefaultFacingDirection();
        void _SetDefaultFacingDirection(int val);

        int _GetIdForClones();
        void _SetIdForClones(int val);

        int _GetShakeTimer();
        void _SetShakeTimer(int val);

        bool _GetIsWalkingInSquare();
        void _SetIsWalkingInSquare(bool val);

        bool _GetIsWalkingTowardPlayer();
        void _SetIsWalkingTowardPlayer(bool val);

        Stack _GetCurrentDialogue();
        void _SetCurrentDialogue(Stack val);

        IList _GetRoutesFromLocationToLocation();
        void _SetRoutesFromLocationToLocation(IList val);

        string _GetTextAboveHead();
        void _SetTextAboveHead(string val);

        int _GetTextAboveHeadPreTimer();
        void _SetTextAboveHeadPreTimer(int val);

        int _GetTextAboveHeadTimer();
        void _SetTextAboveHeadTimer(int val);

        int _GetTextAboveHeadStyle();
        void _SetTextAboveHeadStyle(int val);

        int _GetTextAboveHeadColor();
        void _SetTextAboveHeadColor(int val);

        float _GetTextAboveHeadAlpha();
        void _SetTextAboveHeadAlpha(float val);

        int _GetAge();
        void _SetAge(int val);

        int _GetManners();
        void _SetManners(int val);

        int _GetSocialAnxiety();
        void _SetSocialAnxiety(int val);

        int _GetOptimism();
        void _SetOptimism(int val);

        int _GetGender();
        void _SetGender(int val);

        int _GetId();
        void _SetId(int val);

        int _GetHomeRegion();
        void _SetHomeRegion(int val);

        int _GetDaysUntilBirthing();
        void _SetDaysUntilBirthing(int val);

        int _GetDaysAfterLastBirth();
        void _SetDaysAfterLastBirth(int val);

        int _GetBirthdayDay();
        void _SetBirthdayDay(int val);

        string _GetExtraDialogueMessageToAddThisMorning();
        void _SetExtraDialogueMessageToAddThisMorning(string val);

        GameLocationAccessor _GetCurrentLocation();
        void _SetCurrentLocation(GameLocationAccessor val);

        bool _GetUpdatedDialogueYet();
        void _SetUpdatedDialogueYet(bool val);

        bool _GetUniqueSpriteActive();
        void _SetUniqueSpriteActive(bool val);

        bool _GetUniquePortraitActive();
        void _SetUniquePortraitActive(bool val);

        bool _GetBreather();
        void _SetBreather(bool val);

        bool _GetHideShadow();
        void _SetHideShadow(bool val);

        bool _GetHasPartnerForDance();
        void _SetHasPartnerForDance(bool val);

        bool _GetImmediateSpeak();
        void _SetImmediateSpeak(bool val);

        bool _GetIgnoreScheduleToday();
        void _SetIgnoreScheduleToday(bool val);

        int _GetMoveTowardPlayerThreshold();
        void _SetMoveTowardPlayerThreshold(int val);

        float _GetRotation();
        void _SetRotation(float val);

        float _GetYOffset();
        void _SetYOffset(float val);

        float _GetSwimTimer();
        void _SetSwimTimer(float val);

        float _GetTimerSinceLastMovement();
        void _SetTimerSinceLastMovement(float val);

        string _GetMapBeforeEvent();
        void _SetMapBeforeEvent(string val);

        Vector2 _GetPositionBeforeEvent();
        void _SetPositionBeforeEvent(Vector2 val);

        Vector2 _GetLastPosition();
        void _SetLastPosition(Vector2 val);

        bool _GetIsInvisible();
        void _SetIsInvisible(bool val);

        bool _GetFollowSchedule();
        void _SetFollowSchedule(bool val);

        bool _GetDatable();
        void _SetDatable(bool val);

        bool _GetDatingFarmer();
        void _SetDatingFarmer(bool val);

        bool _GetHasBeenKissedToday();
        void _SetHasBeenKissedToday(bool val);

        bool _GetDoingEndOfRouteAnimation();
        void _SetDoingEndOfRouteAnimation(bool val);

        bool _GetGoingToDoEndOfRouteAnimation();
        void _SetGoingToDoEndOfRouteAnimation(bool val);

        int _GetRouteEndIntro();
        void _SetRouteEndIntro(int val);

        int _GetRouteEndAnimation();
        void _SetRouteEndAnimation(int val);

        int _GetRouteEndOutro();
        void _SetRouteEndOutro(int val);

        string _GetEndOfRouteMessage();
        void _SetEndOfRouteMessage(string val);

        string _GetNextEndOfRouteMessage();
        void _SetNextEndOfRouteMessage(string val);

        string _GetEndOfRouteBehaviorName();
        void _SetEndOfRouteBehaviorName(string val);

        Point _GetPreviousEndPoint();
        void _SetPreviousEndPoint(Point val);

        int _GetScheduleTimeToTry();
        void _SetScheduleTimeToTry(int val);

        int _GetSquareMovementFacingPreference();
        void _SetSquareMovementFacingPreference(int val);

        bool _GetReturningToEndPoint();
        void _SetReturningToEndPoint(bool val);

        bool _GetHasSaidAfternoonDialogue();
        void _SetHasSaidAfternoonDialogue(bool val);

        int _GetMarried();
        void _SetMarried(int val);

        int _GetDaysMarried();
        void _SetDaysMarried(int val);
    }
}