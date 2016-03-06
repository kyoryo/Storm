namespace Storm.StardewValley.Event.Crop
{
    public class AfterHarvestCropEvent : StaticContextEvent
    {
        public AfterHarvestCropEvent(Wrapper.Crop crop)
        {
            Crop = crop;
        }

        public Wrapper.Crop Crop { get; }
    }
}