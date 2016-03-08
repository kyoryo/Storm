using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Billboard : ClickableMenu, Wrapper<BillboardAccessor>
    {
        private BillboardAccessor accessor;

        public Billboard(StaticContext parent, BillboardAccessor accessor) : 
            base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public Texture2D BillboardTexture
        {
            get { return accessor._GetBillboardTexture(); }
            set { accessor._SetBillboardTexture(value); }
        }

        public bool DailyQuestBoard
        {
            get { return accessor._GetDailyQuestBoard(); }
            set { accessor._SetDailyQuestBoard(value); }
        }

        public ClickableComponent AcceptQuestButton
        {
            get { return new ClickableComponent(Parent, accessor._GetAcceptQuestButton()); }
            set { accessor._SetAcceptQuestButton(value.Expose()); }
        }

        public ProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent> CalendarDays
        {
            get {
                return new ProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent>(
                    accessor._GetCalendarDays(), i => new ClickableTextureComponent(Parent, i));
            }
        }

        public String HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public new BillboardAccessor Expose() => accessor;
    }
}
