namespace Storm.StardewValley.Wrapper
{
    public class ProgramWrapper : Wrapper
    {
        public ProgramWrapper(object accessor)
        {
            Underlying = accessor;
        }

        public StaticContext GetGame()
        {
            return new StaticContext(AsDynamic._GetGame());
        }
    }
}