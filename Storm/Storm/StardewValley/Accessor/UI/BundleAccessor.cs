using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface BundleAccessor : ClickableComponentAccessor
    {
        System.String _GetRewardDescription();
        void _SetRewardDescription(System.String val);

        System.Collections.IList _GetIngredients();
        void _SetIngredients(System.Collections.IList val);

        int _GetBundleColor();
        void _SetBundleColor(int val);

        int _GetNumberOfIngredientSlots();
        void _SetNumberOfIngredientSlots(int val);

        int _GetBundleIndex();
        void _SetBundleIndex(int val);

        int _GetCompletionTimer();
        void _SetCompletionTimer(int val);

        bool _GetComplete();
        void _SetComplete(bool val);

        bool _GetDepositsAllowed();
        void _SetDepositsAllowed(bool val);

        TempAnimatedSpriteAccessor _GetSprite();
        void _SetSprite(TempAnimatedSpriteAccessor val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);
    }
}
