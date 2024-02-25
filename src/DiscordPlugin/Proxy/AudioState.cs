namespace Loupedeck.DiscordPlugin
{
    using System;

    internal static class AudioState
    {
        public static event EventHandler<EventArgs> StateChanged;

        private static bool _microphoneMutedFromHeadphones = false;

        public static bool MicrophoneMuted { get; private set; } = false;
        public static bool HeadphonesMuted { get; private set; } = false;

        public static void ToggleMicrophone()
        {
            MicrophoneMuted = !MicrophoneMuted;
            if (MicrophoneMuted == false && HeadphonesMuted == true)
            {
                HeadphonesMuted = false;
                _microphoneMutedFromHeadphones = false;
            }
            StateChanged?.Invoke(null, new EventArgs());
        }

        public static void ToggleHeadphones()
        {
            HeadphonesMuted = !HeadphonesMuted;
            if (HeadphonesMuted == true && MicrophoneMuted == false)
            {
                MicrophoneMuted = true;
                _microphoneMutedFromHeadphones = true;
            }
            else if (HeadphonesMuted == false && MicrophoneMuted == true)
            {
                if (_microphoneMutedFromHeadphones)
                {
                    MicrophoneMuted = false;
                    _microphoneMutedFromHeadphones = false;
                }
            }
            StateChanged?.Invoke(null, new EventArgs());
        }
    }
}
