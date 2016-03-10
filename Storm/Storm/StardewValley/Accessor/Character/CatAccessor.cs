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
    public interface CatAccessor : PetAccessor
    {
        int _GetCurrentBehavior();
        void _SetCurrentBehavior(int val);

        int _GetTimesOnCurrentAnimation();
        void _SetTimesOnCurrentAnimation(int val);

        System.String _GetKittyName();
        void _SetKittyName(System.String val);

        bool _GetWasPet();
        void _SetWasPet(bool val);

        bool _GetMadeSnoozeSoundLastFrame();
        void _SetMadeSnoozeSoundLastFrame(bool val);

        int _GetLoveForMaster();
        void _SetLoveForMaster(int val);
    }
}