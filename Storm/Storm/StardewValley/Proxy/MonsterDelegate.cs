using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public abstract class MonsterDelegate
    {
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
