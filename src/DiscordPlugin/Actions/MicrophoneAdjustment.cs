namespace Loupedeck.DiscordPlugin
{
    using System;

    public class MicrophoneAdjustment : PluginDynamicAdjustment
    {

        private const string microphoneUnmutedResourcePath = "microphone-unmuted.png";
        private const string microphoneMutedResourcePath = "microphone-muted.png";

        public MicrophoneAdjustment()
            : base(displayName: "Display microphone state", description: "Display microphone state.", groupName: "", hasReset: false)
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
            if (AudioState.MicrophoneMuted)
            {
                return PluginResources.ReadImage(microphoneMutedResourcePath);
            }
            else
            {
                return PluginResources.ReadImage(microphoneUnmutedResourcePath);
            }
        }

    }

}
