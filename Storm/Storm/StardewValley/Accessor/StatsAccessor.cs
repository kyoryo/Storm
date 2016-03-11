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
    public interface StatsAccessor
    {
        uint _GetSeedsSown();
        void _SetSeedsSown(uint val);

        uint _GetItemsShipped();
        void _SetItemsShipped(uint val);

        uint _GetItemsCooked();
        void _SetItemsCooked(uint val);

        uint _GetItemsCrafted();
        void _SetItemsCrafted(uint val);

        uint _GetChickenEggsLayed();
        void _SetChickenEggsLayed(uint val);

        uint _GetDuckEggsLayed();
        void _SetDuckEggsLayed(uint val);

        uint _GetCowMilkProduced();
        void _SetCowMilkProduced(uint val);

        uint _GetGoatMilkProduced();
        void _SetGoatMilkProduced(uint val);

        uint _GetRabbitWoolProduced();
        void _SetRabbitWoolProduced(uint val);

        uint _GetSheepWoolProduced();
        void _SetSheepWoolProduced(uint val);

        uint _GetCheeseMade();
        void _SetCheeseMade(uint val);

        uint _GetGoatCheeseMade();
        void _SetGoatCheeseMade(uint val);

        uint _GetTrufflesFound();
        void _SetTrufflesFound(uint val);

        uint _GetStoneGathered();
        void _SetStoneGathered(uint val);

        uint _GetRocksCrushed();
        void _SetRocksCrushed(uint val);

        uint _GetDirtHoed();
        void _SetDirtHoed(uint val);

        uint _GetGiftsGiven();
        void _SetGiftsGiven(uint val);

        uint _GetTimesUnconscious();
        void _SetTimesUnconscious(uint val);

        uint _GetAverageBedtime();
        void _SetAverageBedtime(uint val);

        uint _GetTimesFished();
        void _SetTimesFished(uint val);

        uint _GetFishCaught();
        void _SetFishCaught(uint val);

        uint _GetBouldersCracked();
        void _SetBouldersCracked(uint val);

        uint _GetStumpsChopped();
        void _SetStumpsChopped(uint val);

        uint _GetStepsTaken();
        void _SetStepsTaken(uint val);

        uint _GetMonstersKilled();
        void _SetMonstersKilled(uint val);

        uint _GetDiamondsFound();
        void _SetDiamondsFound(uint val);

        uint _GetPrismaticShardsFound();
        void _SetPrismaticShardsFound(uint val);

        uint _GetOtherPreciousGemsFound();
        void _SetOtherPreciousGemsFound(uint val);

        uint _GetCaveCarrotsFound();
        void _SetCaveCarrotsFound(uint val);

        uint _GetCopperFound();
        void _SetCopperFound(uint val);

        uint _GetIronFound();
        void _SetIronFound(uint val);

        uint _GetCoalFound();
        void _SetCoalFound(uint val);

        uint _GetCoinsFound();
        void _SetCoinsFound(uint val);

        uint _GetGoldFound();
        void _SetGoldFound(uint val);

        uint _GetIridiumFound();
        void _SetIridiumFound(uint val);

        uint _GetBarsSmelted();
        void _SetBarsSmelted(uint val);

        uint _GetBeveragesMade();
        void _SetBeveragesMade(uint val);

        uint _GetPreservesMade();
        void _SetPreservesMade(uint val);

        uint _GetPiecesOfTrashRecycled();
        void _SetPiecesOfTrashRecycled(uint val);

        uint _GetMysticStonesCrushed();
        void _SetMysticStonesCrushed(uint val);

        uint _GetDaysPlayed();
        void _SetDaysPlayed(uint val);

        uint _GetWeedsEliminated();
        void _SetWeedsEliminated(uint val);

        uint _GetSticksChopped();
        void _SetSticksChopped(uint val);

        uint _GetNotesFound();
        void _SetNotesFound(uint val);

        uint _GetQuestsCompleted();
        void _SetQuestsCompleted(uint val);

        uint _GetStarLevelCropsShipped();
        void _SetStarLevelCropsShipped(uint val);

        uint _GetCropsShipped();
        void _SetCropsShipped(uint val);

        uint _GetSlimesKilled();
        void _SetSlimesKilled(uint val);

        uint _GetGeodesCracked();
        void _SetGeodesCracked(uint val);

        System.Collections.IDictionary _GetSpecificMonstersKilled();
        void _SetSpecificMonstersKilled(System.Collections.IDictionary val);
    }
}
