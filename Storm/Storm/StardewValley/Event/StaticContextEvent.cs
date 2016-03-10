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
using System.Reflection;
using Castle.DynamicProxy;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Proxy;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley
{
    public class StaticContextEvent : DetourEvent
    {
        public delegate void InitDelegate(StaticContextEvent @this);

        public void Init(InitDelegate init)
        {
            init(this);
        }

        public Assembly GameAssembly { get; set; }
        public StaticContext Root { get; set; }
        public ModEventBus EventBus { get; set; }
        public Type ToolType { get; set; }
        public InterceptorFactory<ToolDelegate> ToolFactory { get; set; }
        public Type ObjectType { get; set; }
        public InterceptorFactory<ObjectDelegate> ObjectFactory { get; set; }
        public Type TextureComponentType { get; set; }
        public InterceptorFactory<TextureComponentDelegate> TextureComponentFactory { get; set; }
        public Type BillboardType { get; set; }
        public InterceptorFactory<BillboardDelegate> BillboardFactory { get; set; }
        public Type ClickableMenuType { get; set; }
        public InterceptorFactory<ClickableMenuDelegate> ClickableMenuFactory { get; set; }
        public Type AnimatedSpriteType { get; set; }
        public InterceptorFactory<AnimatedSpriteDelegate> AnimatedSpriteFactory { get; set; }
        public Type CharacterType { get; set; }
        public InterceptorFactory<CharacterDelegate> CharacterFactory { get; set; }
        public Type NPCType { get; set; }
        public InterceptorFactory<NPCDelegate> NPCFactory { get; set; }

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
            var generator = new ProxyGenerator();
            var accessor = (ToolAccessor) generator.CreateClassProxy(
                ToolType, ToolFactory.CreateInterceptor(@delegate));

            var wrapped = new Tool(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public ObjectItem ProxyObject(ObjectDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (ObjectAccessor) generator.CreateClassProxy(
                ObjectType, ObjectFactory.CreateInterceptor(@delegate));

            var wrapped = new ObjectItem(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public Billboard ProxyBillboard(BillboardDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (BillboardAccessor) generator.CreateClassProxy(
                BillboardType, BillboardFactory.CreateInterceptor(@delegate));

            var wrapped = new Billboard(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public ClickableTextureComponentAccessor ProxyTexture(TextureComponentDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (ClickableTextureComponentAccessor) generator.CreateClassProxy(
                TextureComponentType,
                @delegate.GetConstructorParams(),
                TextureComponentFactory.CreateInterceptor(@delegate));

            return accessor;
        }

        public ClickableMenu ProxyClickableMenu(ClickableMenuDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (ClickableMenuAccessor) generator.CreateClassProxy(
                ClickableMenuType, ClickableMenuFactory.CreateInterceptor(@delegate));

            var wrapped = new ClickableMenu(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public AnimatedSprite ProxyAnimatedSprite(AnimatedSpriteDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (AnimatedSpriteAccessor) generator.CreateClassProxy(
                AnimatedSpriteType,
                @delegate.GetConstructorParams(),
                AnimatedSpriteFactory.CreateInterceptor(@delegate));

            var wrapped = new AnimatedSprite(accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public Character ProxyCharacter(CharacterDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (CharacterAccessor) generator.CreateClassProxy(
                CharacterType,
                @delegate.GetConstructorParams(),
                CharacterFactory.CreateInterceptor(@delegate));

            var wrapped = new Character(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }

        public NPC ProxyNPC(NPCDelegate @delegate)
        {
            var generator = new ProxyGenerator();
            var accessor = (NPCAccessor) generator.CreateClassProxy(
                NPCType,
                @delegate.GetConstructorParams(),
                NPCFactory.CreateInterceptor(@delegate));

            var wrapped = new NPC(Root, accessor);
            @delegate.Accessor = wrapped;
            return wrapped;
        }
    }
}