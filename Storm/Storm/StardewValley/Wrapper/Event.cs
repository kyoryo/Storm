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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Event : StaticContextWrapper
    {
        public Event(StaticContext parent, EventAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public Event()
        {
        }

        public string EventCommands
        {
            get { return Cast<EventAccessor>()._GetEventCommands(); }
            set { Cast<EventAccessor>()._SetEventCommands(value); }
        }

        public int CurrentCommand
        {
            get { return Cast<EventAccessor>()._GetCurrentCommand(); }
            set { Cast<EventAccessor>()._SetCurrentCommand(value); }
        }

        public int OldPixelZoom
        {
            get { return Cast<EventAccessor>()._GetOldPixelZoom(); }
            set { Cast<EventAccessor>()._SetOldPixelZoom(value); }
        }

        public int ReadyConfirmationTimer
        {
            get { return Cast<EventAccessor>()._GetReadyConfirmationTimer(); }
            set { Cast<EventAccessor>()._SetReadyConfirmationTimer(value); }
        }

        public string MessageToScreen
        {
            get { return Cast<EventAccessor>()._GetMessageToScreen(); }
            set { Cast<EventAccessor>()._SetMessageToScreen(value); }
        }

        public string PlayerControlSequenceID
        {
            get { return Cast<EventAccessor>()._GetPlayerControlSequenceID(); }
            set { Cast<EventAccessor>()._SetPlayerControlSequenceID(value); }
        }

        public bool ShowActiveObject
        {
            get { return Cast<EventAccessor>()._GetShowActiveObject(); }
            set { Cast<EventAccessor>()._SetShowActiveObject(value); }
        }

        public bool ContinueAfterMove
        {
            get { return Cast<EventAccessor>()._GetContinueAfterMove(); }
            set { Cast<EventAccessor>()._SetContinueAfterMove(value); }
        }

        public bool SpecialEventVariable1
        {
            get { return Cast<EventAccessor>()._GetSpecialEventVariable1(); }
            set { Cast<EventAccessor>()._SetSpecialEventVariable1(value); }
        }

        public bool Forked
        {
            get { return Cast<EventAccessor>()._GetForked(); }
            set { Cast<EventAccessor>()._SetForked(value); }
        }

        public bool WasBloomDay
        {
            get { return Cast<EventAccessor>()._GetWasBloomDay(); }
            set { Cast<EventAccessor>()._SetWasBloomDay(value); }
        }

        public bool WasBloomVisible
        {
            get { return Cast<EventAccessor>()._GetWasBloomVisible(); }
            set { Cast<EventAccessor>()._SetWasBloomVisible(value); }
        }

        public bool PlayerControlSequence
        {
            get { return Cast<EventAccessor>()._GetPlayerControlSequence(); }
            set { Cast<EventAccessor>()._SetPlayerControlSequence(value); }
        }

        public bool EventSwitched
        {
            get { return Cast<EventAccessor>()._GetEventSwitched(); }
            set { Cast<EventAccessor>()._SetEventSwitched(value); }
        }

        public bool IsFestival
        {
            get { return Cast<EventAccessor>()._GetIsFestival(); }
            set { Cast<EventAccessor>()._SetIsFestival(value); }
        }

        public bool SentReadyConfirmation
        {
            get { return Cast<EventAccessor>()._GetSentReadyConfirmation(); }
            set { Cast<EventAccessor>()._SetSentReadyConfirmation(value); }
        }

        public bool AllPlayersReady
        {
            get { return Cast<EventAccessor>()._GetAllPlayersReady(); }
            set { Cast<EventAccessor>()._SetAllPlayersReady(value); }
        }

        public bool PlayerWasMounted
        {
            get { return Cast<EventAccessor>()._GetPlayerWasMounted(); }
            set { Cast<EventAccessor>()._SetPlayerWasMounted(value); }
        }

        public float TimeAccumulator
        {
            get { return Cast<EventAccessor>()._GetTimeAccumulator(); }
            set { Cast<EventAccessor>()._SetTimeAccumulator(value); }
        }

        public float ViewportXAccumulator
        {
            get { return Cast<EventAccessor>()._GetViewportXAccumulator(); }
            set { Cast<EventAccessor>()._SetViewportXAccumulator(value); }
        }

        public float ViewportYAccumulator
        {
            get { return Cast<EventAccessor>()._GetViewportYAccumulator(); }
            set { Cast<EventAccessor>()._SetViewportYAccumulator(value); }
        }

        public Vector3 ViewportTarget
        {
            get { return Cast<EventAccessor>()._GetViewportTarget(); }
            set { Cast<EventAccessor>()._SetViewportTarget(value); }
        }

        public Color PreviousAmbientLight
        {
            get { return Cast<EventAccessor>()._GetPreviousAmbientLight(); }
            set { Cast<EventAccessor>()._SetPreviousAmbientLight(value); }
        }

        public ContentManager TemporaryContent
        {
            get { return Cast<EventAccessor>()._GetTemporaryContent(); }
            set { Cast<EventAccessor>()._SetTemporaryContent(value); }
        }

        public GameLocation TemporaryLocation
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetTemporaryLocation();
                if (tmp == null) return null;
                return new GameLocation(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetTemporaryLocation(value?.Cast<GameLocationAccessor>()); }
        }

        public Point PlayerControlTargetTile
        {
            get { return Cast<EventAccessor>()._GetPlayerControlTargetTile(); }
            set { Cast<EventAccessor>()._SetPlayerControlTargetTile(value); }
        }

        public Texture2D FestivalTexture
        {
            get { return Cast<EventAccessor>()._GetFestivalTexture(); }
            set { Cast<EventAccessor>()._SetFestivalTexture(value); }
        }

        public NPC SecretSantaRecipient
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetSecretSantaRecipient();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetSecretSantaRecipient(value?.Cast<NPCAccessor>()); }
        }

        public NPC MySecretSanta
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetMySecretSanta();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetMySecretSanta(value?.Cast<NPCAccessor>()); }
        }

        public bool Skippable
        {
            get { return Cast<EventAccessor>()._GetSkippable(); }
            set { Cast<EventAccessor>()._SetSkippable(value); }
        }

        public int Id
        {
            get { return Cast<EventAccessor>()._GetId(); }
            set { Cast<EventAccessor>()._SetId(value); }
        }

        public int OldShirt
        {
            get { return Cast<EventAccessor>()._GetOldShirt(); }
            set { Cast<EventAccessor>()._SetOldShirt(value); }
        }

        public Color OldPants
        {
            get { return Cast<EventAccessor>()._GetOldPants(); }
            set { Cast<EventAccessor>()._SetOldPants(value); }
        }

        public bool Skipped
        {
            get { return Cast<EventAccessor>()._GetSkipped(); }
            set { Cast<EventAccessor>()._SetSkipped(value); }
        }

        public bool WaitingForMenuClose
        {
            get { return Cast<EventAccessor>()._GetWaitingForMenuClose(); }
            set { Cast<EventAccessor>()._SetWaitingForMenuClose(value); }
        }

        public int OldTime
        {
            get { return Cast<EventAccessor>()._GetOldTime(); }
            set { Cast<EventAccessor>()._SetOldTime(value); }
        }

        public NPC FestivalHost
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetFestivalHost();
                if (tmp == null) return null;
                return new NPC(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetFestivalHost(value?.Cast<NPCAccessor>()); }
        }

        public string HostMessage
        {
            get { return Cast<EventAccessor>()._GetHostMessage(); }
            set { Cast<EventAccessor>()._SetHostMessage(value); }
        }

        public int FestivalTimer
        {
            get { return Cast<EventAccessor>()._GetFestivalTimer(); }
            set { Cast<EventAccessor>()._SetFestivalTimer(value); }
        }

        public Item TempItemStash
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetTempItemStash();
                if (tmp == null) return null;
                return new Item(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetTempItemStash(value?.Cast<ItemAccessor>()); }
        }

        public int GrangeScore
        {
            get { return Cast<EventAccessor>()._GetGrangeScore(); }
            set { Cast<EventAccessor>()._SetGrangeScore(value); }
        }

        public Farmer PlayerUsingGrangeDisplay
        {
            get
            {
                var tmp = Cast<EventAccessor>()._GetPlayerUsingGrangeDisplay();
                if (tmp == null) return null;
                return new Farmer(Parent, tmp);
            }
            set { Cast<EventAccessor>()._SetPlayerUsingGrangeDisplay(value?.Cast<FarmerAccessor>()); }
        }

        public int PreviousFacingDirection
        {
            get { return Cast<EventAccessor>()._GetPreviousFacingDirection(); }
            set { Cast<EventAccessor>()._SetPreviousFacingDirection(value); }
        }

        public int PreviousAnswerChoice
        {
            get { return Cast<EventAccessor>()._GetPreviousAnswerChoice(); }
            set { Cast<EventAccessor>()._SetPreviousAnswerChoice(value); }
        }

        public bool StartSecretSantaAfterDialogue
        {
            get { return Cast<EventAccessor>()._GetStartSecretSantaAfterDialogue(); }
            set { Cast<EventAccessor>()._SetStartSecretSantaAfterDialogue(value); }
        }

        public bool SpecialEventVariable2
        {
            get { return Cast<EventAccessor>()._GetSpecialEventVariable2(); }
            set { Cast<EventAccessor>()._SetSpecialEventVariable2(value); }
        }
    }
}