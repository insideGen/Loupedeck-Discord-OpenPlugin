namespace Loupedeck.DiscordPlugin
{
    using System;

    public class MicrophoneAdjustment : PluginDynamicAdjustment
    {

        protected const String microphoneUnmutedResourcePath = "microphone-unmuted.png";
        protected const String microphoneMutedResourcePath = "microphone-muted.png";

        public MicrophoneAdjustment()
            : base(displayName: "Display microphone state", description: "Display microphone state.", groupName: "Microphone", hasReset: false)
        {
            AudioState.microphoneAdjustment = this;
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
                return PluginResources.ReadImage(microphoneUnmutedResourcePath);
            }
            else
            {
                return AudioState.microphoneCommand.GetCurrentStateName(actionParameter) == "muted"
                    ? PluginResources.ReadImage(microphoneMutedResourcePath)
                    : PluginResources.ReadImage(microphoneUnmutedResourcePath);
            }
        }

        public void RefreshImage()
        {
            this.ActionImageChanged();
        }

    }

}
