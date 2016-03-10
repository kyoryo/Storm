using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface FlooringAccessor : TerrainFeatureAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetFloorsTexture();
        void _SetFloorsTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        System.Collections.IDictionary _GetDrawGuide();
        void _SetDrawGuide(System.Collections.IDictionary val);

        int _GetWhichFloor();
        void _SetWhichFloor(int val);

        int _GetWhichView();
        void _SetWhichView(int val);

        bool _GetIsPathway();
        void _SetIsPathway(bool val);

        bool _GetIsSteppingStone();
        void _SetIsSteppingStone(bool val);
    }
}
