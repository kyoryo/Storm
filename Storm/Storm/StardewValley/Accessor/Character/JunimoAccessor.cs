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

namespace Storm.StardewValley.Accessor
{
    public interface JunimoAccessor : NPCAccessor
    {
        float _GetAlpha();
        void _SetAlpha(float val);

        float _GetAlphaChange();
        void _SetAlphaChange(float val);

        int _GetFarmerCloseCheckTimer();
        void _SetFarmerCloseCheckTimer(int val);

        int _GetWhichArea();
        void _SetWhichArea(int val);

        bool _GetFriendly();
        void _SetFriendly(bool val);

        bool _GetHoldingStar();
        void _SetHoldingStar(bool val);

        bool _GetHoldingBundle();
        void _SetHoldingBundle(bool val);

        bool _GetTemporaryJunimo();
        void _SetTemporaryJunimo(bool val);

        bool _GetStayPut();
        void _SetStayPut(bool val);

        bool _GetEventActor();
        void _SetEventActor(bool val);

        Microsoft.Xna.Framework.Vector2 _GetMotion();
        void _SetMotion(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Rectangle _GetNextPosition();
        void _SetNextPosition(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Color _GetColor();
        void _SetColor(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Color _GetBundleColor();
        void _SetBundleColor(Microsoft.Xna.Framework.Color val);

        int _GetSoundTimer();
        void _SetSoundTimer(int val);

        bool _GetSayingGoodbye();
        void _SetSayingGoodbye(bool val);
    }
}