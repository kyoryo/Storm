namespace Storm.StardewValley.Event.Crop
{
    public class AfterHarvestCropEvent : StaticContextEvent
    {
        public Storm.StardewValley.Wrapper.Crop Crop { get; }

        public AfterHarvestCropEvent(Storm.StardewValley.Wrapper.Crop crop)
        {
            this.Crop = crop;
        }

    }
}
