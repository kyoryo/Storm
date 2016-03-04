using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class AddItemToInventoryEvent : StaticContextEvent
    {
        private Farmer source;
        private Item item;
        
        public AddItemToInventoryEvent(Farmer source, Item item)
        {
            this.source = source;
            this.item = item;
        }

        public Farmer Source { get { return source; } }
        public Item Item { get { return item; } }
    }
}
