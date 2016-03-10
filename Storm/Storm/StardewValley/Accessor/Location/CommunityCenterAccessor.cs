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
    public interface CommunityCenterAccessor : GameLocationAccessor
    {
        bool _GetRefurbishedLoaded();
        void _SetRefurbishedLoaded(bool val);

        bool _GetWarehouse();
        void _SetWarehouse(bool val);

        System.Collections.IDictionary _GetBundles();
        void _SetBundles(System.Collections.IDictionary val);

        System.Collections.IDictionary _GetBundleRewards();
        void _SetBundleRewards(System.Collections.IDictionary val);

        bool[] _GetAreasComplete();
        void _SetAreasComplete(bool[] val);

        int _GetNumberOfStarsOnPlaque();
        void _SetNumberOfStarsOnPlaque(int val);

        float _GetMessageAlpha();
        void _SetMessageAlpha(float val);

        System.Collections.IList _GetJunimoNotesViewportTargets();
        void _SetJunimoNotesViewportTargets(System.Collections.IList val);

        System.Collections.IDictionary _GetAreaToBundleDictionary();
        void _SetAreaToBundleDictionary(System.Collections.IDictionary val);

        System.Collections.IDictionary _GetBundleToAreaDictionary();
        void _SetBundleToAreaDictionary(System.Collections.IDictionary val);

        int _GetRestoreAreaTimer();
        void _SetRestoreAreaTimer(int val);

        int _GetRestoreAreaPhase();
        void _SetRestoreAreaPhase(int val);

        int _GetRestoreAreaIndex();
        void _SetRestoreAreaIndex(int val);

        Microsoft.Xna.Framework.Audio.Cue _GetBuildUpSound();
        void _SetBuildUpSound(Microsoft.Xna.Framework.Audio.Cue val);
    }
}
