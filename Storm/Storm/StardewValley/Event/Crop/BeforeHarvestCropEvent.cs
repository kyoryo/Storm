namespace Storm.StardewValley.Event.Crop
{
    public class BeforeHarvestCropEvent : StaticContextEvent
    {
        public Storm.StardewValley.Wrapper.Crop Crop { get; }

        public BeforeHarvestCropEvent(Storm.StardewValley.Wrapper.Crop crop)
        {
            this.Crop = crop;
        }

    }
}
