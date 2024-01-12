namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphoneAdjustment : PluginDynamicAdjustment
    {

        private const string headphoneUnmutedResourcePath = "headphone-unmuted.png";
        private const string headphoneMutedResourcePath = "headphone-muted.png";

        public HeadphoneAdjustment()
            : base(displayName: "Display headphone state", description: "Display headphone state.", groupName: "", hasReset: false)
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
            if (AudioState.HeadphoneMuted)
            {
                return PluginResources.ReadImage(headphoneMutedResourcePath);
            }
            else
            {
                return PluginResources.ReadImage(headphoneUnmutedResourcePath);
            }
        }

    }

}
