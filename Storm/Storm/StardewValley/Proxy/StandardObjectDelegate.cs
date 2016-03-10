namespace Storm.StardewValley.Proxy
{
    public class StandardObjectDelegate : ObjectDelegate
    {
        private readonly int initialStack;
        private readonly int parentSpriteSheetIndex;

        public StandardObjectDelegate(int parentSpriteSheetIndex, int initialStack)
        {
            this.parentSpriteSheetIndex = parentSpriteSheetIndex;
            this.initialStack = initialStack;
        }

        public override object[] GetConstructorParams()
        {
            return new object[] {parentSpriteSheetIndex, initialStack};
        }
    }
}