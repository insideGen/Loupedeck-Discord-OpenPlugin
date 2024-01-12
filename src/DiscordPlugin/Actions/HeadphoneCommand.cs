namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphoneCommand : ActionEditorCommand
    {

        private const string headphoneShortcutControlName = "headphoneShortcut";
        private const string keyboardLayoutIdControlName = "keyboardLayoutId";

        public HeadphoneCommand()
            : base()
        {
            base.Name = "HeadphoneActionEditorCommand";
            base.DisplayName = "Mute/Unmute headphone";
            base.Description = "Mute/Unmute headphone.";
            base.ActionEditor.AddControlEx(new ActionEditorKeyboardKey(headphoneShortcutControlName, "Keyboard shortcut to mute headphone").SetRequired());
            base.ActionEditor.AddControlEx(new ActionEditorSlider(keyboardLayoutIdControlName, "Keyboard layout identifier", "Default value: -1").SetValues(-1, int.MaxValue, -1, 1).SetRequired());
            AudioState.StateChanged += (object sender, EventArgs e) => base.ActionImageChanged();
        }

        protected override bool RunCommand(ActionEditorActionParameters actionParameters)
        {
            AudioState.ToggleHeadphone();
            string headphoneShortcut = actionParameters.Parameters.GetValue(headphoneShortcutControlName);
            string keyboardLayoutId = actionParameters.Parameters.GetValue(keyboardLayoutIdControlName);
            KeyboardKey headphoneKeyboardKey = KeyboardExtensions.GetKeyboardKey(headphoneShortcut.Split("___")[0]);
            base.Plugin.KeyboardApi.SendShortcut(headphoneKeyboardKey.VirtualKeyCode, headphoneKeyboardKey.ModifierKey, int.Parse(keyboardLayoutId));
            return base.RunCommand(actionParameters);
        }

        protected override BitmapImage GetCommandImage(ActionEditorActionParameters actionParameters, int imageWidth, int imageHeight)
        {
            if (AudioState.HeadphoneMuted)
            {
                return PluginResources.ReadImage("headphone-muted.png");
            }
            else
            {
                return PluginResources.ReadImage("headphone-unmuted.png");
            }
        }

    }

}
