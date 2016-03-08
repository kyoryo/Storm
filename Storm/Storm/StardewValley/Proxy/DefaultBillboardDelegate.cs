using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public class StandardBillboardDelegate : BillboardDelegate
    {
        private bool dailyQuest;

        public StandardBillboardDelegate(bool dailyQuest = false)
        {
            this.dailyQuest = dailyQuest;
        }

        public override object[] GetConstructorParams()
        {
            return new object[] { dailyQuest };
        }
    }
}
