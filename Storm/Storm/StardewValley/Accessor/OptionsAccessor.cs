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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface OptionsAccessor
    {
        bool _GetAutoRun();
        void _SetAutoRun(bool val);

        bool _GetDialogueTyping();
        void _SetDialogueTyping(bool val);

        bool _GetFullscreen();
        void _SetFullscreen(bool val);

        bool _GetWindowedBorderlessFullscreen();
        void _SetWindowedBorderlessFullscreen(bool val);

        bool _GetShowPortraits();
        void _SetShowPortraits(bool val);

        bool _GetShowMerchantPortraits();
        void _SetShowMerchantPortraits(bool val);

        bool _GetShowMenuBackground();
        void _SetShowMenuBackground(bool val);

        bool _GetPlayFootstepSounds();
        void _SetPlayFootstepSounds(bool val);

        bool _GetAlwaysShowToolHitLocation();
        void _SetAlwaysShowToolHitLocation(bool val);

        bool _GetHideToolHitLocationWhenInMotion();
        void _SetHideToolHitLocationWhenInMotion(bool val);

        bool _GetPauseWhenOutOfFocus();
        void _SetPauseWhenOutOfFocus(bool val);

        bool _GetPinToolbarToggle();
        void _SetPinToolbarToggle(bool val);

        bool _GetMouseControls();
        void _SetMouseControls(bool val);

        bool _GetKeyboardControls();
        void _SetKeyboardControls(bool val);

        bool _GetGamepadControls();
        void _SetGamepadControls(bool val);

        bool _GetRumble();
        void _SetRumble(bool val);

        bool _GetAmbientOnlyToggle();
        void _SetAmbientOnlyToggle(bool val);

        float _GetMusicVolumeLevel();
        void _SetMusicVolumeLevel(float val);

        float _GetSoundVolumeLevel();
        void _SetSoundVolumeLevel(float val);

        int _GetPreferredResolutionX();
        void _SetPreferredResolutionX(int val);

        int _GetPreferredResolutionY();
        void _SetPreferredResolutionY(int val);

        InputButtonAccessor[] _GetActionButton();
        void _SetActionButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetToolSwapButton();
        void _SetToolSwapButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetCancelButton();
        void _SetCancelButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetUseToolButton();
        void _SetUseToolButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMoveUpButton();
        void _SetMoveUpButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMoveRightButton();
        void _SetMoveRightButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMoveDownButton();
        void _SetMoveDownButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMoveLeftButton();
        void _SetMoveLeftButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMenuButton();
        void _SetMenuButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetRunButton();
        void _SetRunButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetTmpKeyToReplace();
        void _SetTmpKeyToReplace(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetChatButton();
        void _SetChatButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetMapButton();
        void _SetMapButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetJournalButton();
        void _SetJournalButton(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot1();
        void _SetInventorySlot1(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot2();
        void _SetInventorySlot2(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot3();
        void _SetInventorySlot3(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot4();
        void _SetInventorySlot4(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot5();
        void _SetInventorySlot5(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot6();
        void _SetInventorySlot6(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot7();
        void _SetInventorySlot7(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot8();
        void _SetInventorySlot8(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot9();
        void _SetInventorySlot9(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot10();
        void _SetInventorySlot10(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot11();
        void _SetInventorySlot11(InputButtonAccessor[] val);

        InputButtonAccessor[] _GetInventorySlot12();
        void _SetInventorySlot12(InputButtonAccessor[] val);
    }
}
