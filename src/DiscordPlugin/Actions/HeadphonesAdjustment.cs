namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphonesAdjustment : PluginDynamicAdjustment
    {
        public HeadphonesAdjustment() : base(displayName: "Display headphones state", description: "Display headphones state.", groupName: "", hasReset: false)
        {
            AudioState.StateChanged += this.OnStateChanged;
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            base.ActionImageChanged();
        }

        protected override void ApplyAdjustment(string actionParameter, int diff)
        {
            base.ActionImageChanged(actionParameter);
        }

        protected override BitmapImage GetAdjustmentImage(string actionParameter, PluginImageSize imageSize)
        {
            if (AudioState.HeadphonesMuted)
            {
                return PluginResources.ReadImage("headphones-muted.png");
            }
            else
            {
                return PluginResources.ReadImage("headphones-unmuted.png");
            }
        }
    }
}
