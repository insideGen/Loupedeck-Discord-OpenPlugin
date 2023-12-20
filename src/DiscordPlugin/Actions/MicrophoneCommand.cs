namespace Loupedeck.DiscordPlugin
{
    using System;

    public class MicrophoneCommand : PluginMultistateDynamicCommand
    {

        protected const String microphoneUnmutedResourcePath = "microphone-unmuted.png";
        protected const String microphoneMutedResourcePath = "microphone-muted.png";

        public MicrophoneCommand()
            : base(displayName: "Mute/Unmute microphone", description: "Mute/Unmute microphone (Use the Alt+F11 keyboard shortcut in Discord).", groupName: "Microphone")
        {
            this.AddState("unmuted", "Unmuted", "Microphone is unmuted");
            this.AddState("muted", "Muted", "Microphone is muted");
            this.SetCurrentState(0);
            AudioState.microphoneCommand = this;
        }

        protected override void RunCommand(String actionParameter)
        {
            AudioState.ToggleMicrophone();
        }

        protected override BitmapImage GetCommandImage(String actionParameter, Int32 deviceState, PluginImageSize imageSize)
        {
            return this.States[deviceState].Name == "muted"
                ? PluginResources.ReadImage(microphoneMutedResourcePath)
                : PluginResources.ReadImage(microphoneUnmutedResourcePath);
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
