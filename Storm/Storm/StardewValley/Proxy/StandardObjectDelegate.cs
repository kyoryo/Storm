using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public class StandardObjectDelegate : ObjectDelegate
    {
        private int parentSpriteSheetIndex;
        private int initialStack;

        public StandardObjectDelegate(int parentSpriteSheetIndex, int initialStack)
        {
            this.parentSpriteSheetIndex = parentSpriteSheetIndex;
            this.initialStack = initialStack;
        }

        public override object[] GetConstructorParams()
        {
            return new object[] { parentSpriteSheetIndex, initialStack };
        }
    }
}
