namespace Storm.StardewValley.Event.Crop
{
    public class BeforeHarvestCropEvent : StaticContextEvent
    {
        public BeforeHarvestCropEvent(Wrapper.Crop crop)
        {
            Crop = crop;
        }

        public Wrapper.Crop Crop { get; }
    }
}