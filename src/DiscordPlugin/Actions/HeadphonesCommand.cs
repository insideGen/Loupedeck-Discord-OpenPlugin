namespace Loupedeck.DiscordPlugin
{
    using System;

    public class HeadphonesCommand : ActionEditorCommand
    {

        private const string headphonesShortcutControlName = "headphonesShortcut";
        private const string keyboardLayoutIdControlName = "keyboardLayoutId";

        public HeadphonesCommand()
            : base()
        {
            base.Name = "HeadphonesActionEditorCommand";
            base.DisplayName = "Mute/Unmute headphones";
            base.Description = "Mute/Unmute headphones.";
            base.ActionEditor.AddControlEx(new ActionEditorKeyboardKey(headphonesShortcutControlName, "Keyboard shortcut to mute headphones").SetRequired());
            base.ActionEditor.AddControlEx(new ActionEditorSlider(keyboardLayoutIdControlName, "Keyboard layout identifier", "Default value: -1").SetValues(-1, int.MaxValue, -1, 1).SetRequired());
            AudioState.StateChanged += (object sender, EventArgs e) => base.ActionImageChanged();
        }

        protected override bool RunCommand(ActionEditorActionParameters actionParameters)
        {
            AudioState.ToggleHeadphones();
            string headphonesShortcut = actionParameters.Parameters.GetValue(headphonesShortcutControlName);
            string keyboardLayoutId = actionParameters.Parameters.GetValue(keyboardLayoutIdControlName);
            KeyboardKey headphonesKeyboardKey = KeyboardExtensions.GetKeyboardKey(headphonesShortcut.Split("___")[0]);
            base.Plugin.KeyboardApi.SendShortcut(headphonesKeyboardKey.VirtualKeyCode, headphonesKeyboardKey.ModifierKey, int.Parse(keyboardLayoutId));
            return base.RunCommand(actionParameters);
        }

        protected override BitmapImage GetCommandImage(ActionEditorActionParameters actionParameters, int imageWidth, int imageHeight)
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
