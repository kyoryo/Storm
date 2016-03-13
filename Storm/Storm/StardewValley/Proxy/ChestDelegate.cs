using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public class ChestDelegate : ObjectDelegate
    {
        public ChestDelegate(bool playerChest)
        {
            ConstructorParams.Add(playerChest);
        }
    }
}
