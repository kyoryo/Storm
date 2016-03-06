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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class NPC : Character, Wrapper<NPCAccessor>
    {
        private readonly NPCAccessor accessor;

        public NPC(StaticContext parent, NPCAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int DirectionIndex
        {
            get { return accessor._GetDirectionIndex(); }
            set { accessor._SetDirectionIndex(value); }
        }

        public int LengthOfWalkingSquareX
        {
            get { return accessor._GetLengthOfWalkingSquareX(); }
            set { accessor._SetLengthOfWalkingSquareX(value); }
        }

        public int LengthOfWalkingSquareY
        {
            get { return accessor._GetLengthOfWalkingSquareY(); }
            set { accessor._SetLengthOfWalkingSquareY(value); }
        }

        public int SquarePauseAccumulation
        {
            get { return accessor._GetSquarePauseAccumulation(); }
            set { accessor._SetSquarePauseAccumulation(value); }
        }

        public int SquarePauseTotal
        {
            get { return accessor._GetSquarePauseTotal(); }
            set { accessor._SetSquarePauseTotal(value); }
        }

        public int SquarePauseOffset
        {
            get { return accessor._GetSquarePauseOffset(); }
            set { accessor._SetSquarePauseOffset(value); }
        }

        public Rectangle LastCrossroad
        {
            get { return accessor._GetLastCrossroad(); }
            set { accessor._SetLastCrossroad(value); }
        }

        public string DefaultMap
        {
            get { return accessor._GetDefaultMap(); }
            set { accessor._SetDefaultMap(value); }
        }

        public string LoveInterest
        {
            get { return accessor._GetLoveInterest(); }
            set { accessor._SetLoveInterest(value); }
        }

        public string BirthdaySeason
        {
            get { return accessor._GetBirthdaySeason(); }
            set { accessor._SetBirthdaySeason(value); }
        }

        public Texture2D Portrait
        {
            get { return accessor._GetPortrait(); }
            set { accessor._SetPortrait(value); }
        }

        public Vector2 DefaultPosition
        {
            get { return accessor._GetDefaultPosition(); }
            set { accessor._SetDefaultPosition(value); }
        }

        public Vector2 NextSquarePosition
        {
            get { return accessor._GetNextSquarePosition(); }
            set { accessor._SetNextSquarePosition(value); }
        }

        public int DefaultFacingDirection
        {
            get { return accessor._GetDefaultFacingDirection(); }
            set { accessor._SetDefaultFacingDirection(value); }
        }

        public int IdForClones
        {
            get { return accessor._GetIdForClones(); }
            set { accessor._SetIdForClones(value); }
        }

        public int ShakeTimer
        {
            get { return accessor._GetShakeTimer(); }
            set { accessor._SetShakeTimer(value); }
        }

        public bool IsWalkingInSquare
        {
            get { return accessor._GetIsWalkingInSquare(); }
            set { accessor._SetIsWalkingInSquare(value); }
        }

        public bool IsWalkingTowardPlayer
        {
            get { return accessor._GetIsWalkingTowardPlayer(); }
            set { accessor._SetIsWalkingTowardPlayer(value); }
        }

        public Stack CurrentDialogue
        {
            get { return accessor._GetCurrentDialogue(); }
            set { accessor._SetCurrentDialogue(value); }
        }

        public string TextAboveHead
        {
            get { return accessor._GetTextAboveHead(); }
            set { accessor._SetTextAboveHead(value); }
        }

        public int TextAboveHeadPreTimer
        {
            get { return accessor._GetTextAboveHeadPreTimer(); }
            set { accessor._SetTextAboveHeadPreTimer(value); }
        }

        public int TextAboveHeadTimer
        {
            get { return accessor._GetTextAboveHeadTimer(); }
            set { accessor._SetTextAboveHeadTimer(value); }
        }

        public int TextAboveHeadStyle
        {
            get { return accessor._GetTextAboveHeadStyle(); }
            set { accessor._SetTextAboveHeadStyle(value); }
        }

        public int TextAboveHeadColor
        {
            get { return accessor._GetTextAboveHeadColor(); }
            set { accessor._SetTextAboveHeadColor(value); }
        }

        public float TextAboveHeadAlpha
        {
            get { return accessor._GetTextAboveHeadAlpha(); }
            set { accessor._SetTextAboveHeadAlpha(value); }
        }

        public int Age
        {
            get { return accessor._GetAge(); }
            set { accessor._SetAge(value); }
        }

        public int Manners
        {
            get { return accessor._GetManners(); }
            set { accessor._SetManners(value); }
        }

        public int SocialAnxiety
        {
            get { return accessor._GetSocialAnxiety(); }
            set { accessor._SetSocialAnxiety(value); }
        }

        public int Optimism
        {
            get { return accessor._GetOptimism(); }
            set { accessor._SetOptimism(value); }
        }

        public int Gender
        {
            get { return accessor._GetGender(); }
            set { accessor._SetGender(value); }
        }

        public int Id
        {
            get { return accessor._GetId(); }
            set { accessor._SetId(value); }
        }

        public int HomeRegion
        {
            get { return accessor._GetHomeRegion(); }
            set { accessor._SetHomeRegion(value); }
        }

        public int DaysUntilBirthing
        {
            get { return accessor._GetDaysUntilBirthing(); }
            set { accessor._SetDaysUntilBirthing(value); }
        }

        public int DaysAfterLastBirth
        {
            get { return accessor._GetDaysAfterLastBirth(); }
            set { accessor._SetDaysAfterLastBirth(value); }
        }

        public int BirthdayDay
        {
            get { return accessor._GetBirthdayDay(); }
            set { accessor._SetBirthdayDay(value); }
        }

        public string ExtraDialogueMessageToAddThisMorning
        {
            get { return accessor._GetExtraDialogueMessageToAddThisMorning(); }
            set { accessor._SetExtraDialogueMessageToAddThisMorning(value); }
        }

        public GameLocation CurrentLocation
        {
            get { return new GameLocation(Parent, accessor._GetCurrentLocation()); }
            set { accessor._SetCurrentLocation(value.Expose()); }
        }

        public bool UpdatedDialogueYet
        {
            get { return accessor._GetUpdatedDialogueYet(); }
            set { accessor._SetUpdatedDialogueYet(value); }
        }

        public bool UniqueSpriteActive
        {
            get { return accessor._GetUniqueSpriteActive(); }
            set { accessor._SetUniqueSpriteActive(value); }
        }

        public bool UniquePortraitActive
        {
            get { return accessor._GetUniquePortraitActive(); }
            set { accessor._SetUniquePortraitActive(value); }
        }

        public bool Breather
        {
            get { return accessor._GetBreather(); }
            set { accessor._SetBreather(value); }
        }

        public bool HideShadow
        {
            get { return accessor._GetHideShadow(); }
            set { accessor._SetHideShadow(value); }
        }

        public bool HasPartnerForDance
        {
            get { return accessor._GetHasPartnerForDance(); }
            set { accessor._SetHasPartnerForDance(value); }
        }

        public bool ImmediateSpeak
        {
            get { return accessor._GetImmediateSpeak(); }
            set { accessor._SetImmediateSpeak(value); }
        }

        public bool IgnoreScheduleToday
        {
            get { return accessor._GetIgnoreScheduleToday(); }
            set { accessor._SetIgnoreScheduleToday(value); }
        }

        public int MoveTowardPlayerThreshold
        {
            get { return accessor._GetMoveTowardPlayerThreshold(); }
            set { accessor._SetMoveTowardPlayerThreshold(value); }
        }

        public float Rotation
        {
            get { return accessor._GetRotation(); }
            set { accessor._SetRotation(value); }
        }

        public float YOffset
        {
            get { return accessor._GetYOffset(); }
            set { accessor._SetYOffset(value); }
        }

        public float SwimTimer
        {
            get { return accessor._GetSwimTimer(); }
            set { accessor._SetSwimTimer(value); }
        }

        public float TimerSinceLastMovement
        {
            get { return accessor._GetTimerSinceLastMovement(); }
            set { accessor._SetTimerSinceLastMovement(value); }
        }

        public string MapBeforeEvent
        {
            get { return accessor._GetMapBeforeEvent(); }
            set { accessor._SetMapBeforeEvent(value); }
        }

        public Vector2 PositionBeforeEvent
        {
            get { return accessor._GetPositionBeforeEvent(); }
            set { accessor._SetPositionBeforeEvent(value); }
        }

        public Vector2 LastPosition
        {
            get { return accessor._GetLastPosition(); }
            set { accessor._SetLastPosition(value); }
        }

        public bool IsInvisible
        {
            get { return accessor._GetIsInvisible(); }
            set { accessor._SetIsInvisible(value); }
        }

        public bool FollowSchedule
        {
            get { return accessor._GetFollowSchedule(); }
            set { accessor._SetFollowSchedule(value); }
        }

        public bool Datable
        {
            get { return accessor._GetDatable(); }
            set { accessor._SetDatable(value); }
        }

        public bool DatingFarmer
        {
            get { return accessor._GetDatingFarmer(); }
            set { accessor._SetDatingFarmer(value); }
        }

        public bool HasBeenKissedToday
        {
            get { return accessor._GetHasBeenKissedToday(); }
            set { accessor._SetHasBeenKissedToday(value); }
        }

        public bool DoingEndOfRouteAnimation
        {
            get { return accessor._GetDoingEndOfRouteAnimation(); }
            set { accessor._SetDoingEndOfRouteAnimation(value); }
        }

        public bool GoingToDoEndOfRouteAnimation
        {
            get { return accessor._GetGoingToDoEndOfRouteAnimation(); }
            set { accessor._SetGoingToDoEndOfRouteAnimation(value); }
        }

        public int RouteEndIntro
        {
            get { return accessor._GetRouteEndIntro(); }
            set { accessor._SetRouteEndIntro(value); }
        }

        public int RouteEndAnimation
        {
            get { return accessor._GetRouteEndAnimation(); }
            set { accessor._SetRouteEndAnimation(value); }
        }

        public int RouteEndOutro
        {
            get { return accessor._GetRouteEndOutro(); }
            set { accessor._SetRouteEndOutro(value); }
        }

        public string EndOfRouteMessage
        {
            get { return accessor._GetEndOfRouteMessage(); }
            set { accessor._SetEndOfRouteMessage(value); }
        }

        public string NextEndOfRouteMessage
        {
            get { return accessor._GetNextEndOfRouteMessage(); }
            set { accessor._SetNextEndOfRouteMessage(value); }
        }

        public string EndOfRouteBehaviorName
        {
            get { return accessor._GetEndOfRouteBehaviorName(); }
            set { accessor._SetEndOfRouteBehaviorName(value); }
        }

        public Point PreviousEndPoint
        {
            get { return accessor._GetPreviousEndPoint(); }
            set { accessor._SetPreviousEndPoint(value); }
        }

        public int ScheduleTimeToTry
        {
            get { return accessor._GetScheduleTimeToTry(); }
            set { accessor._SetScheduleTimeToTry(value); }
        }

        public int SquareMovementFacingPreference
        {
            get { return accessor._GetSquareMovementFacingPreference(); }
            set { accessor._SetSquareMovementFacingPreference(value); }
        }

        public bool ReturningToEndPoint
        {
            get { return accessor._GetReturningToEndPoint(); }
            set { accessor._SetReturningToEndPoint(value); }
        }

        public bool HasSaidAfternoonDialogue
        {
            get { return accessor._GetHasSaidAfternoonDialogue(); }
            set { accessor._SetHasSaidAfternoonDialogue(value); }
        }

        public int Married
        {
            get { return accessor._GetMarried(); }
            set { accessor._SetMarried(value); }
        }

        public int DaysMarried
        {
            get { return accessor._GetDaysMarried(); }
            set { accessor._SetDaysMarried(value); }
        }

        public new NPCAccessor Expose() => accessor;
    }
}