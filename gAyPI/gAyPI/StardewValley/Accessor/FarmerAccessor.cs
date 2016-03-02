using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Accessor
{
    public interface FarmerAccessor : CharacterAccessor
    {
        /*int GetHouseUpgradeLevel();

        bool CanMove();

        bool CanOnlyWalk();

        bool CanReleaseTool();

        int GetCombatLevel();

        int GetHealth();

        int GetMaxHealth();

        int GetImmunity();

        bool IsCrafting();

        bool IsMale();

        int GetMaxItems();

        float GetRotation();

        bool IsRunning();

        float GetStamina();

        bool UsingTool();

        float GetOffsetX();

        float GetOffsetY();*/

        IList _GetItems();
    }
}
