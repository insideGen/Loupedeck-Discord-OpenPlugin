namespace Loupedeck.DiscordPlugin
{
    using System;

    internal static class AudioState
    {

        public static MicrophoneCommand microphoneCommand = null;
        public static MicrophoneAdjustment microphoneAdjustment = null;
        public static Boolean microphoneMutedFromHeadphone = false;

        public static HeadphoneCommand headphoneCommand = null;
        public static HeadphoneAdjustment headphoneAdjustment = null;

        public static void ToggleMicrophone()
        {
            microphoneCommand.GetPlugin().KeyboardApi.SendShortcut(VirtualKeyCode.F11, ModifierKey.Alt, 3);
            microphoneCommand.Toggle();
            microphoneAdjustment.RefreshImage();

            if (microphoneCommand.GetCurrentStateName() == "unmuted" && headphoneCommand.GetCurrentStateName() == "muted")
            {
                headphoneCommand.Toggle();
                headphoneAdjustment.RefreshImage();
                microphoneMutedFromHeadphone = false;
            }
        }

        public static void ToggleHeadphone()
        {
            headphoneCommand.GetPlugin().KeyboardApi.SendShortcut(VirtualKeyCode.F12, ModifierKey.Alt, 3);
            headphoneCommand.Toggle();
            headphoneAdjustment.RefreshImage();

            if (headphoneCommand.GetCurrentStateName() == "muted" && microphoneCommand.GetCurrentStateName() == "unmuted")
            {
                microphoneCommand.Toggle();
                microphoneAdjustment.RefreshImage();
                microphoneMutedFromHeadphone = true;
            }
            else if (headphoneCommand.GetCurrentStateName() == "unmuted" && microphoneCommand.GetCurrentStateName() == "muted")
            {
                if (microphoneMutedFromHeadphone)
                {
                    microphoneCommand.Toggle();
                    microphoneAdjustment.RefreshImage();
                    microphoneMutedFromHeadphone = false;
                }
            }
        }

    }

}
