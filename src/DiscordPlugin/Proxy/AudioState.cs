namespace Loupedeck.DiscordPlugin
{
    using System;

    internal static class AudioState
    {

        public static event EventHandler<EventArgs> StateChanged;

        private static bool _microphoneMutedFromHeadphone = false;

        public static bool MicrophoneMuted { get; private set; } = false;
        public static bool HeadphoneMuted { get; private set; } = false;

        public static void ToggleMicrophone()
        {
            MicrophoneMuted = !MicrophoneMuted;
            if (MicrophoneMuted == false && HeadphoneMuted == true)
            {
                HeadphoneMuted = false;
                _microphoneMutedFromHeadphone = false;
            }
            StateChanged?.Invoke(null, new EventArgs());
        }

        public static void ToggleHeadphone()
        {
            HeadphoneMuted = !HeadphoneMuted;
            if (HeadphoneMuted == true && MicrophoneMuted == false)
            {
                MicrophoneMuted = true;
                _microphoneMutedFromHeadphone = true;
            }
            else if (HeadphoneMuted == false && MicrophoneMuted == true)
            {
                if (_microphoneMutedFromHeadphone)
                {
                    MicrophoneMuted = false;
                    _microphoneMutedFromHeadphone = false;
                }
            }
            StateChanged?.Invoke(null, new EventArgs());
        }

    }

}
