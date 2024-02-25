namespace Loupedeck.DiscordPlugin
{
    using System;

    public class MicrophoneCommand : ActionEditorCommand
    {
        private const string microphoneShortcutControlName = "microphoneShortcut";
        private const string keyboardLayoutIdControlName = "keyboardLayoutId";

        public MicrophoneCommand() : base()
        {
            base.Name = "MicrophoneActionEditorCommand";
            base.DisplayName = "Mute/Unmute microphone";
            base.Description = "Mute/Unmute microphone.";
            base.ActionEditor.AddControlEx(new ActionEditorKeyboardKey(microphoneShortcutControlName, "Keyboard shortcut to mute microphone").SetRequired());
            base.ActionEditor.AddControlEx(new ActionEditorSlider(keyboardLayoutIdControlName, "Keyboard layout identifier", "Default value: -1").SetValues(-1, int.MaxValue, -1, 1).SetRequired());
            AudioState.StateChanged += (object sender, EventArgs e) => base.ActionImageChanged();
        }

        protected override bool RunCommand(ActionEditorActionParameters actionParameters)
        {
            AudioState.ToggleMicrophone();
            string microphoneShortcut = actionParameters.Parameters.GetValue(microphoneShortcutControlName);
            string keyboardLayoutId = actionParameters.Parameters.GetValue(keyboardLayoutIdControlName);
            KeyboardKey microphoneKeyboardKey = KeyboardExtensions.GetKeyboardKey(microphoneShortcut.Split("___")[0]);
            base.Plugin.KeyboardApi.SendShortcut(microphoneKeyboardKey.VirtualKeyCode, microphoneKeyboardKey.ModifierKey, int.Parse(keyboardLayoutId));
            return base.RunCommand(actionParameters);
        }

        protected override BitmapImage GetCommandImage(ActionEditorActionParameters actionParameters, int imageWidth, int imageHeight)
        {
            if (AudioState.MicrophoneMuted)
            {
                return PluginResources.ReadImage("microphone-muted.png");
            }
            else
            {
                return PluginResources.ReadImage("microphone-unmuted.png");
            }
        }
    }
}
