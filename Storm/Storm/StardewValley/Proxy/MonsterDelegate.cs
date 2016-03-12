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

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public abstract class MonsterDelegate : NPCDelegate
    {
        public MonsterDelegate(string name, Vector2 position)
        {
            ConstructorParams.Add(name);
            ConstructorParams.Add(position);
        }

        public MonsterDelegate()
        {
        }

        [ProxyMap(Name = "BehaviourAtGameTick")]
        public virtual OverrideEvent BehaviourAtGameTick(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "DeathAnimation")]
        public virtual OverrideEvent DeathAnimation(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "DefaultMovementBehavior")]
        public virtual OverrideEvent DefaultMovementBehavior(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "Draw")]
        public virtual OverrideEvent Draw(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "DrawAboveAllLayers")]
        public virtual OverrideEvent DrawAboveAllLayers(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "GetExtraDropItems")]
        public virtual OverrideEvent GetExtraDropItems(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "MovePosition")]
        public virtual OverrideEvent MovePosition(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "NoMovementProgressNearPlayerBehavior")]
        public virtual OverrideEvent NoMovementProgressNearPlayerBehavior(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "PassThroughCharacters")]
        public virtual OverrideEvent PassTHroughCharacters(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "ReloadSprite")]
        public virtual OverrideEvent ReloadSprite(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "ShedChunks")]
        public virtual OverrideEvent ShedChunks(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "ShouldCollideWithBuildingLayer")]
        public virtual OverrideEvent ShouldCollideWithBuildingLayer(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "TakeDamage")]
        public virtual OverrideEvent TakeDamage(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "Update")]
        public virtual OverrideEvent Update(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "UpdateMovement")]
        public virtual OverrideEvent UpdateMovement(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }

        [ProxyMap(Name = "WithinPlayerThreshold")]
        public virtual OverrideEvent WithinPlayerThreshold(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }
    }
}
