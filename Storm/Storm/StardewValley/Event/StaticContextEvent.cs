/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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
using System.Reflection;
using Castle.DynamicProxy;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Proxy;
using Storm.StardewValley.Wrapper;
using System.Collections.Generic;

namespace Storm.StardewValley
{
    public class StaticContextEvent : DetourEvent
    {
        public delegate void InitDelegate(StaticContextEvent @this);
        public delegate InterceptorFactory<DType> CreateFactoryDelegate<AType, DType>();

        public void Init(InitDelegate init)
        {
            init(this);
        }

        public Assembly GameAssembly { get; set; }
        public StaticContext Root { get; set; }
        public ModEventBus EventBus { get; set; }

        public Farmer LocalPlayer
        {
            get { return Root.Player; }
        }

        public GameLocation Location
        {
            get { return Root.CurrentLocation; }
        }

        public Tool ProxyTool(ToolDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<ToolAccessor, ToolDelegate>(@delegate);
            var wrapped = new Tool(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public ObjectItem ProxyObject(ObjectDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<ObjectAccessor, ObjectDelegate>(@delegate);
            var wrapped = new ObjectItem(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public Billboard ProxyBillboard(BillboardDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<BillboardAccessor, BillboardDelegate>(@delegate);
            var wrapped = new Billboard(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public ClickableTextureComponent ProxyTexture(TextureComponentDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<ClickableTextureComponentAccessor, TextureComponentDelegate>(@delegate);
            var wrapped = new ClickableTextureComponent(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public ClickableMenu ProxyClickableMenu(ClickableMenuDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<ClickableMenuAccessor, ClickableMenuDelegate>(@delegate);
            var wrapped = new ClickableMenu(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public AnimatedSprite ProxyAnimatedSprite(AnimatedSpriteDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<AnimatedSpriteAccessor, AnimatedSpriteDelegate>(@delegate);
            var wrapped = new AnimatedSprite(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public Character ProxyCharacter(CharacterDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<CharacterAccessor, CharacterDelegate>(@delegate);
            var wrapped = new Character(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public NPC ProxyNPC(NPCDelegate @delegate)
        {
            var accessor = StaticGameContext.ProxyAccessor<NPCAccessor, NPCDelegate>(@delegate);
            var wrapped = new NPC(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }
    }
}