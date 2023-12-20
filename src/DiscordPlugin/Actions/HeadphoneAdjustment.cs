namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphoneAdjustment : PluginDynamicAdjustment
    {

        protected const String headphoneUnmutedResourcePath = "headphone-unmuted.png";
        protected const String headphoneMutedResourcePath = "headphone-muted.png";

        public HeadphoneAdjustment()
            : base(displayName: "Display headphone state", description: "Display headphone state.", groupName: "Headphone", hasReset: false)
        {
            AudioState.headphoneAdjustment = this;
        }

        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            this.AdjustmentValueChanged(actionParameter);
            this.ActionImageChanged(actionParameter);
        }

        protected override BitmapImage GetAdjustmentImage(String actionParameter, PluginImageSize imageSize)
        {
            if (AudioState.microphoneCommand == null)
            {
                return PluginResources.ReadImage(headphoneUnmutedResourcePath);
            }
            else
            {
                return AudioState.headphoneCommand.GetCurrentStateName(actionParameter) == "muted"
                    ? PluginResources.ReadImage(headphoneMutedResourcePath)
                    : PluginResources.ReadImage(headphoneUnmutedResourcePath);
            }
        }

        public void RefreshImage()
        {
            this.ActionImageChanged();
        }

    }

}
