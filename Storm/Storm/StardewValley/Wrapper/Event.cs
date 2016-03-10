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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Event : Wrapper
    {
        private readonly EventAccessor accessor;

        public Event(StaticContext parent, EventAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        private StaticContext Parent { get; }

        public string EventCommands
        {
            get { return accessor._GetEventCommands(); }
            set { accessor._SetEventCommands(value); }
        }

        public int CurrentCommand
        {
            get { return accessor._GetCurrentCommand(); }
            set { accessor._SetCurrentCommand(value); }
        }

        public int OldPixelZoom
        {
            get { return accessor._GetOldPixelZoom(); }
            set { accessor._SetOldPixelZoom(value); }
        }

        public int ReadyConfirmationTimer
        {
            get { return accessor._GetReadyConfirmationTimer(); }
            set { accessor._SetReadyConfirmationTimer(value); }
        }

        public string MessageToScreen
        {
            get { return accessor._GetMessageToScreen(); }
            set { accessor._SetMessageToScreen(value); }
        }

        public string PlayerControlSequenceID
        {
            get { return accessor._GetPlayerControlSequenceID(); }
            set { accessor._SetPlayerControlSequenceID(value); }
        }

        public bool ShowActiveObject
        {
            get { return accessor._GetShowActiveObject(); }
            set { accessor._SetShowActiveObject(value); }
        }

        public bool ContinueAfterMove
        {
            get { return accessor._GetContinueAfterMove(); }
            set { accessor._SetContinueAfterMove(value); }
        }

        public bool SpecialEventVariable1
        {
            get { return accessor._GetSpecialEventVariable1(); }
            set { accessor._SetSpecialEventVariable1(value); }
        }

        public bool Forked
        {
            get { return accessor._GetForked(); }
            set { accessor._SetForked(value); }
        }

        public bool WasBloomDay
        {
            get { return accessor._GetWasBloomDay(); }
            set { accessor._SetWasBloomDay(value); }
        }

        public bool WasBloomVisible
        {
            get { return accessor._GetWasBloomVisible(); }
            set { accessor._SetWasBloomVisible(value); }
        }

        public bool PlayerControlSequence
        {
            get { return accessor._GetPlayerControlSequence(); }
            set { accessor._SetPlayerControlSequence(value); }
        }

        public bool EventSwitched
        {
            get { return accessor._GetEventSwitched(); }
            set { accessor._SetEventSwitched(value); }
        }

        public bool IsFestival
        {
            get { return accessor._GetIsFestival(); }
            set { accessor._SetIsFestival(value); }
        }

        public bool SentReadyConfirmation
        {
            get { return accessor._GetSentReadyConfirmation(); }
            set { accessor._SetSentReadyConfirmation(value); }
        }

        public bool AllPlayersReady
        {
            get { return accessor._GetAllPlayersReady(); }
            set { accessor._SetAllPlayersReady(value); }
        }

        public bool PlayerWasMounted
        {
            get { return accessor._GetPlayerWasMounted(); }
            set { accessor._SetPlayerWasMounted(value); }
        }

        public float TimeAccumulator
        {
            get { return accessor._GetTimeAccumulator(); }
            set { accessor._SetTimeAccumulator(value); }
        }

        public float ViewportXAccumulator
        {
            get { return accessor._GetViewportXAccumulator(); }
            set { accessor._SetViewportXAccumulator(value); }
        }

        public float ViewportYAccumulator
        {
            get { return accessor._GetViewportYAccumulator(); }
            set { accessor._SetViewportYAccumulator(value); }
        }

        public Vector3 ViewportTarget
        {
            get { return accessor._GetViewportTarget(); }
            set { accessor._SetViewportTarget(value); }
        }

        public Color PreviousAmbientLight
        {
            get { return accessor._GetPreviousAmbientLight(); }
            set { accessor._SetPreviousAmbientLight(value); }
        }

        public ContentManager TemporaryContent
        {
            get { return accessor._GetTemporaryContent(); }
            set { accessor._SetTemporaryContent(value); }
        }

        public GameLocation TemporaryLocation
        {
            get { return accessor._GetTemporaryLocation() == null ? null : new GameLocation(Parent, accessor._GetTemporaryLocation()); }
            set { accessor._SetTemporaryLocation(value.Cast<GameLocationAccessor>()); }
        }

        public Point PlayerControlTargetTile
        {
            get { return accessor._GetPlayerControlTargetTile(); }
            set { accessor._SetPlayerControlTargetTile(value); }
        }

        public Texture2D FestivalTexture
        {
            get { return accessor._GetFestivalTexture(); }
            set { accessor._SetFestivalTexture(value); }
        }

        public NPC SecretSantaRecipient
        {
            get { return accessor._GetSecretSantaRecipient() == null ? null : new NPC(Parent, accessor._GetSecretSantaRecipient()); }
            set { accessor._SetSecretSantaRecipient(value.Cast<NPCAccessor>()); }
        }

        public NPC MySecretSanta
        {
            get { return accessor._GetMySecretSanta() == null ? null : new NPC(Parent, accessor._GetMySecretSanta()); }
            set { accessor._SetMySecretSanta(value.Cast<NPCAccessor>()); }
        }

        public bool Skippable
        {
            get { return accessor._GetSkippable(); }
            set { accessor._SetSkippable(value); }
        }

        public int Id
        {
            get { return accessor._GetId(); }
            set { accessor._SetId(value); }
        }

        public int OldShirt
        {
            get { return accessor._GetOldShirt(); }
            set { accessor._SetOldShirt(value); }
        }

        public Color OldPants
        {
            get { return accessor._GetOldPants(); }
            set { accessor._SetOldPants(value); }
        }

        public bool Skipped
        {
            get { return accessor._GetSkipped(); }
            set { accessor._SetSkipped(value); }
        }

        public bool WaitingForMenuClose
        {
            get { return accessor._GetWaitingForMenuClose(); }
            set { accessor._SetWaitingForMenuClose(value); }
        }

        public int OldTime
        {
            get { return accessor._GetOldTime(); }
            set { accessor._SetOldTime(value); }
        }

        public NPC FestivalHost
        {
            get { return accessor._GetFestivalHost() == null ? null : new NPC(Parent, accessor._GetFestivalHost()); }
            set { accessor._SetFestivalHost(value.Cast<NPCAccessor>()); }
        }

        public string HostMessage
        {
            get { return accessor._GetHostMessage(); }
            set { accessor._SetHostMessage(value); }
        }

        public int FestivalTimer
        {
            get { return accessor._GetFestivalTimer(); }
            set { accessor._SetFestivalTimer(value); }
        }

        public Item TempItemStash
        {
            get { return accessor._GetTempItemStash() == null ? null : new Item(Parent, accessor._GetTempItemStash()); }
            set { accessor._SetTempItemStash(value.Cast<ItemAccessor>()); }
        }

        public int GrangeScore
        {
            get { return accessor._GetGrangeScore(); }
            set { accessor._SetGrangeScore(value); }
        }

        public Farmer PlayerUsingGrangeDisplay
        {
            get { return accessor._GetPlayerUsingGrangeDisplay() == null ? null : new Farmer(Parent, accessor._GetPlayerUsingGrangeDisplay()); }
            set { accessor._SetPlayerUsingGrangeDisplay(value.Cast<FarmerAccessor>()); }
        }

        public int PreviousFacingDirection
        {
            get { return accessor._GetPreviousFacingDirection(); }
            set { accessor._SetPreviousFacingDirection(value); }
        }

        public int PreviousAnswerChoice
        {
            get { return accessor._GetPreviousAnswerChoice(); }
            set { accessor._SetPreviousAnswerChoice(value); }
        }

        public bool StartSecretSantaAfterDialogue
        {
            get { return accessor._GetStartSecretSantaAfterDialogue(); }
            set { accessor._SetStartSecretSantaAfterDialogue(value); }
        }

        public bool SpecialEventVariable2
        {
            get { return accessor._GetSpecialEventVariable2(); }
            set { accessor._SetSpecialEventVariable2(value); }
        }

        public object Expose() => accessor;
    }
}