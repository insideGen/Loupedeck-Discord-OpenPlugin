namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphoneCommand : PluginMultistateDynamicCommand
    {

        protected const String headphoneUnmutedResourcePath = "headphone-unmuted.png";
        protected const String headphoneMutedResourcePath = "headphone-muted.png";

        public HeadphoneCommand()
            : base(displayName: "Mute/Unmute headphone", description: "Mute/Unmute headphone (Use the Alt+F12 keyboard shortcut in Discord).", groupName: "Headphone")
        {
            this.AddState("unmuted", "Unmuted", "Headphone is unmuted");
            this.AddState("muted", "Muted", "Headphone is muted");
            this.SetCurrentState(0);
            AudioState.headphoneCommand = this;
        }

        protected override void RunCommand(String actionParameter)
        {
            AudioState.ToggleHeadphone();
        }

        protected override BitmapImage GetCommandImage(String actionParameter, Int32 deviceState, PluginImageSize imageSize)
        {
            return this.States[deviceState].Name == "muted"
                ? PluginResources.ReadImage(headphoneMutedResourcePath)
                : PluginResources.ReadImage(headphoneUnmutedResourcePath);
        }

        public Plugin GetPlugin()
        {
            return this.Plugin;
        }

        public String GetCurrentStateName(String actionParameter = null)
        {
            return this.GetCurrentState(actionParameter).Name;
        }

        public void Toggle(String actionParameter = null)
        {
            this.ToggleCurrentState(actionParameter);
            this.ActionImageChanged(actionParameter);
        }

    }

}
