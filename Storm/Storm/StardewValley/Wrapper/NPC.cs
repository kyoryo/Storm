/*
    Copyright 2016 Inari-Whitebear

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
    public class NPC : Character
    {
        public NPC(StaticContext parent, NPCAccessor accessor) :
            base(parent, accessor)
        {
        }

        public NPC()
        {
        }

        public int DirectionIndex
        {
            get { return Cast<NPCAccessor>()._GetDirectionIndex(); }
            set { Cast<NPCAccessor>()._SetDirectionIndex(value); }
        }

        public int LengthOfWalkingSquareX
        {
            get { return Cast<NPCAccessor>()._GetLengthOfWalkingSquareX(); }
            set { Cast<NPCAccessor>()._SetLengthOfWalkingSquareX(value); }
        }

        public int LengthOfWalkingSquareY
        {
            get { return Cast<NPCAccessor>()._GetLengthOfWalkingSquareY(); }
            set { Cast<NPCAccessor>()._SetLengthOfWalkingSquareY(value); }
        }

        public int SquarePauseAccumulation
        {
            get { return Cast<NPCAccessor>()._GetSquarePauseAccumulation(); }
            set { Cast<NPCAccessor>()._SetSquarePauseAccumulation(value); }
        }

        public int SquarePauseTotal
        {
            get { return Cast<NPCAccessor>()._GetSquarePauseTotal(); }
            set { Cast<NPCAccessor>()._SetSquarePauseTotal(value); }
        }

        public int SquarePauseOffset
        {
            get { return Cast<NPCAccessor>()._GetSquarePauseOffset(); }
            set { Cast<NPCAccessor>()._SetSquarePauseOffset(value); }
        }

        public Rectangle LastCrossroad
        {
            get { return Cast<NPCAccessor>()._GetLastCrossroad(); }
            set { Cast<NPCAccessor>()._SetLastCrossroad(value); }
        }

        public string DefaultMap
        {
            get { return Cast<NPCAccessor>()._GetDefaultMap(); }
            set { Cast<NPCAccessor>()._SetDefaultMap(value); }
        }

        public string LoveInterest
        {
            get { return Cast<NPCAccessor>()._GetLoveInterest(); }
            set { Cast<NPCAccessor>()._SetLoveInterest(value); }
        }

        public string BirthdaySeason
        {
            get { return Cast<NPCAccessor>()._GetBirthdaySeason(); }
            set { Cast<NPCAccessor>()._SetBirthdaySeason(value); }
        }

        public Texture2D Portrait
        {
            get { return Cast<NPCAccessor>()._GetPortrait(); }
            set { Cast<NPCAccessor>()._SetPortrait(value); }
        }

        public Vector2 DefaultPosition
        {
            get { return Cast<NPCAccessor>()._GetDefaultPosition(); }
            set { Cast<NPCAccessor>()._SetDefaultPosition(value); }
        }

        public Vector2 NextSquarePosition
        {
            get { return Cast<NPCAccessor>()._GetNextSquarePosition(); }
            set { Cast<NPCAccessor>()._SetNextSquarePosition(value); }
        }

        public int DefaultFacingDirection
        {
            get { return Cast<NPCAccessor>()._GetDefaultFacingDirection(); }
            set { Cast<NPCAccessor>()._SetDefaultFacingDirection(value); }
        }

        public int IdForClones
        {
            get { return Cast<NPCAccessor>()._GetIdForClones(); }
            set { Cast<NPCAccessor>()._SetIdForClones(value); }
        }

        public int ShakeTimer
        {
            get { return Cast<NPCAccessor>()._GetShakeTimer(); }
            set { Cast<NPCAccessor>()._SetShakeTimer(value); }
        }

        public bool IsWalkingInSquare
        {
            get { return Cast<NPCAccessor>()._GetIsWalkingInSquare(); }
            set { Cast<NPCAccessor>()._SetIsWalkingInSquare(value); }
        }

        public bool IsWalkingTowardPlayer
        {
            get { return Cast<NPCAccessor>()._GetIsWalkingTowardPlayer(); }
            set { Cast<NPCAccessor>()._SetIsWalkingTowardPlayer(value); }
        }

        public Stack CurrentDialogue
        {
            get { return Cast<NPCAccessor>()._GetCurrentDialogue(); }
            set { Cast<NPCAccessor>()._SetCurrentDialogue(value); }
        }

        public string TextAboveHead
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHead(); }
            set { Cast<NPCAccessor>()._SetTextAboveHead(value); }
        }

        public int TextAboveHeadPreTimer
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHeadPreTimer(); }
            set { Cast<NPCAccessor>()._SetTextAboveHeadPreTimer(value); }
        }

        public int TextAboveHeadTimer
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHeadTimer(); }
            set { Cast<NPCAccessor>()._SetTextAboveHeadTimer(value); }
        }

        public int TextAboveHeadStyle
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHeadStyle(); }
            set { Cast<NPCAccessor>()._SetTextAboveHeadStyle(value); }
        }

        public int TextAboveHeadColor
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHeadColor(); }
            set { Cast<NPCAccessor>()._SetTextAboveHeadColor(value); }
        }

        public float TextAboveHeadAlpha
        {
            get { return Cast<NPCAccessor>()._GetTextAboveHeadAlpha(); }
            set { Cast<NPCAccessor>()._SetTextAboveHeadAlpha(value); }
        }

        public int Age
        {
            get { return Cast<NPCAccessor>()._GetAge(); }
            set { Cast<NPCAccessor>()._SetAge(value); }
        }

        public int Manners
        {
            get { return Cast<NPCAccessor>()._GetManners(); }
            set { Cast<NPCAccessor>()._SetManners(value); }
        }

        public int SocialAnxiety
        {
            get { return Cast<NPCAccessor>()._GetSocialAnxiety(); }
            set { Cast<NPCAccessor>()._SetSocialAnxiety(value); }
        }

        public int Optimism
        {
            get { return Cast<NPCAccessor>()._GetOptimism(); }
            set { Cast<NPCAccessor>()._SetOptimism(value); }
        }

        public int Gender
        {
            get { return Cast<NPCAccessor>()._GetGender(); }
            set { Cast<NPCAccessor>()._SetGender(value); }
        }

        public int Id
        {
            get { return Cast<NPCAccessor>()._GetId(); }
            set { Cast<NPCAccessor>()._SetId(value); }
        }

        public int HomeRegion
        {
            get { return Cast<NPCAccessor>()._GetHomeRegion(); }
            set { Cast<NPCAccessor>()._SetHomeRegion(value); }
        }

        public int DaysUntilBirthing
        {
            get { return Cast<NPCAccessor>()._GetDaysUntilBirthing(); }
            set { Cast<NPCAccessor>()._SetDaysUntilBirthing(value); }
        }

        public int DaysAfterLastBirth
        {
            get { return Cast<NPCAccessor>()._GetDaysAfterLastBirth(); }
            set { Cast<NPCAccessor>()._SetDaysAfterLastBirth(value); }
        }

        public int BirthdayDay
        {
            get { return Cast<NPCAccessor>()._GetBirthdayDay(); }
            set { Cast<NPCAccessor>()._SetBirthdayDay(value); }
        }

        public string ExtraDialogueMessageToAddThisMorning
        {
            get { return Cast<NPCAccessor>()._GetExtraDialogueMessageToAddThisMorning(); }
            set { Cast<NPCAccessor>()._SetExtraDialogueMessageToAddThisMorning(value); }
        }

        public GameLocation CurrentLocation
        {
            get
            {
                var tmp = Cast<NPCAccessor>()._GetCurrentLocation();
                if (tmp == null) return null;
                return new GameLocation(Parent, tmp);
            }
            set { Cast<NPCAccessor>()._SetCurrentLocation(value?.Cast<GameLocationAccessor>()); }
        }

        public bool UpdatedDialogueYet
        {
            get { return Cast<NPCAccessor>()._GetUpdatedDialogueYet(); }
            set { Cast<NPCAccessor>()._SetUpdatedDialogueYet(value); }
        }

        public bool UniqueSpriteActive
        {
            get { return Cast<NPCAccessor>()._GetUniqueSpriteActive(); }
            set { Cast<NPCAccessor>()._SetUniqueSpriteActive(value); }
        }

        public bool UniquePortraitActive
        {
            get { return Cast<NPCAccessor>()._GetUniquePortraitActive(); }
            set { Cast<NPCAccessor>()._SetUniquePortraitActive(value); }
        }

        public bool Breather
        {
            get { return Cast<NPCAccessor>()._GetBreather(); }
            set { Cast<NPCAccessor>()._SetBreather(value); }
        }

        public bool HideShadow
        {
            get { return Cast<NPCAccessor>()._GetHideShadow(); }
            set { Cast<NPCAccessor>()._SetHideShadow(value); }
        }

        public bool HasPartnerForDance
        {
            get { return Cast<NPCAccessor>()._GetHasPartnerForDance(); }
            set { Cast<NPCAccessor>()._SetHasPartnerForDance(value); }
        }

        public bool ImmediateSpeak
        {
            get { return Cast<NPCAccessor>()._GetImmediateSpeak(); }
            set { Cast<NPCAccessor>()._SetImmediateSpeak(value); }
        }

        public bool IgnoreScheduleToday
        {
            get { return Cast<NPCAccessor>()._GetIgnoreScheduleToday(); }
            set { Cast<NPCAccessor>()._SetIgnoreScheduleToday(value); }
        }

        public int MoveTowardPlayerThreshold
        {
            get { return Cast<NPCAccessor>()._GetMoveTowardPlayerThreshold(); }
            set { Cast<NPCAccessor>()._SetMoveTowardPlayerThreshold(value); }
        }

        public float Rotation
        {
            get { return Cast<NPCAccessor>()._GetRotation(); }
            set { Cast<NPCAccessor>()._SetRotation(value); }
        }

        public float YOffset
        {
            get { return Cast<NPCAccessor>()._GetYOffset(); }
            set { Cast<NPCAccessor>()._SetYOffset(value); }
        }

        public float SwimTimer
        {
            get { return Cast<NPCAccessor>()._GetSwimTimer(); }
            set { Cast<NPCAccessor>()._SetSwimTimer(value); }
        }

        public float TimerSinceLastMovement
        {
            get { return Cast<NPCAccessor>()._GetTimerSinceLastMovement(); }
            set { Cast<NPCAccessor>()._SetTimerSinceLastMovement(value); }
        }

        public string MapBeforeEvent
        {
            get { return Cast<NPCAccessor>()._GetMapBeforeEvent(); }
            set { Cast<NPCAccessor>()._SetMapBeforeEvent(value); }
        }

        public Vector2 PositionBeforeEvent
        {
            get { return Cast<NPCAccessor>()._GetPositionBeforeEvent(); }
            set { Cast<NPCAccessor>()._SetPositionBeforeEvent(value); }
        }

        public Vector2 LastPosition
        {
            get { return Cast<NPCAccessor>()._GetLastPosition(); }
            set { Cast<NPCAccessor>()._SetLastPosition(value); }
        }

        public bool IsInvisible
        {
            get { return Cast<NPCAccessor>()._GetIsInvisible(); }
            set { Cast<NPCAccessor>()._SetIsInvisible(value); }
        }

        public bool FollowSchedule
        {
            get { return Cast<NPCAccessor>()._GetFollowSchedule(); }
            set { Cast<NPCAccessor>()._SetFollowSchedule(value); }
        }

        public bool Datable
        {
            get { return Cast<NPCAccessor>()._GetDatable(); }
            set { Cast<NPCAccessor>()._SetDatable(value); }
        }

        public bool DatingFarmer
        {
            get { return Cast<NPCAccessor>()._GetDatingFarmer(); }
            set { Cast<NPCAccessor>()._SetDatingFarmer(value); }
        }

        public bool HasBeenKissedToday
        {
            get { return Cast<NPCAccessor>()._GetHasBeenKissedToday(); }
            set { Cast<NPCAccessor>()._SetHasBeenKissedToday(value); }
        }

        public bool DoingEndOfRouteAnimation
        {
            get { return Cast<NPCAccessor>()._GetDoingEndOfRouteAnimation(); }
            set { Cast<NPCAccessor>()._SetDoingEndOfRouteAnimation(value); }
        }

        public bool GoingToDoEndOfRouteAnimation
        {
            get { return Cast<NPCAccessor>()._GetGoingToDoEndOfRouteAnimation(); }
            set { Cast<NPCAccessor>()._SetGoingToDoEndOfRouteAnimation(value); }
        }

        public int RouteEndIntro
        {
            get { return Cast<NPCAccessor>()._GetRouteEndIntro(); }
            set { Cast<NPCAccessor>()._SetRouteEndIntro(value); }
        }

        public int RouteEndAnimation
        {
            get { return Cast<NPCAccessor>()._GetRouteEndAnimation(); }
            set { Cast<NPCAccessor>()._SetRouteEndAnimation(value); }
        }

        public int RouteEndOutro
        {
            get { return Cast<NPCAccessor>()._GetRouteEndOutro(); }
            set { Cast<NPCAccessor>()._SetRouteEndOutro(value); }
        }

        public string EndOfRouteMessage
        {
            get { return Cast<NPCAccessor>()._GetEndOfRouteMessage(); }
            set { Cast<NPCAccessor>()._SetEndOfRouteMessage(value); }
        }

        public string NextEndOfRouteMessage
        {
            get { return Cast<NPCAccessor>()._GetNextEndOfRouteMessage(); }
            set { Cast<NPCAccessor>()._SetNextEndOfRouteMessage(value); }
        }

        public string EndOfRouteBehaviorName
        {
            get { return Cast<NPCAccessor>()._GetEndOfRouteBehaviorName(); }
            set { Cast<NPCAccessor>()._SetEndOfRouteBehaviorName(value); }
        }

        public Point PreviousEndPoint
        {
            get { return Cast<NPCAccessor>()._GetPreviousEndPoint(); }
            set { Cast<NPCAccessor>()._SetPreviousEndPoint(value); }
        }

        public int ScheduleTimeToTry
        {
            get { return Cast<NPCAccessor>()._GetScheduleTimeToTry(); }
            set { Cast<NPCAccessor>()._SetScheduleTimeToTry(value); }
        }

        public int SquareMovementFacingPreference
        {
            get { return Cast<NPCAccessor>()._GetSquareMovementFacingPreference(); }
            set { Cast<NPCAccessor>()._SetSquareMovementFacingPreference(value); }
        }

        public bool ReturningToEndPoint
        {
            get { return Cast<NPCAccessor>()._GetReturningToEndPoint(); }
            set { Cast<NPCAccessor>()._SetReturningToEndPoint(value); }
        }

        public bool HasSaidAfternoonDialogue
        {
            get { return Cast<NPCAccessor>()._GetHasSaidAfternoonDialogue(); }
            set { Cast<NPCAccessor>()._SetHasSaidAfternoonDialogue(value); }
        }

        public int Married
        {
            get { return Cast<NPCAccessor>()._GetMarried(); }
            set { Cast<NPCAccessor>()._SetMarried(value); }
        }

        public int DaysMarried
        {
            get { return Cast<NPCAccessor>()._GetDaysMarried(); }
            set { Cast<NPCAccessor>()._SetDaysMarried(value); }
        }
    }
}